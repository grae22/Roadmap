using System.Collections.ObjectModel;
using System.Xml;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Roadmapp.Core;
using Roadmapp.Entities;
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
      ReadOnlyDictionary< string, EntityMocks.EntityMock1 > mock1Entities;
      TestObject.GetEntities< EntityMocks.EntityMock1 >( out mock1Entities );
      Assert.IsTrue( mock1Entities.ContainsKey( mock1.Title ), "Failed to retrieve entity." );

      ReadOnlyDictionary< string, EntityMocks.EntityMock2 > mock2Entities;
      TestObject.GetEntities< EntityMocks.EntityMock2 >( out mock2Entities );
      Assert.IsTrue( mock2Entities.ContainsKey( mock2.Title ), "Failed to retrieve entity." );
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
      ReadOnlyDictionary< string, EntityMocks.EntityMock1 > mock1Entities;
      TestObject.GetEntities< EntityMocks.EntityMock1 >( out mock1Entities );
      Assert.IsFalse( mock1Entities.ContainsKey( mock1.Title ), "Entity is still present." );
      
      // Check the other is still there.
      ReadOnlyDictionary< string, EntityMocks.EntityMock2 > mock2Entities;
      TestObject.GetEntities< EntityMocks.EntityMock2 >( out mock2Entities );
      Assert.IsTrue( mock2Entities.ContainsKey( mock2.Title ), "Failed to retrieve entity." );
    }
    
    //-------------------------------------------------------------------------

    [TestMethod]
    public void XmlPersistence()
    {
      // Set up allowed dependencies.
      EntityRelationshipManager.AddAllowedDependency(
        typeof( EntityMocks.EntityMock1 ),
        typeof( EntityMocks.EntityMock2 ) );

      // Add some entities.
      EntityMocks.EntityMock1 mock1 = TestObject.AddEntity< EntityMocks.EntityMock1 >();
      EntityMocks.EntityMock2 mock2_1 = TestObject.AddEntity< EntityMocks.EntityMock2 >();
      EntityMocks.EntityMock2 mock2_2 = TestObject.AddEntity< EntityMocks.EntityMock2 >();

      // Add dependencies.
      mock1.AddDependency( mock2_1 );
      mock1.AddDependency( mock2_2 );

      // Get as xml.
      XmlDocument xmlDoc = new XmlDocument();
      XmlElement xml = xmlDoc.CreateElement( "Roadmap" );
      TestObject.GetAsXml( xml );

      // Initialise a new roadmap using the xml.
      Roadmap newRoadmap = new Roadmap();
      newRoadmap.InitialiseFromXml( xml );

      // Check the entities are present.
      Entity newMock1 = newRoadmap.GetEntity( mock1.Title );
      Entity newMock2_1 = newRoadmap.GetEntity( mock2_1.Title );
      Entity newMock2_2 = newRoadmap.GetEntity( mock2_2.Title );

      Assert.IsNotNull( newMock1.Title, "Entity not found." );
      Assert.IsNotNull( newMock2_1.Title, "Entity not found." );
      Assert.IsNotNull( newMock2_2.Title, "Entity not found." );

      // Check the dependencies are present.
      ReadOnlyCollection< Entity > dependencies;
      newRoadmap.GetDependencies( newMock1, out dependencies );

      Assert.IsTrue( dependencies.Contains( newMock2_1 ), "Dependency not found." );
      Assert.IsTrue( dependencies.Contains( newMock2_2 ), "Dependency not found." );
    }

    //-------------------------------------------------------------------------
  }
}