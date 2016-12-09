﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Diagnostics;
using System.Drawing;

namespace Roadmapp.Diagrams
{
  class GraphVizDiagram
  {
    //-------------------------------------------------------------------------

    public class Node
    {
      //-----------------------------------------------------------------------

      public enum NodeShape
      {
        BOX,
        CIRCLE,
        ELLIPSE,
        PENTAGON,
        HEXAGON,
        OCTAGON,
      }

      public int Id { get; private set; }
      public string Text { get; private set; }
      public Color Colour { get; private set; }
      public NodeShape Shape { get; private set; }
      public List<int> Links { get; private set; }

      //-----------------------------------------------------------------------

      public Node( int id,
                   string text,
                   Color colour,
                   NodeShape shape )
      {
        Id = id;
        Text = text;
        Colour = colour;
        Shape = shape;

        Links = new List<int>();
      }

      //-----------------------------------------------------------------------

      public void AddLink( int id )
      {
        if( Links.Contains( id ) == false )
        {
          Links.Add( id );
        }
      }

      //-----------------------------------------------------------------------

      public string ShapeAsString()
      {
        switch( Shape )
        {
          case NodeShape.BOX:
            return "box";

          case NodeShape.CIRCLE:
            return "circle";

          case NodeShape.ELLIPSE:
            return "ellipse";

          case NodeShape.PENTAGON:
            return "polygon sides=5";

          case NodeShape.HEXAGON:
            return "polygon sides=6";

          case NodeShape.OCTAGON:
            return "polygon sides=8";

          default:
            return "box";
        }
      }
    }

    //=========================================================================

    private const string c_tmpFolder = "GraphVisTmp";

    public Dictionary<int, Node> Nodes { get; private set; }

    private string _absGraphVizBinPath;
    private string _absTemplateFilename;

    //-------------------------------------------------------------------------

    public GraphVizDiagram( string absGraphVizBinPath,
                            string relTemplateFilename )
    {
      Nodes = new Dictionary<int,Node>();

      // GraphViz path.
      _absGraphVizBinPath = absGraphVizBinPath;

      if( _absGraphVizBinPath != null )
      {
        if( _absGraphVizBinPath[ _absGraphVizBinPath.Length - 1 ] !=  '\\' && 
            _absGraphVizBinPath[ _absGraphVizBinPath.Length - 1 ] !=  '/' )
        {
          _absGraphVizBinPath += '\\';
        }
      }

      if( _absGraphVizBinPath == null ||
          Directory.Exists( _absGraphVizBinPath ) == false )
      {
        throw new ArgumentNullException(
          "GraphViz bin path is null or was not found (" + _absGraphVizBinPath + ")." );
      }

      // Template file.
      if( relTemplateFilename == null )
      {
        throw new ArgumentNullException( "Template filename is null." );
      }

      _absTemplateFilename =
        Path.GetDirectoryName(
          System.Reflection.Assembly.GetExecutingAssembly().Location ) + '\\' + relTemplateFilename;

      if( File.Exists( _absTemplateFilename ) == false )
      {
        throw new ArgumentNullException(
          "Template file was not found (" + _absTemplateFilename + ")." );
      }
    }

    //-------------------------------------------------------------------------

    // maxCharsBeforeWrappingText: Set to 0 for no wrapping.

    public Node AddNode( int id,
                         string text,
                         int maxCharsBeforeWrappingText,
                         Color colour,
                         Node.NodeShape shape )
    {
      if( Nodes.ContainsKey( id ) == false )
      {
        // Wrap the text?
        if( maxCharsBeforeWrappingText > 0 &&
            text.Length > maxCharsBeforeWrappingText )
        {
          // Iterate through all chars in text.
          for( int i = 0; i + maxCharsBeforeWrappingText < text.Length; )
          {
            // Find the end of the last word that can be on the current line.
            int endOfLastWordIndex = 0;

            for( int c = i; c < i + maxCharsBeforeWrappingText; c++ )
            {
              if( text[ c ] == ' ' )
              {
                endOfLastWordIndex = c;
              }
            }

            if( endOfLastWordIndex == 0 )
            {
              endOfLastWordIndex = i + maxCharsBeforeWrappingText;
            }

            // Add new-line to end the current line.
            text = text.Insert( endOfLastWordIndex, Environment.NewLine );

            // Next line.
            i = endOfLastWordIndex + 2;
          }
        }

        // Create new node.
        Node newNode = new Node( id, text, colour, shape );
        Nodes.Add( id, newNode );
        return newNode;
      }

      return Nodes[ id ];
    }

    //-------------------------------------------------------------------------

    public void AddLinkToNode( int nodeId, int linkId )
    {
      if( Nodes.ContainsKey( nodeId ) )
      {
        Nodes[ nodeId ].AddLink( linkId );
      }
    }

    //-------------------------------------------------------------------------

    public string CreateDiagram()
    {
      try
      {
        // Read the template.
        string buffer = File.ReadAllText( _absTemplateFilename );

        // Compile the nodes & links text;
        string nodesText = "";
        string linksText = "";

        foreach( Node n in Nodes.Values )
        {
          string thisNodeIdAsString = n.Id.ToString();

          nodesText +=
            "  " +
            thisNodeIdAsString +
            " [" +
            "label=\"" + n.Text.Replace( '"', '\'' ) + "\" " +
            "shape=" + n.ShapeAsString() + " " +
            "fillcolor=\"#" + n.Colour.R.ToString( "X2" ) + n.Colour.G.ToString( "X2" ) + n.Colour.B.ToString( "X2" ) + "\"" +
            "];"
            + Environment.NewLine;

          foreach( int id in n.Links )
          {
            if( Nodes.ContainsKey( id ) )
            {
              linksText += "  " + thisNodeIdAsString + " -> " + id.ToString() + Environment.NewLine;
            }
          }
        }

        buffer = buffer.Replace( "<INSERT_NODES_HERE>", nodesText );
        buffer = buffer.Replace( "<INSERT_LINKS_HERE>", linksText );

        // Create a tmp filename for the graphviz file.
        string tmpPath =
          Path.GetDirectoryName(
            System.Reflection.Assembly.GetExecutingAssembly().Location ) + '\\' + c_tmpFolder + '\\';

        string tmpFilename = tmpPath + DateTime.Now.ToString( "yyyyMMddhhmmss" );

        if( Directory.Exists( tmpPath ) == false )
        {
          Directory.CreateDirectory( tmpPath );
        }

        // Write the gv file
        string gvFilename = tmpFilename + ".gv";
        File.WriteAllText( gvFilename, buffer );

        // Get graphvis to generate the diagram.
        string diagramFilename = tmpFilename + ".bmp";

       Process proc =
        Process.Start(
          _absGraphVizBinPath + "dot.exe",
          "\"" + gvFilename + "\" -o \"" + diagramFilename + "\" -T bmp" );

        proc.WaitForExit( 10000 );

        // Clean up.
        File.Delete( gvFilename );

        return diagramFilename;
      }
      catch( Exception ex )
      {
        throw ex;
      }
    }

    //-------------------------------------------------------------------------

    // Deletes contents for the GraphVisTmp

    public static void CleanupTmpFolder()
    {
      try
      {
        string absPath =
          Path.GetDirectoryName(
            System.Reflection.Assembly.GetExecutingAssembly().Location ) + '\\' + c_tmpFolder;

        if( Directory.Exists( absPath ) )
        {
          string[] files = Directory.GetFiles( absPath );

          foreach( string filename in files )
          {
            File.Delete( filename );
          }
        }
      }
      catch( Exception )
      {
        // Ignore.
      }
    }

    //-------------------------------------------------------------------------
  }
}
