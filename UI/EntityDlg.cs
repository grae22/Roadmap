using System;
using System.Windows.Forms;
using System.Reflection;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using Roadmapp.Entities;
using Roadmapp.Core;

namespace Roadmapp.UI
{
  partial class EntityDlg : Form
  {
    //-------------------------------------------------------------------------

    private static Point LastPosition { get; set; } = Point.Empty;
    private static Size LastSize { get; set; } = Size.Empty;

    private Roadmap Roadmap { get; set; }
    private Entity Entity { get; set; }
    private Dictionary< string, Type > EntityTypes { get; set; } = new Dictionary< string, Type >();

    //-------------------------------------------------------------------------

    public EntityDlg( Roadmap roadmap,
                      Entity entity )
    {
      try
      {
        Roadmap = roadmap;
        Entity = entity;

        InitializeComponent();
        LookUpEntityTypes();
        PopualteTypeDropdownList();
        PopulateDependencies();
        PopulateFields();

        // Restore previous pos & size.
        if( LastPosition != Point.Empty )
        {
          StartPosition = FormStartPosition.Manual;
          Location = LastPosition;
        }

        if( LastSize != Size.Empty )
        {
          Size = LastSize;
        }
      }
      catch( Exception ex )
      {
        Program.HandleException( ex );
      }
    }

    //-------------------------------------------------------------------------
    
    private void EntityDlg_FormClosing( object sender, FormClosingEventArgs e )
    {
      try
      {
        LastPosition = Location;
        LastSize = Size;
      }
      catch( Exception ex )
      {
        Program.HandleException( ex );
      }
    }

    //-------------------------------------------------------------------------

    private void PopulateFields()
    {
      try
      {
        uiType.Text = Entity.TypeName;
        uiTitle.Text = Entity.Title;
        uiDescription.Text = Entity.Description;
        uiValuePoints.Text = Entity.ValuePoints.ToString();
        uiEffortPoints.Text = Entity.EffortPoints.ToString();
        uiPriorityPoints.Text = Entity.PriorityPoints.ToString();
      }
      catch( Exception ex )
      {
        Program.HandleException( ex );
      }
    }

    //-------------------------------------------------------------------------

    private void LookUpEntityTypes()
    {
      try
      {
        Type[] types = Assembly.GetExecutingAssembly().GetTypes();

        foreach( Type t in types )
        {
          if( t.IsSubclassOf( typeof( Entity ) ) )
          {
            Entity e = (Entity)Activator.CreateInstance( t, new object[] { 0, null } );
            EntityTypes.Add( e.TypeName, t );
          }
        }
      }
      catch( Exception ex )
      {
        Program.HandleException( ex );
      }
    }

    //-------------------------------------------------------------------------

    private void PopualteTypeDropdownList()
    {
      try
      {
        uiType.Items.Clear();

        foreach( string name in EntityTypes.Keys )
        {
          uiType.Items.Add( name );
        }
      }
      catch( Exception ex )
      {
        Program.HandleException( ex );
      }
    }

    //-------------------------------------------------------------------------

    private void PopulateDependencies()
    {
      try
      {
        uiDependencies.Items.Clear();

        // Iterate through all the entity types.
        foreach( Type type in EntityTypes.Values )
        {
          // Is the entity is allowed to depend on this type?
          bool dependencyAllowed =
            EntityRelationshipManager.GetIsDependencyAllowed(
              Entity.GetType(),
              type );

          if( dependencyAllowed )
          {
            // Get all the entities of the type (which we now know
            // the entity is allowed to depend on) and add to the UI list.
            ReadOnlyDictionary< int, Entity > entities;
            Roadmap.GetEntities( type, out entities );

            foreach( Entity e in entities.Values )
            {
              // Can't depend on itself.
              if( e != Entity )
              {
                uiDependencies.Items.Add(
                  e,
                  Entity.GetIsDependantOn( e ) );
              }
            }
          }
        }
      }
      catch( Exception ex )
      {
        Program.HandleException( ex );
      }
    }

    //-------------------------------------------------------------------------

    private void uiOk_Click( object sender, EventArgs e )
    {
      try
      {
        // Validate.
        if( uiTitle.Text.Length == 0 )
        {
          MessageBox.Show(
            "Enter a title.",
            "Title",
            MessageBoxButtons.OK,
            MessageBoxIcon.Exclamation );
          uiTitle.Focus();
          return;
        }

        int valuePoints;
        if( int.TryParse( uiValuePoints.Text, out valuePoints ) == false )
        {
          MessageBox.Show(
            "Enter a numeric points value.",
            "Value Points",
            MessageBoxButtons.OK,
            MessageBoxIcon.Exclamation );
          uiValuePoints.Focus();
          return;
        }

        int effortPoints;
        if( int.TryParse( uiEffortPoints.Text, out effortPoints ) == false )
        {
          MessageBox.Show(
            "Enter a numeric points value.",
            "Effort Points",
            MessageBoxButtons.OK,
            MessageBoxIcon.Exclamation );
          uiEffortPoints.Focus();
          return;
        }

        int priorityPoints;
        if( int.TryParse( uiPriorityPoints.Text, out priorityPoints ) == false )
        {
          MessageBox.Show(
            "Enter a numeric points value.",
            "Priority Points",
            MessageBoxButtons.OK,
            MessageBoxIcon.Exclamation );
          uiPriorityPoints.Focus();
          return;
        }

        // Update entity's properties.
        Entity.Title = uiTitle.Text;
        Entity.Description = uiDescription.Text;
        Entity.ValuePoints = valuePoints;
        Entity.EffortPoints = effortPoints;
        Entity.PriorityPoints = priorityPoints;

        Entity.RemoveDependencies();

        foreach( Entity entity in uiDependencies.CheckedItems )
        {
          Entity.AddDependency( entity );
        }

        // Close the dlg.
        DialogResult = DialogResult.OK;
        Close();
      }
      catch( Exception ex )
      {
        Program.HandleException( ex );
      }
    }

    //-------------------------------------------------------------------------

    private void uiType_SelectedIndexChanged( object sender, EventArgs e )
    {
      try
      {
        // Changing the type?
        if( uiType.Text != Entity.TypeName )
        {
          Roadmap.RemoveEntity( Entity );
          Entity newEntity = Roadmap.AddEntity( EntityTypes[ uiType.Text ] );
          
          newEntity.Title = Entity.Title;
          newEntity.Description = Entity.Description;

          Entity = newEntity;

          PopulateFields();
        }
      }
      catch( Exception ex )
      {
        Program.HandleException( ex );
      }
    }

    //-------------------------------------------------------------------------
  }
}
