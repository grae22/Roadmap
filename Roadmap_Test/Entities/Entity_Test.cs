using System.Xml;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Roadmap.Entities;

namespace Roadmap_Test.Entities
{
  [TestClass]
  public class Entity_Test
  {
    //-------------------------------------------------------------------------

    private EntityFactory Factory = new EntityFactory();
    private Entity TestObject { get; set; }

    //-------------------------------------------------------------------------

    [TestInitialize]
    public void Initialise()
    {
      TestObject = Factory.GetEntity< EntityMocks.EntityMock1 >();
      Assert.IsNotNull( TestObject, "Failed to instantiate TestObject." );
    }

    //-------------------------------------------------------------------------

    [TestMethod]
    public void Instantiate()
    {
      // Instantiation is performed in Initialise()
    }

    //-------------------------------------------------------------------------

    [TestMethod]
    public void SetTitle()
    {
      TestObject.Title = "Title";
      Assert.AreEqual( "Title", TestObject.Title );
    }

    //-------------------------------------------------------------------------

    [TestMethod]
    public void SetDescription()
    {
      TestObject.Description = "Description";
      Assert.AreEqual( "Description", TestObject.Description );
    }

    //-------------------------------------------------------------------------

    [TestMethod]
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
    }

    //-------------------------------------------------------------------------
  }
}
