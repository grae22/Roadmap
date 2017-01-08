using NUnit.Framework;
using Roadmapp.Entities;

namespace Roadmapp_NTest.Entities
{
  [TestFixture]
  public class ActionEntity_Test
  {
    //-------------------------------------------------------------------------

    private EntityFactory Factory = new EntityFactory( new EntityRelationshipManager() );
    private ActionEntity TestObject { get; set; }

    //-------------------------------------------------------------------------

    [SetUp]
    public void Initialise()
    {
      TestObject = Factory.GetActionEntity();
      Assert.IsNotNull( TestObject, "Failed to instantiate TestObject." );
    }

    //-------------------------------------------------------------------------

    [Test]
    public void Instantiate()
    {
      // Instantiation is performed in Initialise()
    }

    //-------------------------------------------------------------------------

    [Test]
    public void DependOnGoal()
    {
      GoalEntity other = Factory.GetGoalEntity();

      bool result = TestObject.AddDependency( other );
      Assert.IsFalse( result, "Should not be able to depend on Goals entities." );
    }

    //-------------------------------------------------------------------------

    [Test]
    public void DependOnStrategy()
    {
      StrategyEntity strategy = Factory.GetStrategyEntity();

      bool result = TestObject.AddDependency( strategy );
      Assert.IsFalse( result, "Should not be able to depend on Strategy entities." );
    }

    //-------------------------------------------------------------------------

    [Test]
    public void DependOnRealisation()
    {
      RealisationEntity realisation = Factory.GetRealisationEntity();

      bool result = TestObject.AddDependency( realisation );
      Assert.IsFalse( result, "Should not be able to depend on Realisation entities." );
    }

    //-------------------------------------------------------------------------

    [Test]
    public void DependOnOtherAction()
    {
      ActionEntity action = Factory.GetActionEntity();

      bool result = TestObject.AddDependency( action );
      Assert.IsTrue( result, "Should be able to depend on other Action entities." );
    }

    //-------------------------------------------------------------------------
  }
}
