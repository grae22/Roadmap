using Microsoft.VisualStudio.TestTools.UnitTesting;
using Roadmapp.Entities;

namespace Roadmapp_Test.Entities
{
  [TestClass]
  public class EntityMetrics_Test
  {
    //-------------------------------------------------------------------------

    private EntityFactory Factory = new EntityFactory( new EntityRelationshipManager() );
    private EntityMetrics TestObject { get; set; }

    //-------------------------------------------------------------------------

    [TestInitialize]
    public void Initialise()
    {
      TestObject = new EntityMetrics( Factory.GetRealisationEntity() );
      Assert.IsNotNull( TestObject, "Failed to instantiate TestObject." );

      Factory.GetStrategyEntity().AddDependency( TestObject.Entity );

      TestObject.Calculate();
    }

    //-------------------------------------------------------------------------

    [TestMethod]
    public void DependantCount()
    {
      Assert.AreEqual( 1U, TestObject.DependantCount, "Dependant count is incorrect." );
    }

    //-------------------------------------------------------------------------
  }
}
