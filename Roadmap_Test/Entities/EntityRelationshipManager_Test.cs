﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Roadmap.Entities;

namespace Roadmap_Test.Entities
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
      TestObject.AddAllowedDependency( typeof( EntityMocks.EntityMock1 ),
                                       typeof( EntityMocks.EntityMock2 ) );

      Assert.IsTrue(
        TestObject.GetIsDependencyAllowed( typeof( EntityMocks.EntityMock1 ),
                                           typeof( EntityMocks.EntityMock2 ) ) );

      Assert.IsFalse(
        TestObject.GetIsDependencyAllowed( typeof( EntityMocks.EntityMock2 ),
                                           typeof( EntityMocks.EntityMock1 ) ) );
    }

    //-------------------------------------------------------------------------

    [TestMethod]
    public void AddDependency()
    {
      TestObject.AddAllowedDependency( typeof( EntityMocks.EntityMock1 ),
                                       typeof( EntityMocks.EntityMock2 ) );

      EntityMocks.EntityMock1 mock1 = new EntityMocks.EntityMock1( TestObject );
      EntityMocks.EntityMock2 mock2 = new EntityMocks.EntityMock2( TestObject );

      bool result = TestObject.AddDependency( mock1, mock2 );
      Assert.IsTrue( result, "Failed to add dependency." );

      result = TestObject.AddDependency( mock2, mock1 );
      Assert.IsFalse( result, "Added a dependency that should've failed." );

      result = TestObject.AddDependency( mock1, mock1 );
      Assert.IsFalse( result, "Added itself as a dependency." );
    }

    //-------------------------------------------------------------------------
  }
}