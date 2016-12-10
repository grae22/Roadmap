using System;
using System.Windows.Forms;
using System.Reflection;
using System.IO;

namespace Roadmapp
{
  static class Program
  {
    //-------------------------------------------------------------------------

    public static string AppPath { private set; get; }

    //-------------------------------------------------------------------------

    static Program()
    {
      try
      {
        AppPath =
          Path.GetDirectoryName(
            Assembly.GetExecutingAssembly().Location ) + Path.DirectorySeparatorChar;
      }
      catch( Exception ex )
      {
        HandleException( ex );
      }
    }

    //-------------------------------------------------------------------------

    [STAThread]
    static void Main( string[] args )
    {
      try
      {
        string roadmapFilename = null;

        if( args.Length > 0 )
        {
          roadmapFilename = args[ 0 ];
        }

        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault( false );
        Application.Run( new UI.Main( roadmapFilename ) );
      }
      catch( Exception ex )
      {
        HandleException( ex );
      }
    }

    //-------------------------------------------------------------------------

    public static void HandleException( Exception ex )
    {
      string errMsg = ex.Message;

      while( ( ex = ex.InnerException ) != null )
      {
        errMsg += Environment.NewLine + ex.Message;
      }

      MessageBox.Show(
        errMsg,
        "Error",
        MessageBoxButtons.OK,
        MessageBoxIcon.Error );
    }

    //-------------------------------------------------------------------------
  }
}
