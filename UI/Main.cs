using System;
using System.Windows.Forms;
using Roadmapp.Core;

namespace Roadmapp.UI
{
  partial class Main : Form
  {
    //-------------------------------------------------------------------------

    private Roadmap ActiveRoadmap { get; set; }

    //-------------------------------------------------------------------------

    public Main( string roadmapFilename )
    {
      try
      {
        InitializeComponent();

        LoadRoadmap( roadmapFilename );
      }
      catch( Exception ex )
      {
        Program.HandleException( ex );
      }
    }

    //-------------------------------------------------------------------------

    private void LoadRoadmap( string filename )
    {
      try
      {
        ActiveRoadmap = Roadmap.InstantiateFromFile( filename );
      }
      catch( Exception ex )
      {
        Program.HandleException(
          new Exception(
            "Failed to load Roadmap '" + filename + "'.",
            ex ) );
      }
    }

    //-------------------------------------------------------------------------
  }
}
