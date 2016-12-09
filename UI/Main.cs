using System;
using System.Windows.Forms;
using System.Collections.ObjectModel;
using Roadmapp.Core;
using Roadmapp.Entities;

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

        // Update the UI.
        PopulateEntityLists();
      }
      catch( Exception ex )
      {
        Program.HandleException( ex );
      }
    }

    //-------------------------------------------------------------------------

    private void PopulateEntityLists()
    {
      try
      {
        PopulateEntityList< GoalEntity >( uiGoals );
        PopulateEntityList< StrategyEntity >( uiStrategies );
        PopulateEntityList< RealisationEntity >( uiRealisations );
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

        dlg.Dispose();
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

        dlg.Dispose();
      }
      catch( Exception ex )
      {
        Program.HandleException( ex );
      }
    }

    //-------------------------------------------------------------------------
    
    private void PopulateEntityList< T >( ListBox list,
                                          Entity dependant = null ) where T : Entity
    {
      try
      {
        list.Items.Clear();

        ReadOnlyDictionary< string, T > entities;
        ActiveRoadmap.GetEntities( out entities );

        foreach( T entity in entities.Values )
        {
          if( dependant == null ||
              dependant.GetIsDependantOn( entity ) )
          {
            list.Items.Add( entity );
          }
        }
      }
      catch( Exception ex )
      {
        Program.HandleException( ex );
      }
    }

    //-------------------------------------------------------------------------

    private void uiAddGoal_Click( object sender, EventArgs e )
    {
      try
      {
        // Add new entity.
        Entity entity = ActiveRoadmap.AddEntity< GoalEntity >();

        // Show the entity properties dialog.
        EntityDlg dlg = new EntityDlg( ActiveRoadmap, entity );

        if( dlg.ShowDialog( this ) == DialogResult.OK )
        {
          PopulateEntityList< GoalEntity >( uiGoals );
          uiGoals.SelectedItem = entity;
        }
        else
        {
          ActiveRoadmap.RemoveEntity( entity );
        }

        dlg.Dispose();
      }
      catch( Exception ex )
      {
        Program.HandleException( ex );
      }
    }

    //-------------------------------------------------------------------------

    private void uiRemoveGoal_Click( object sender, EventArgs e )
    {
      try
      {
        Entity entity = (Entity)uiGoals.SelectedItem;

        if( entity == null )
        {
          return;
        }

        // Sure?
        if( MessageBox.Show(
              "Remove '" + entity.Title + "'?",
              "Confirmation",
              MessageBoxButtons.YesNo,
              MessageBoxIcon.Question ) == DialogResult.Yes )
        {
          ActiveRoadmap.RemoveEntity( entity );
          PopulateEntityList< GoalEntity >( uiGoals );
        }
      }
      catch( Exception ex )
      {
        Program.HandleException( ex );
      }
    }

    //-------------------------------------------------------------------------

    private void uiAddStrategy_Click( object sender, EventArgs e )
    {
      try
      {
        // Add new entity.
        Entity entity = ActiveRoadmap.AddEntity< StrategyEntity >();

        // Show the entity properties dialog.
        EntityDlg dlg = new EntityDlg( ActiveRoadmap, entity );

        if( dlg.ShowDialog( this ) == DialogResult.OK )
        {
          PopulateEntityList< StrategyEntity >( uiStrategies );
          uiStrategies.SelectedItem = entity;
        }
        else
        {
          ActiveRoadmap.RemoveEntity( entity );
        }

        dlg.Dispose();
      }
      catch( Exception ex )
      {
        Program.HandleException( ex );
      }
    }

    //-------------------------------------------------------------------------

    private void uiRemoveStrategy_Click( object sender, EventArgs e )
    {
      try
      {
        Entity entity = (Entity)uiStrategies.SelectedItem;

        if( entity == null )
        {
          return;
        }

        // Sure?
        if( MessageBox.Show(
              "Remove '" + entity.Title + "'?",
              "Confirmation",
              MessageBoxButtons.YesNo,
              MessageBoxIcon.Question ) == DialogResult.Yes )
        {
          ActiveRoadmap.RemoveEntity( entity );
          PopulateEntityList< StrategyEntity >( uiStrategies );
        }
      }
      catch( Exception ex )
      {
        Program.HandleException( ex );
      }
    }

    //-------------------------------------------------------------------------

    private void uiAddRealisation_Click( object sender, EventArgs e )
    {
      try
      {
        // Add new entity.
        Entity entity = ActiveRoadmap.AddEntity< RealisationEntity >();

        // Show the entity properties dialog.
        EntityDlg dlg = new EntityDlg( ActiveRoadmap, entity );

        if( dlg.ShowDialog( this ) == DialogResult.OK )
        {
          PopulateEntityList< RealisationEntity >( uiRealisations );
          uiRealisations.SelectedItem = entity;
        }
        else
        {
          ActiveRoadmap.RemoveEntity( entity );
        }

        dlg.Dispose();
      }
      catch( Exception ex )
      {
        Program.HandleException( ex );
      }
    }

    //-------------------------------------------------------------------------

    private void uiRemoveRealisation_Click( object sender, EventArgs e )
    {
      try
      {
        Entity entity = (Entity)uiRealisations.SelectedItem;

        if( entity == null )
        {
          return;
        }

        // Sure?
        if( MessageBox.Show(
              "Remove '" + entity.Title + "'?",
              "Confirmation",
              MessageBoxButtons.YesNo,
              MessageBoxIcon.Question ) == DialogResult.Yes )
        {
          ActiveRoadmap.RemoveEntity( entity );
          PopulateEntityList< RealisationEntity >( uiRealisations );
        }
      }
      catch( Exception ex )
      {
        Program.HandleException( ex );
      }
    }

    //-------------------------------------------------------------------------

    private void uiGoals_SelectedIndexChanged( object sender, EventArgs e )
    {
      try
      {
        PopulateEntityList< StrategyEntity >( uiStrategies, (Entity)uiGoals.SelectedItem );

        if( uiGoals.SelectedItem != null )
        {
          uiRealisations.Items.Clear();
        }
      }
      catch( Exception ex )
      {
        Program.HandleException( ex );
      }
    }

    //-------------------------------------------------------------------------

    private void uiStrategies_SelectedIndexChanged( object sender, EventArgs e )
    {
      try
      {
        PopulateEntityList< RealisationEntity >( uiRealisations, (Entity)uiStrategies.SelectedItem );
      }
      catch( Exception ex )
      {
        Program.HandleException( ex );
      }
    }

    //-------------------------------------------------------------------------

    private void uiGoals_DoubleClick( object sender, EventArgs e )
    {
      try
      {
        Entity entity = (Entity)uiGoals.SelectedItem;

        if( entity != null )
        {
          EntityDlg dlg = new EntityDlg( ActiveRoadmap, entity );
          dlg.ShowDialog( this );
          dlg.Dispose();

          PopulateEntityLists();
          uiGoals.SelectedItem = entity;
        }
      }
      catch( Exception ex )
      {
        Program.HandleException( ex );
      }
    }

    //-------------------------------------------------------------------------

    private void uiStrategies_DoubleClick( object sender, EventArgs e )
    {
      try
      {
        Entity entity = (Entity)uiStrategies.SelectedItem;

        if( entity != null )
        {
          EntityDlg dlg = new EntityDlg( ActiveRoadmap, entity );
          dlg.ShowDialog( this );
          dlg.Dispose();

          PopulateEntityLists();
          uiStrategies.SelectedItem = entity;
        }
      }
      catch( Exception ex )
      {
        Program.HandleException( ex );
      }
    }

    //-------------------------------------------------------------------------

    private void uiRealisations_DoubleClick( object sender, EventArgs e )
    {
      try
      {
        Entity entity = (Entity)uiRealisations.SelectedItem;

        if( entity != null )
        {
          EntityDlg dlg = new EntityDlg( ActiveRoadmap, entity );
          dlg.ShowDialog( this );
          dlg.Dispose();

          PopulateEntityLists();
          uiRealisations.SelectedItem = entity;
        }
      }
      catch( Exception ex )
      {
        Program.HandleException( ex );
      }
    }

    //-------------------------------------------------------------------------

    private void uiGoalsClearSelection_Click( object sender, EventArgs e )
    {
      try
      {
        uiGoals.SelectedItem = null;
        PopulateEntityLists();
      }
      catch( Exception ex )
      {
        Program.HandleException( ex );
      }
    }

    //-------------------------------------------------------------------------
  }
}
