using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Xml;
using Roadmapp.Entities;

namespace Roadmapp.Core
{
  class Roadmap
  {
    //-------------------------------------------------------------------------

    public static Roadmap InstantiateFromFile( string absFilename )
    {
      XmlDocument xmlDoc = new XmlDocument();
      xmlDoc.Load( absFilename );

      Roadmap roadmap = new Roadmap();
      roadmap.InitialiseFromXml( xmlDoc.FirstChild as XmlElement );

      return roadmap;
    }

    //-------------------------------------------------------------------------

    public static void WriteToFile( string absFilename,
                                    Roadmap roadmap )
    {
      XmlDocument xmlDoc = new XmlDocument();
      XmlElement xml = xmlDoc.CreateElement( "Roadmap" );
      xmlDoc.AppendChild( xml );

      roadmap.GetAsXml( xml );

      xmlDoc.Save( absFilename );
    }

    //=========================================================================

    private EntityRelationshipManager EntityRelationships { get; set; }
    private EntityFactory EntityFactory { get; set; }

    // Entities organised by type and id.
    private Dictionary< Type, Dictionary< int, Entity > > Entities { get; set; }
      = new Dictionary< Type, Dictionary< int, Entity > >();

    //-------------------------------------------------------------------------

    public Roadmap()
    {
      EntityRelationships = new EntityRelationshipManager();
      EntityFactory = new EntityFactory( EntityRelationships );
    }

    //-------------------------------------------------------------------------

    public void Reset()
    {
      EntityRelationships.RemoveAllDependencies();
      Entities.Clear();
    }

    //-------------------------------------------------------------------------

    public T AddEntity< T >() where T : Entity
    {
      // Instantiate a new entity.
      T entity = (T)EntityFactory.GetEntity< T >();

      if( entity == null )
      {
        return null;
      }

      // Construct a title.
      string title = "Unnamed";
      int i = 1;
      while( GetIsTitleUnique( title ) == false )
      {
        title = string.Format( "Unnamed{0}", i++ );
      }

      entity.Title = title;

      // Add it.
      AddEntity( entity );

      return entity;
    }

    //-------------------------------------------------------------------------

    public Entity AddEntity( Type type )
    {
      Entity entity = EntityFactory.GetEntity( type.AssemblyQualifiedName );

      if( entity != null )
      {
        // Construct a title.
        string title = "Unnamed";
        int i = 1;
        while( GetIsTitleUnique( title ) == false )
        {
          title = string.Format( "Unnamed{0}", i++ );
        }

        entity.Title = title;

        // Add it.
        AddEntity( entity );
      }

      return entity;
    }

    //-------------------------------------------------------------------------

    private void AddEntity( Entity entity )
    {
      if( Entities.ContainsKey( entity.GetType() ) == false )
      {
        Entities.Add(
          entity.GetType(),
          new Dictionary< int, Entity >() );
      }

      Entities[ entity.GetType() ].Add( entity.Id, entity );
    }

    //-------------------------------------------------------------------------

    public void GetEntities< T >( out ReadOnlyDictionary< int, T > entities ) where T : Entity
    {
      Dictionary< int, T > tmp = new Dictionary< int, T >();

      if( Entities.ContainsKey( typeof( T ) ) )
      {
        foreach( KeyValuePair< int, Entity > pair in Entities[ typeof( T ) ] )
        {
          tmp.Add( pair.Key, (T)pair.Value );
        }
      }

      entities = new ReadOnlyDictionary< int, T >( tmp );
    }

    //-------------------------------------------------------------------------

    public void GetEntities( Type type,
                             out ReadOnlyDictionary< int, Entity > entities )
    {
      Dictionary< int, Entity > tmp = new Dictionary< int, Entity >();

      if( Entities.ContainsKey( type ) )
      {
        foreach( KeyValuePair< int, Entity > pair in Entities[ type ] )
        {
          tmp.Add( pair.Key, pair.Value );
        }
      }

      entities = new ReadOnlyDictionary< int, Entity >( tmp );
    }

    //-------------------------------------------------------------------------

    public Entity GetEntity( int id )
    {
      foreach( Dictionary< int, Entity > pair in Entities.Values )
      {
        if( pair.ContainsKey( id ) )
        {
          return pair[ id ];
        }
      }

      return null;
    }

    //-------------------------------------------------------------------------

    public void GetDependencies( Entity dependant,
                                 out ReadOnlyCollection< Entity > dependencies )
    {
      EntityRelationships.GetDependencies( dependant, out dependencies );
    }

    //-------------------------------------------------------------------------

    public void RemoveEntity( Entity entity )
    {
      Type type = entity.GetType();

      if( Entities.ContainsKey( type ) )
      {
        Entities[ type ].Remove( entity.Id );
      }
    }

    //-------------------------------------------------------------------------

    public bool GetIsTitleUnique( string name )
    {
      foreach( Dictionary< int, Entity > entities in Entities.Values )
      {
        foreach( Entity e in entities.Values )
        {
          if( name == e.Title )
          {
            return false;
          }
        }
      }

      return true;
    }

    //-------------------------------------------------------------------------

    public void GetAsXml( XmlElement xml )
    {
      //-- Add entities & their dependencies.
      XmlElement entitiesXml = xml.OwnerDocument.CreateElement( "Entities" );
      xml.AppendChild( entitiesXml );

      XmlElement dependenciesXml = xml.OwnerDocument.CreateElement( "EntityDependencies" );
      xml.AppendChild( dependenciesXml );

      // Iterate through each entity type.
      foreach( Dictionary< int, Entity > pair in Entities.Values )
      {
        // Iterate through each entity for the current entity type.
        foreach( Entity entity in pair.Values )
        {
          // Entity xml.
          XmlElement entityXml = xml.OwnerDocument.CreateElement( "Entity" );
          entitiesXml.AppendChild( entityXml );
          entity.GetAsXml( entityXml );

          //-- Dependency xml.

          // Dependant entity.
          XmlElement entityDependencyXml = xml.OwnerDocument.CreateElement( "Entity" );
          dependenciesXml.AppendChild( entityDependencyXml );

          XmlAttribute attrib = xml.OwnerDocument.CreateAttribute( "id" );
          entityDependencyXml.Attributes.Append( attrib );
          attrib.Value = entity.Id.ToString();

          // Entity's dependencies.
          ReadOnlyCollection< Entity > dependencies;
          EntityRelationships.GetDependencies( entity, out dependencies );

          foreach( Entity dependency in dependencies )
          {
            XmlElement dependencyXml = xml.OwnerDocument.CreateElement( "Dependency" );
            entityDependencyXml.AppendChild( dependencyXml );
            
            attrib = xml.OwnerDocument.CreateAttribute( "id" );
            dependencyXml.Attributes.Append( attrib );
            attrib.Value = dependency.Id.ToString();
          }
        }
      }
    }

    //-------------------------------------------------------------------------

    public void InitialiseFromXml( XmlElement xml )
    {
      Reset();

      // Load the Entities.
      if( xml.SelectSingleNode( "Entities" ) == null )
      {
        throw new ArgumentException( "'Entities' element not found." );
      }

      foreach( XmlElement entityXml in xml[ "Entities" ] )
      {
        AddEntity( Entity.InstantiateFromXml( EntityFactory, entityXml ) );        
      }

      // Load entity dependencies.
      if( xml.SelectSingleNode( "EntityDependencies" ) == null )
      {
        throw new ArgumentException( "'EntityDependencies' element not found." );
      }

      foreach( XmlElement entityXml in xml[ "EntityDependencies" ] )
      {
        // Dependant entity.
        if( entityXml.HasAttribute( "id" ) == false )
        {
          throw new ArgumentException( "Dependant entity 'id' not found." );
        }

        int dependantId = int.Parse( entityXml.Attributes[ "id" ].Value );
        Entity dependant = GetEntity( dependantId );

        if( dependant == null )
        {
          throw new ArgumentException(
            string.Format( "Dependant Entity '{0}' not found.", dependantId ) );
        }

        // Dependency.
        foreach( XmlElement dependencyXml in entityXml )
        {
          if( dependencyXml.HasAttribute( "id" ) == false )
          {
            throw new ArgumentException(
              string.Format( "Dependant Entity '{0}' 'Dependency' element missing 'id' attribute.",
                             dependantId ) );
          }

          int dependencyId = int.Parse( dependencyXml.Attributes[ "id" ].Value );
          Entity dependency = GetEntity( dependencyId );

          if( dependency == null )
          {
            throw new ArgumentException(
              string.Format( "Dependant Entity '{0}' dependency '{1}' not found.",
                             dependantId,
                             dependencyId ) );
          }

          // Create the dependency.
          EntityRelationships.AddDependency( dependant, dependency );
        }
      }
    }

    //-------------------------------------------------------------------------
  }
}
