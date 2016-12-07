using Microsoft.VisualStudio.TestTools.UnitTesting;
using Roadmap.Entities;

namespace Roadmap_Test.Entities
{
  [TestClass]
  public class StrategyEntity_Test
  {
    //-------------------------------------------------------------------------

    private EntityFactory Factory = new EntityFactory();
    private StrategyEntity TestObject { get; set; }

    //-------------------------------------------------------------------------

    [TestInitialize]
    public void Initialise()
    {
      TestObject = Factory.GetStrategyEntity();
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
    public void DependOnGoal()
    {
      GoalEntity other = Factory.GetGoalEntity();

      bool result = TestObject.AddDependency( other );
      Assert.IsFalse( result, "Should not be able to depend on Goal entities." );
    }

    //-------------------------------------------------------------------------

    [TestMethod]
    public void DependOnAnotherStrategy()
    {
      StrategyEntity strategy = Factory.GetStrategyEntity();

      bool result = TestObject.AddDependency( strategy );
      Assert.IsTrue( result, "Should be able to depend on other Strategy entities." );
    }

    //-------------------------------------------------------------------------

    [TestMethod]
    public void DependOnRealisation()
    {
      RealisationEntity realisation = Factory.GetRealisationEntity();

      bool result = TestObject.AddDependency( realisation );
      Assert.IsTrue( result, "Should be able to depend on Realisation entities." );
    }

    //-------------------------------------------------------------------------
  }
}
