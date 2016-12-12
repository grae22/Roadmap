using System;
using System.Windows.Forms;
using System.Reflection;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Roadmapp.Entities;
using Roadmapp.Core;

namespace Roadmapp.UI
{
  partial class EntityDlg : Form
  {
    //-------------------------------------------------------------------------

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
        uiPoints.Text = Entity.Points.ToString();
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

        int points;
        if( int.TryParse( uiPoints.Text, out points ) == false )
        {
          MessageBox.Show(
            "Enter a numeric points value.",
            "Points",
            MessageBoxButtons.OK,
            MessageBoxIcon.Exclamation );
          uiPoints.Focus();
          return;
        }

        // Update entity's properties.
        Entity.Title = uiTitle.Text;
        Entity.Description = uiDescription.Text;
        Entity.Points = points;

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
