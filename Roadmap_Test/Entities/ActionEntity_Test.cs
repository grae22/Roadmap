using Microsoft.VisualStudio.TestTools.UnitTesting;
using Roadmapp.Entities;

namespace Roadmapp_Test.Entities
{
  [TestClass]
  public class ActionEntity_Test
  {
    //-------------------------------------------------------------------------

    private EntityFactory Factory = new EntityFactory();
    private ActionEntity TestObject { get; set; }

    //-------------------------------------------------------------------------

    [TestInitialize]
    public void Initialise()
    {
      TestObject = Factory.GetActionEntity();
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
      Assert.IsFalse( result, "Should not be able to depend on Goals entities." );
    }

    //-------------------------------------------------------------------------

    [TestMethod]
    public void DependOnStrategy()
    {
      StrategyEntity strategy = Factory.GetStrategyEntity();

      bool result = TestObject.AddDependency( strategy );
      Assert.IsFalse( result, "Should not be able to depend on Strategy entities." );
    }

    //-------------------------------------------------------------------------

    [TestMethod]
    public void DependOnRealisation()
    {
      RealisationEntity realisation = Factory.GetRealisationEntity();

      bool result = TestObject.AddDependency( realisation );
      Assert.IsFalse( result, "Should not be able to depend on Realisation entities." );
    }

    //-------------------------------------------------------------------------

    [TestMethod]
    public void DependOnOtherAction()
    {
      ActionEntity action = Factory.GetActionEntity();

      bool result = TestObject.AddDependency( action );
      Assert.IsTrue( result, "Should be able to depend on other Action entities." );
    }

    //-------------------------------------------------------------------------
  }
}
