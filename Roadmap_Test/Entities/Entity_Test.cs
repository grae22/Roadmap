using Microsoft.VisualStudio.TestTools.UnitTesting;
using Roadmap.Entities;

namespace Roadmap_Test.Entities
{
  [TestClass]
  public class Entity_Test
  {
    //-------------------------------------------------------------------------

    private Entity TestObject { get; set; }

    //-------------------------------------------------------------------------

    [TestInitialize]
    public void Initialise()
    {
      EntityFactory factory = new EntityFactory();

      TestObject = factory.GetEntity< EntityMocks.EntityMock1 >();
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
  }
}
