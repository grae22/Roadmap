﻿using NUnit.Framework;
using Roadmapp.Entities;

namespace Roadmapp_NTest.Entities
{
  [TestFixture]
  public class EntityMetrics_Test
  {
    //-------------------------------------------------------------------------

    private EntityFactory Factory = new EntityFactory( new EntityRelationshipManager() );
    private EntityMetrics TestObject { get; set; }

    //-------------------------------------------------------------------------

    [SetUp]
    public void Initialise()
    {
      TestObject = new EntityMetrics( Factory.GetRealisationEntity() );
      Assert.IsNotNull( TestObject, "Failed to instantiate TestObject." );
    }

    //-------------------------------------------------------------------------

    [Test]
    public void SingleDependantCount()
    {
      Factory.GetStrategyEntity().AddDependency( TestObject.Entity );

      TestObject.Calculate();

      Assert.AreEqual( 1U, TestObject.DependantCount, "Dependant count is incorrect." );
    }

    //-------------------------------------------------------------------------

    [Test]
    public void MultipleDependantsCount()
    {
      Factory.GetStrategyEntity().AddDependency( TestObject.Entity );
      Factory.GetStrategyEntity().AddDependency( TestObject.Entity );
      Factory.GetStrategyEntity().AddDependency( TestObject.Entity );

      TestObject.Calculate();

      Assert.AreEqual( 3U, TestObject.DependantCount, "Dependant count is incorrect." );
    }

    //-------------------------------------------------------------------------
    
    [Test]
    public void MultipleIndirectDependantsCount()
    {
      Entity directDependant = Factory.GetStrategyEntity();

      // Create direct dependant.
      directDependant.AddDependency( TestObject.Entity );

      // Create indirect dependants.
      Factory.GetStrategyEntity().AddDependency( directDependant );
      Factory.GetStrategyEntity().AddDependency( directDependant );
      Factory.GetStrategyEntity().AddDependency( directDependant );

      TestObject.Calculate();

      Assert.AreEqual( 4U, TestObject.DependantCount, "Dependant count is incorrect." );
    }

    //-------------------------------------------------------------------------
    
    [Test]
    public void NoDuplicateDependantsViaDifferentRoutes()
    {
      Entity directDependant1 = Factory.GetStrategyEntity();
      Entity directDependant2 = Factory.GetStrategyEntity();
      Entity indirectDependant = Factory.GetGoalEntity();

      indirectDependant.AddDependency( directDependant1 );
      indirectDependant.AddDependency( directDependant2 );

      directDependant1.AddDependency( TestObject.Entity );
      directDependant2.AddDependency( TestObject.Entity );

      TestObject.Calculate();

      Assert.AreEqual( 3U, TestObject.DependantCount, "Dependant count is incorrect." );
    }

    //-------------------------------------------------------------------------
  }
}
