using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Roadmapp.Entities
{
  class EntityRelationshipManager
  {
    //-------------------------------------------------------------------------

    private static Dictionary< Type, List< Type > > AllowedDependencies { get; set; } =
      new Dictionary< Type, List< Type > >();

    private Dictionary< Entity, List< Entity > > Dependencies { get; set; } =
      new Dictionary< Entity, List< Entity > >();

    //-------------------------------------------------------------------------

    public static void AddAllowedDependency( Type dependant, Type dependency )
    {
      // Types must extend Entity class.
      if( dependant.IsSubclassOf( typeof( Entity ) ) == false ||
          dependency.IsSubclassOf( typeof( Entity ) ) == false )
      {
        throw new Exception( "Dependant and dependency types must extend Entity." );
      }

      // First time a dependant of this type is used?
      if( AllowedDependencies.ContainsKey( dependant ) == false )
      {
        AllowedDependencies.Add(
          dependant,
          new List< Type >() );
      }

      // Add the dependency for the dependant.
      if( AllowedDependencies[ dependant ].Contains( dependency ) == false )
      {
        AllowedDependencies[ dependant ].Add( dependency );
      }
    }

    //-------------------------------------------------------------------------

    public static bool GetIsDependencyAllowed( Type dependant, Type dependency )
    {
      if( AllowedDependencies.ContainsKey( dependant ) )
      {
        return AllowedDependencies[ dependant ].Contains( dependency );
      }

      return false;
    }

    //-------------------------------------------------------------------------

    public bool AddDependency( Entity dependant, Entity dependency )
    {
      // An entity can't depend on itself.
      if( dependant == dependency )
      {
        return false;
      }

      // Is the dependency allowed?
      bool isDependencyAllowed =
        GetIsDependencyAllowed( dependant.GetType(),
                                dependency.GetType() );

      if( isDependencyAllowed == false )
      {
        return false;
      }

      if( Dependencies.ContainsKey( dependant ) == false )
      {
        Dependencies.Add(
          dependant,
          new List< Entity >() );
      }

      if( Dependencies[ dependant ].Contains( dependency ) == false )
      {
        Dependencies[ dependant ].Add( dependency );
      }

      return true;
    }

    //-------------------------------------------------------------------------

    public void RemoveDependency( Entity dependant, Entity dependency )
    {
      if( Dependencies.ContainsKey( dependant ) )
      {
        Dependencies[ dependant ].Remove( dependency );
      }
    }

    //-------------------------------------------------------------------------

    public void GetDependencies( Entity dependant,
                                 out ReadOnlyCollection< Entity > dependencies )
    {
      List< Entity > list = new List< Entity >();

      if( Dependencies.ContainsKey( dependant ) )
      {
        list = Dependencies[ dependant ];
      }

      dependencies = new ReadOnlyCollection< Entity >( list );
    }

    //-------------------------------------------------------------------------

    public bool GetDoesDependencyExist( Entity dependant,
                                        Entity dependency )
    {
      if( Dependencies.ContainsKey( dependant ) )
      {
        return Dependencies[ dependant ].Contains( dependency );
      }

      return false;
    }

    //-------------------------------------------------------------------------

    public void RemoveAllDependencies()
    {
      Dependencies.Clear();
    }

    //-------------------------------------------------------------------------
  }
}
