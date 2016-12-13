using System;
using System.Xml;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Roadmapp.Entities
{
  abstract class Entity
  {
    //-------------------------------------------------------------------------

    // <exception cref="System.ArgumentException">Thrown if expected xml elements are missing.</exception>
    public static Entity InstantiateFromXml( EntityFactory factory,
                                             XmlElement entityXml )
    {
      if( entityXml.HasAttribute( "type" ) == false )
      {
        throw new ArgumentException( "'type' attribute missing." );
      }

      Entity entity = factory.GetEntity( entityXml.Attributes[ "type" ].Value );

      if( entity != null )
      {
        entity.InitialiseFromXml( entityXml );
      }

      return entity;
    }

    //=========================================================================

    // Name of the entity type (e.g. Goal, Strategy, etc.).
    abstract public string TypeName { get; }

    // General.
    public int Id { get; private set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public int Points { get; set; } = 0;

    // Entity relationships.
    protected EntityRelationshipManager Relationships { get; private set; }

    // Metrics.
    public EntityMetrics Metrics { get; private set; }

    //-------------------------------------------------------------------------

    public Entity( int id,
                   EntityRelationshipManager relationshipManager )
    {
      Id = id;
      Relationships = relationshipManager;
      Metrics = new EntityMetrics( this );
    }

    //-------------------------------------------------------------------------

    public bool AddDependency( Entity dependency )
    {
      return Relationships.AddDependency( this, dependency );
    }

    //-------------------------------------------------------------------------

    public void GetDependencies( out ReadOnlyCollection< Entity > dependencies )
    {
      Relationships.GetDependencies( this, out dependencies );
    }

    //-------------------------------------------------------------------------

    public void GetDependants( out List< Entity > dependants )
    {
      Relationships.GetDependants( this, out dependants );
    }

    //-------------------------------------------------------------------------

    public bool GetIsDependantOn( Entity entity )
    {
      return Relationships.GetDoesDependencyExist( this, entity );
    }

    //-------------------------------------------------------------------------

    public void RemoveDependencies()
    {
      Relationships.RemoveDependencies( this );
    }

    //-------------------------------------------------------------------------

    virtual public void GetAsXml( XmlElement xml )
    {
      // Type.
      XmlAttribute attrib = xml.OwnerDocument.CreateAttribute( "type" );
      attrib.Value = GetType().AssemblyQualifiedName;
      xml.Attributes.Append( attrib );

      // Id.
      XmlElement element = xml.OwnerDocument.CreateElement( "Id" );
      element.InnerText = Id.ToString();
      xml.AppendChild( element );

      // Title.
      element = xml.OwnerDocument.CreateElement( "Title" );
      element.InnerText = Title;
      xml.AppendChild( element );

      // Description.
      element = xml.OwnerDocument.CreateElement( "Description" );
      element.InnerText = Description;
      xml.AppendChild( element );

      // Points.
      element = xml.OwnerDocument.CreateElement( "Points" );
      element.InnerText = Points.ToString();
      xml.AppendChild( element );
    }

    //-------------------------------------------------------------------------

    // <exception cref="System.ArgumentException">Thrown if expected xml elements are missing.</exception>
    virtual protected void InitialiseFromXml( XmlElement xml )
    {
      // Id.
      if( xml.SelectSingleNode( "Id" ) as XmlElement == null )
      {
        throw new ArgumentException( "'Id' element not found." );
      }

      Id = int.Parse( ( xml[ "Id" ] as XmlElement ).InnerText );

      // Title.
      if( xml.SelectSingleNode( "Title" ) as XmlElement == null )
      {
        throw new ArgumentException( "'Title' element not found." );
      }

      Title = ( xml[ "Title" ] as XmlElement ).InnerText;

      // Description.
      if( xml.SelectSingleNode( "Description" ) as XmlElement == null )
      {
        throw new ArgumentException( "'Description' element not found." );
      }

      Description = ( xml[ "Description" ] as XmlElement ).InnerText;

      // Points.
      if( xml.SelectSingleNode( "Points" ) as XmlElement == null )
      {
        throw new ArgumentException( "'Points' element not found." );
      }

      Points = int.Parse( ( xml[ "Points" ] as XmlElement ).InnerText );
    }

    //-------------------------------------------------------------------------

    public override string ToString()
    {
      return string.Format( "({0}) {1}", TypeName[ 0 ], Title );
    }

    //-------------------------------------------------------------------------
  }
}
