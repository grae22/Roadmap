using System;
using System.Windows.Forms;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Web;
using Roadmapp.Core;
using Roadmapp.Entities;
using Roadmapp.Diagrams;

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
          UpdateAppTitle();
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

    private void Main_FormClosing( object sender, FormClosingEventArgs e )
    {
      try
      {
        if( RoadmapFilename != null )
        {
          DialogResult result =
            MessageBox.Show(
                  "Save before closing?",
                  "Save?",
                  MessageBoxButtons.YesNoCancel,
                  MessageBoxIcon.Question );

          switch( result )
          {
            case DialogResult.Yes:
              uiFileSave_Click( null, null );
              break;

            case DialogResult.No:
              break;

            case DialogResult.Cancel:
              e.Cancel = true;
              break;
          }
        }
      }
      catch( Exception ex )
      {
        Program.HandleException( ex );
      }
    }

    //-------------------------------------------------------------------------

    private void UpdateAppTitle()
    {
      try
      {
        Text = "Roadmap";

        if( RoadmapFilename != null )
        {
          Text += " [" + RoadmapFilename + "]";
        }
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
        UpdateAppTitle();
        PopulateEntityLists();
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
          UpdateAppTitle();
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
          LoadRoadmap( RoadmapFilename );
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

        ReadOnlyDictionary< int, T > entities;
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

    private void UpdateDiagram()
    {
      try
      {
        // Get graphviz bin path from settings.
        string graphvizBinPath =
          (string)Properties.Settings.Default[ "graphvizBinPath" ];

        if( graphvizBinPath == null ||
            Directory.Exists( graphvizBinPath ) == false )
        {
          MessageBox.Show(
            "GraphViz bin path not found.",
            "GraphViz",
            MessageBoxButtons.OK,
            MessageBoxIcon.Error );
          return;
        }

        // Create new diagram.
        GraphVizDiagram diagram =
          new GraphVizDiagram(
            graphvizBinPath,
            "Diagrams" + Path.DirectorySeparatorChar + "DiagramTemplate.gv" );

        // Get all the roadmap's entities.
        Dictionary< int, Entity > entities;
        ActiveRoadmap.GetEntities( out entities );

        foreach( Entity entity in entities.Values )
        {
          // Determine node colour & shape based on entity type.
          Color colour = Color.Gray;
          GraphVizDiagram.Node.NodeShape shape = GraphVizDiagram.Node.NodeShape.PENTAGON;

          if( entity is GoalEntity )
          {
            colour = Color.LightGreen;
            shape = GraphVizDiagram.Node.NodeShape.BOX;
          }
          else if( entity is StrategyEntity )
          {
            colour = Color.LightBlue;
            shape = GraphVizDiagram.Node.NodeShape.ELLIPSE;
          }
          else if( entity is RealisationEntity )
          {
            colour = Color.Bisque;
            shape = GraphVizDiagram.Node.NodeShape.OCTAGON;
          }

          // Build entity text.
          string entityTitle =
            string.Format(
              "<B>{0}</B><BR/>({1}) ",    // Trailing space prevents brackets from being partially clipped.
              HttpUtility.HtmlEncode( entity.Title ),
              entity.Points );

          string entityText = null;

          if( uiDiagramShowDescriptions.Checked &&
              entity.Description.Length > 0 )
          {
            entityText +=
              "<BR/>" +
              HttpUtility.HtmlEncode(
                entity.Description ).Replace(
                  Environment.NewLine, "<BR ALIGN='LEFT' />" ) +
              "<BR ALIGN='LEFT' />";
          }

          // Add a node for the entity.
          diagram.AddNode(
            entity.Id,
            entityTitle,
            entityText,
            50,
            colour,
            shape );

          // Add links for each of this entity's dependencies.
          ReadOnlyCollection< Entity > dependencies;
          entity.GetDependencies( entity, out dependencies );

          foreach( Entity dependency in dependencies )
          {
            diagram.AddLinkToNode( entity.Id, dependency.Id );
          }
        }

        // Create the actual diagram file.
        string diagramFilename = diagram.CreateDiagram();

        if( diagramFilename != null )
        {
          uiDiagram.Image = new Bitmap( diagramFilename );
        }
      }
      catch( Exception ex )
      {
        Program.HandleException( ex );
      }
    }

    //-------------------------------------------------------------------------

    private void uiFileNew_Click( object sender, EventArgs e )
    {
      try
      {
        if( MessageBox.Show(
              "Discard any changes to current Roadmap?",
              "New Roadmap",
              MessageBoxButtons.YesNo,
              MessageBoxIcon.Warning ) == DialogResult.Yes )
        {
          RoadmapFilename = null;
          ActiveRoadmap = new Roadmap();
          UpdateAppTitle();
          PopulateEntityLists();
        }
      }
      catch( Exception ex )
      {
        Program.HandleException( ex );
      }
    }

    //-------------------------------------------------------------------------

    private void uiMainTabs_SelectedIndexChanged( object sender, EventArgs e )
    {
      try
      {
        if( uiMainTabs.SelectedTab == uiDiagramTab )
        {
          UpdateDiagram();
        }
      }
      catch( Exception ex )
      {
        Program.HandleException( ex );
      }
    }

    //-------------------------------------------------------------------------

    private void uiDiagramShowDescriptions_Click( object sender, EventArgs e )
    {
      try
      {
        uiDiagramShowDescriptions.Checked = !uiDiagramShowDescriptions.Checked;
        UpdateDiagram();
      }
      catch( Exception ex )
      {
        Program.HandleException( ex );
      }
    }

    //-------------------------------------------------------------------------
  }
}
