using NUnit.Framework;
using System.Xml;
using Roadmapp.Entities;

namespace Roadmapp_NTest.Entities
{
  [TestFixture]
  public class Entity_Test
  {
    //-------------------------------------------------------------------------

    private EntityFactory Factory = new EntityFactory( new EntityRelationshipManager() );
    private Entity TestObject { get; set; }
    private int X { get; set; }

    //-------------------------------------------------------------------------

    [SetUp]
    public void Initialise()
    {
      TestObject = Factory.GetEntity< EntityMocks.EntityMock1 >();
      Assert.IsNotNull( TestObject, "Failed to instantiate TestObject." );
      X = 0;
    }

    //-------------------------------------------------------------------------

    [Test]
    public void Instantiate()
    {
      // Instantiation is performed in Initialise()
      Assert.AreEqual( 0, X++ );
    }

    //-------------------------------------------------------------------------

    [Test]
    public void SetTitle()
    {
      TestObject.Title = "Title";
      Assert.AreEqual( "Title", TestObject.Title );
      Assert.AreEqual( 0, X++ );
    }

    //-------------------------------------------------------------------------

    [Test]
    public void SetDescription()
    {
      TestObject.Description = "Description";
      Assert.AreEqual( "Description", TestObject.Description );
      Assert.AreEqual( 0, X++ );
    }

    //-------------------------------------------------------------------------

    [Test]
    public void XmlPersistence()
    {
      // Set property values.
      TestObject.Title = "TestObject";
      TestObject.Description = "Test description...";

      // Get entity as xml.
      XmlDocument xmlDoc = new XmlDocument();
      XmlElement xml = xmlDoc.CreateElement( "Entity" );

      TestObject.GetAsXml( xml );

      // Instantiate a new entity from the xml.
      Entity newEntity = Entity.InstantiateFromXml( Factory, xml );
      Assert.IsNotNull( newEntity, "Failed to instantiate." );

      // Correct type of entity instantiated?
      Assert.AreEqual(
        typeof( EntityMocks.EntityMock1 ),
        newEntity.GetType(),
        "Incorrect entity type instantiated." );

      // Test property values.
      Assert.AreEqual( TestObject.Title, newEntity.Title );
      Assert.AreEqual( TestObject.Description, newEntity.Description );
      Assert.AreEqual( 0, X++ );
    }

    //-------------------------------------------------------------------------
  }
}
