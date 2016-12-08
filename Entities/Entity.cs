using System;
using System.Xml;

namespace Roadmap.Entities
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

    // General.
    public string Title { get; set; }
    public string Description { get; set; }

    // Entity relationships.
    protected EntityRelationshipManager Relationships { get; private set; }

    //-------------------------------------------------------------------------

    public Entity( EntityRelationshipManager relationshipManager )
    {
      Relationships = relationshipManager;
    }

    //-------------------------------------------------------------------------

    public bool AddDependency( Entity dependency )
    {
      return Relationships.AddDependency( this, dependency );
    }

    //-------------------------------------------------------------------------

    virtual public void GetAsXml( XmlElement xml )
    {
      // Type.
      XmlAttribute attrib = xml.OwnerDocument.CreateAttribute( "type" );
      attrib.Value = GetType().AssemblyQualifiedName;
      xml.Attributes.Append( attrib );

      // Title.
      XmlElement element = xml.OwnerDocument.CreateElement( "Title" );
      element.InnerText = Title;
      xml.AppendChild( element );

      // Description.
      element = xml.OwnerDocument.CreateElement( "Description" );
      element.InnerText = Description;
      xml.AppendChild( element );
    }

    //-------------------------------------------------------------------------

    // <exception cref="System.ArgumentException">Thrown if expected xml elements are missing.</exception>
    virtual protected void InitialiseFromXml( XmlElement xml )
    {
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
    }

    //-------------------------------------------------------------------------
  }
}
