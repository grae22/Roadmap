﻿using System.Collections.ObjectModel;
using System.Collections.Generic;
using NUnit.Framework;
using Roadmapp.Entities;

namespace Roadmapp_NTest.Entities
{
  [TestFixture]
  public class EntityRelationshipManager_Test
  {
    //-------------------------------------------------------------------------

    private EntityRelationshipManager TestObject { get; set; }

    //-------------------------------------------------------------------------

    [SetUp]
    public void Initialise()
    {
      TestObject = new EntityRelationshipManager();
    }

    //-------------------------------------------------------------------------

    [Test]
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

    [Test]
    public void AddDependency()
    {
      // Set up allowed dependencies.
      EntityRelationshipManager.AddAllowedDependency(
        typeof( EntityMocks.EntityMock1 ),
        typeof( EntityMocks.EntityMock2 ) );

      // Create entities.
      EntityMocks.EntityMock1 mock1 = new EntityMocks.EntityMock1( 0, TestObject );
      EntityMocks.EntityMock2 mock2 = new EntityMocks.EntityMock2( 1, TestObject );

      // Create dependencies between entities.
      bool result = TestObject.AddDependency( mock1, mock2 );
      Assert.IsTrue( result, "Failed to add dependency." );

      result = TestObject.AddDependency( mock2, mock1 );
      Assert.IsFalse( result, "Added a dependency that should've failed." );

      result = TestObject.AddDependency( mock1, mock1 );
      Assert.IsFalse( result, "Added itself as a dependency." );

      // GetDependencies() method.
      ReadOnlyCollection< Entity > dependencies;
      TestObject.GetDependencies( mock1, out dependencies );
      Assert.IsTrue( dependencies.Contains( mock2 ), "Dependency not found." );

      // GetDoesDependencyExist() method.
      Assert.IsTrue( TestObject.GetDoesDependencyExist( mock1, mock2 ) );
      Assert.IsFalse( TestObject.GetDoesDependencyExist( mock2, mock1 ) );

      // GetDependants() method.
      List< Entity > dependants;
      TestObject.GetDependants( mock2, out dependants );

      Assert.IsTrue( dependants.Contains( mock1 ), "Dependant not found." );
    }

    //-------------------------------------------------------------------------

    [Test]
    public void RemoveDependency()
    {
      // Set up allowed dependencies.
      EntityRelationshipManager.AddAllowedDependency(
        typeof( EntityMocks.EntityMock1 ),
        typeof( EntityMocks.EntityMock2 ) );

      // Set up entities.
      EntityMocks.EntityMock1 mock1 = new EntityMocks.EntityMock1( 0, TestObject );
      EntityMocks.EntityMock2 mock2_1 = new EntityMocks.EntityMock2( 1, TestObject );
      EntityMocks.EntityMock2 mock2_2 = new EntityMocks.EntityMock2( 2, TestObject );

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

      // Remove the remaining dependency entity.
      TestObject.RemoveEntity( mock2_2 );

      // Check the dependency is now removed.
      TestObject.GetDependencies( mock1, out dependencies );
      Assert.IsFalse( dependencies.Contains( mock2_2 ), "Dependency still present." );
    }

    //-------------------------------------------------------------------------
  }
}
