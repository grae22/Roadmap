using Microsoft.VisualStudio.TestTools.UnitTesting;
using Roadmapp.Core;

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
    public void TestMethod1()
    {
    }

    //-------------------------------------------------------------------------
  }
}