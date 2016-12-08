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

    private EntityRelationshipManager EntityRelationships { get; set; }
    private EntityFactory EntityFactory { get; set; }

    // Entities organised by type and name.
    private Dictionary< Type, Dictionary< string, Entity > > Entities { get; set; }
      = new Dictionary< Type, Dictionary< string, Entity > >();

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

    private void AddEntity( Entity entity )
    {
      if( Entities.ContainsKey( entity.GetType() ) == false )
      {
        Entities.Add(
          entity.GetType(),
          new Dictionary< string, Entity >() );
      }

      Entities[ entity.GetType() ].Add( entity.Title, entity );
    }

    //-------------------------------------------------------------------------

    public void GetEntities< T >( out ReadOnlyDictionary< string, T > entities ) where T : Entity
    {
      Dictionary< string, T > tmp = new Dictionary< string, T >();

      if( Entities.ContainsKey( typeof( T ) ) )
      {
        foreach( KeyValuePair< string, Entity > pair in Entities[ typeof( T ) ] )
        {
          tmp.Add( pair.Key, (T)pair.Value );
        }
      }

      entities = new ReadOnlyDictionary< string, T >( tmp );
    }

    //-------------------------------------------------------------------------

    public Entity GetEntity( string title )
    {
      foreach( Dictionary< string, Entity > pair in Entities.Values )
      {
        if( pair.ContainsKey( title ) )
        {
          return pair[ title ];
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
        Entities[ type ].Remove( entity.Title );
      }
    }

    //-------------------------------------------------------------------------

    public bool GetIsTitleUnique( string name )
    {
      foreach( Dictionary< string, Entity > entities in Entities.Values )
      {
        if( entities.ContainsKey( name ) )
        {
          return false;
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
      foreach( Dictionary< string, Entity > pair in Entities.Values )
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

          XmlAttribute attrib = xml.OwnerDocument.CreateAttribute( "title" );
          entityDependencyXml.Attributes.Append( attrib );
          attrib.Value = entity.Title;

          // Entity's dependencies.
          ReadOnlyCollection< Entity > dependencies;
          EntityRelationships.GetDependencies( entity, out dependencies );

          foreach( Entity dependency in dependencies )
          {
            XmlElement dependencyXml = xml.OwnerDocument.CreateElement( "Dependency" );
            entityDependencyXml.AppendChild( dependencyXml );
            
            attrib = xml.OwnerDocument.CreateAttribute( "title" );
            dependencyXml.Attributes.Append( attrib );
            attrib.Value = dependency.Title;
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
        if( entityXml.HasAttribute( "title" ) == false )
        {
          throw new ArgumentException( "Dependant entity 'title' not found." );
        }

        string dependantTitle = entityXml.Attributes[ "title" ].Value;
        Entity dependant = GetEntity( dependantTitle );

        if( dependant == null )
        {
          throw new ArgumentException(
            string.Format( "Dependant Entity '{0}' not found.", dependantTitle ) );
        }

        // Dependency.
        foreach( XmlElement dependencyXml in entityXml )
        {
          if( dependencyXml.HasAttribute( "title" ) == false )
          {
            throw new ArgumentException(
              string.Format( "Dependant Entity '{0}' 'Dependency' element missing 'title' attribute.",
                             dependantTitle ) );
          }

          string dependencyTitle = dependencyXml.Attributes[ "title" ].Value;
          Entity dependency = GetEntity( dependencyTitle );

          if( dependency == null )
          {
            throw new ArgumentException(
              string.Format( "Dependant Entity '{0}' dependency '{1}' not found.",
                             dependantTitle,
                             dependencyTitle ) );
          }

          // Create the dependency.
          EntityRelationships.AddDependency( dependant, dependency );
        }
      }
    }

    //-------------------------------------------------------------------------
  }
}
