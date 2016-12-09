using System;
using System.Windows.Forms;
using Roadmapp.Core;

namespace Roadmapp.UI
{
  partial class Main : Form
  {
    //-------------------------------------------------------------------------

    private string RoadmapFilename { get; set; }
    private Roadmap ActiveRoadmap { get; set; }

    //-------------------------------------------------------------------------

    public Main( string roadmapFilename )
    {
      try
      {
        // Set class vars.
        RoadmapFilename = roadmapFilename;

        // Init components.
        InitializeComponent();
      }
      catch( Exception ex )
      {
        Program.HandleException( ex );
      }
    }

    //-------------------------------------------------------------------------

    private void Main_Load( object sender, EventArgs e )
    {
      try
      {
        // Load roadmap from file if one was specified.
        if( RoadmapFilename != null )
        {
          LoadRoadmap( RoadmapFilename );
          Text = "Roadmap [" + RoadmapFilename + "]";
        }

        // Create a new roadmap if we don't have one by now.
        if( ActiveRoadmap == null )
        {
          ActiveRoadmap = new Roadmap();
        }
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

    private void SaveRoadmap( string filename )
    {
      try
      {
        if( ActiveRoadmap != null )
        {
          Roadmap.WriteToFile( filename, ActiveRoadmap );
        }
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

    private void uiFileSave_Click( object sender, EventArgs e )
    {
      try
      {
        // No roadmap filename?
        if( RoadmapFilename == null )
        {
          uiFileSaveAs_Click( null, null );
        }
        else
        {
          SaveRoadmap( RoadmapFilename );
        }
      }
      catch( Exception ex )
      {
        Program.HandleException( ex );
      }
    }

    //-------------------------------------------------------------------------

    private void uiFileSaveAs_Click( object sender, EventArgs e )
    {
      try
      {
        SaveFileDialog dlg = new SaveFileDialog();
        dlg.AddExtension = true;
        dlg.CheckPathExists = true;
        dlg.DefaultExt = "roadmap";
        dlg.Filter = "Roadmap files | *.roadmap";
        dlg.OverwritePrompt = true;
        dlg.Title = "Save Roadmap file...";
        dlg.ValidateNames = true;

        if( dlg.ShowDialog() == DialogResult.OK )
        {
          RoadmapFilename = dlg.FileName;
          SaveRoadmap( RoadmapFilename );
        }
      }
      catch( Exception ex )
      {
        Program.HandleException( ex );
      }
    }
    
    //-------------------------------------------------------------------------

    private void uiFileLoad_Click( object sender, EventArgs e )
    {
      try
      {
        OpenFileDialog dlg = new OpenFileDialog();
        dlg.AddExtension = true;
        dlg.CheckFileExists = true;
        dlg.CheckPathExists = true;
        dlg.DefaultExt = "roadmap";
        dlg.Filter = "Roadmap files | *.roadmap";
        dlg.Title = "Open Roadmap file...";
        dlg.ValidateNames = true;
        dlg.Multiselect = false;

        if( dlg.ShowDialog() == DialogResult.OK )
        {
          RoadmapFilename = dlg.FileName;
          ActiveRoadmap = Roadmap.InstantiateFromFile( RoadmapFilename );
        }
      }
      catch( Exception ex )
      {
        Program.HandleException( ex );
      }
    }

    //-------------------------------------------------------------------------

    private void uiAddEntity_Click( object sender, EventArgs e )
    {
      try
      {
      }
      catch( Exception ex )
      {
        Program.HandleException( ex );
      }
    }

    //-------------------------------------------------------------------------
  }
}
