using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Roadmapp.Entities;

namespace Roadmapp.Core
{
  class Roadmap
  {
    //-------------------------------------------------------------------------

    // This Roadmap's entity factory.
    private EntityFactory EntityFactory { get; set; } = new EntityFactory();

    // Entities organised by type.
    private Dictionary< Type, List< Entity > > Entities { get; set; }
      = new Dictionary< Type, List< Entity > >();

    //-------------------------------------------------------------------------

    public T AddEntity< T >() where T : Entity
    {
      // Instantiate a new entity.
      T entity = (T)EntityFactory.GetEntity< T >();

      if( entity == null )
      {
        return null;
      }

      // Add it to our collection.
      if( Entities.ContainsKey( typeof( T ) ) == false )
      {
        Entities.Add(
          typeof( T ),
          new List< Entity >() );
      }

      Entities[ typeof( T ) ].Add( entity );

      return entity;
    }

    //-------------------------------------------------------------------------

    public void GetEntities< T >( out ReadOnlyCollection< T > entities ) where T : Entity
    {
      List< T > list = new List< T >();

      if( Entities.ContainsKey( typeof( T ) ) )
      {
        foreach( Entity entity in Entities[ typeof( T ) ] )
        {
          list.Add( (T)entity );
        }
      }

      entities = new ReadOnlyCollection< T >( list );
    }

    //-------------------------------------------------------------------------

    public void RemoveEntity( Entity entity )
    {
      Type type = entity.GetType();

      if( Entities.ContainsKey( type ) )
      {
        Entities[ type ].Remove( entity );
      }
    }

    //-------------------------------------------------------------------------
  }
}
