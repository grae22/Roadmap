﻿using System.Collections.ObjectModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Roadmapp.Entities;

namespace Roadmapp_Test.Entities
{
  [TestClass]
  public class EntityRelationshipManager_Test
  {
    //-------------------------------------------------------------------------

    private EntityRelationshipManager TestObject { get; set; }

    //-------------------------------------------------------------------------

    [TestInitialize]
    public void Initialise()
    {
      TestObject = new EntityRelationshipManager();
    }

    //-------------------------------------------------------------------------

    [TestMethod]
    public void AllowedDependencies()
    {
      EntityRelationshipManager.AddAllowedDependency(
        typeof( EntityMocks.EntityMock1 ),
        typeof( EntityMocks.EntityMock2 ) );

      Assert.IsTrue(
        EntityRelationshipManager.GetIsDependencyAllowed(
          typeof( EntityMocks.EntityMock1 ),
          typeof( EntityMocks.EntityMock2 ) ) );

      Assert.IsFalse(
        EntityRelationshipManager.GetIsDependencyAllowed(
          typeof( EntityMocks.EntityMock2 ),
          typeof( EntityMocks.EntityMock1 ) ) );
    }

    //-------------------------------------------------------------------------

    [TestMethod]
    public void AddDependency()
    {
      EntityRelationshipManager.AddAllowedDependency(
        typeof( EntityMocks.EntityMock1 ),
        typeof( EntityMocks.EntityMock2 ) );

      EntityMocks.EntityMock1 mock1 = new EntityMocks.EntityMock1( TestObject );
      EntityMocks.EntityMock2 mock2 = new EntityMocks.EntityMock2( TestObject );

      bool result = TestObject.AddDependency( mock1, mock2 );
      Assert.IsTrue( result, "Failed to add dependency." );

      result = TestObject.AddDependency( mock2, mock1 );
      Assert.IsFalse( result, "Added a dependency that should've failed." );

      result = TestObject.AddDependency( mock1, mock1 );
      Assert.IsFalse( result, "Added itself as a dependency." );

      ReadOnlyCollection< Entity > dependencies;
      TestObject.GetDependencies( mock1, out dependencies );
      Assert.IsTrue( dependencies.Contains( mock2 ), "Dependency not found." );
    }

    //-------------------------------------------------------------------------

    [TestMethod]
    public void RemoveDependency()
    {
      // Set up allowed dependencies.
      EntityRelationshipManager.AddAllowedDependency(
        typeof( EntityMocks.EntityMock1 ),
        typeof( EntityMocks.EntityMock2 ) );

      // Set up entities.
      EntityMocks.EntityMock1 mock1 = new EntityMocks.EntityMock1( TestObject );
      EntityMocks.EntityMock2 mock2_1 = new EntityMocks.EntityMock2( TestObject );
      EntityMocks.EntityMock2 mock2_2 = new EntityMocks.EntityMock2( TestObject );

      // Add some dependencies.
      TestObject.AddDependency( mock1, mock2_1 );
      TestObject.AddDependency( mock1, mock2_2 );

      // Remove a dependency.
      TestObject.RemoveDependency( mock1, mock2_1 );

      // Check it was removed.
      ReadOnlyCollection< Entity > dependencies;
      TestObject.GetDependencies( mock1, out dependencies );
      Assert.IsFalse( dependencies.Contains( mock2_1 ), "Dependency still present." );

      // Check the other dependency is still present.
      TestObject.GetDependencies( mock1, out dependencies );
      Assert.IsTrue( dependencies.Contains( mock2_2 ), "Dependency not found." );
    }

    //-------------------------------------------------------------------------
  }
}
