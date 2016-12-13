using System.Collections.Generic;

namespace Roadmapp.Entities
{
  class EntityMetrics
  {
    //-------------------------------------------------------------------------

    // The entity for which these metrics pertain to.
    public Entity Entity { get; private set; }

    // The number of entities that have either a direct or indirect
    // dependency on his entity.
    public uint DependantCount { get; private set; }

    //-------------------------------------------------------------------------

    public EntityMetrics( Entity entity )
    {
      Entity = entity;
    }

    //-------------------------------------------------------------------------

    public void Calculate()
    {
      CalculateDependantCount( this );
    }

    //-------------------------------------------------------------------------

    private static void CalculateDependantCount( EntityMetrics metrics )
    {
      metrics.DependantCount = CountDependants( metrics.Entity );
    }

    //-------------------------------------------------------------------------

    private static uint CountDependants( Entity entity )
    {
      uint count = 0;

      List< Entity > dependants;
      entity.GetDependants( out dependants );

      foreach( Entity dependant in dependants )
      {
        count++;
        count += CountDependants( dependant );
      }

      return count;
    }

    //-------------------------------------------------------------------------
  }
}
