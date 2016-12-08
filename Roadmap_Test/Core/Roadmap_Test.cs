using System.Collections.ObjectModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Roadmapp.Core;
using Roadmapp_Test.Entities;

namespace Roadmapp_Test.Core
{
  [TestClass]
  public class Roadmap_Test
  {
    //-------------------------------------------------------------------------

    private Roadmap TestObject { get; set; }

    //-------------------------------------------------------------------------

    [TestInitialize]
    public void Initialise()
    {
      TestObject = new Roadmap();
    }

    //-------------------------------------------------------------------------

    [TestMethod]
    public void AddEntities()
    {
      // Add some entities.
      EntityMocks.EntityMock1 mock1 = TestObject.AddEntity< EntityMocks.EntityMock1 >();
      Assert.IsNotNull( mock1, "Failed to add entity." );

      EntityMocks.EntityMock2 mock2 = TestObject.AddEntity< EntityMocks.EntityMock2 >();
      Assert.IsNotNull( mock2, "Failed to add entity." );

      // Check they're there.
      ReadOnlyCollection< EntityMocks.EntityMock1 > mock1Entities;
      TestObject.GetEntities< EntityMocks.EntityMock1 >( out mock1Entities );
      Assert.IsTrue( mock1Entities.Contains( mock1 ), "Failed to retrieve entity." );

      ReadOnlyCollection< EntityMocks.EntityMock2 > mock2Entities;
      TestObject.GetEntities< EntityMocks.EntityMock2 >( out mock2Entities );
      Assert.IsTrue( mock2Entities.Contains( mock2 ), "Failed to retrieve entity." );
    }

    //-------------------------------------------------------------------------

    [TestMethod]
    public void RemoveEntity()
    {
      // Add some entities.
      EntityMocks.EntityMock1 mock1 = TestObject.AddEntity< EntityMocks.EntityMock1 >();
      EntityMocks.EntityMock2 mock2 = TestObject.AddEntity< EntityMocks.EntityMock2 >();

      // Remove one.
      TestObject.RemoveEntity( mock1 );
      
      // Check it's gone.
      ReadOnlyCollection< EntityMocks.EntityMock1 > mock1Entities;
      TestObject.GetEntities< EntityMocks.EntityMock1 >( out mock1Entities );
      Assert.IsFalse( mock1Entities.Contains( mock1 ), "Entity is still present." );
      
      // Check the other is still there.
      ReadOnlyCollection< EntityMocks.EntityMock2 > mock2Entities;
      TestObject.GetEntities< EntityMocks.EntityMock2 >( out mock2Entities );
      Assert.IsTrue( mock2Entities.Contains( mock2 ), "Failed to retrieve entity." );
    }
    
    //-------------------------------------------------------------------------
  }
}