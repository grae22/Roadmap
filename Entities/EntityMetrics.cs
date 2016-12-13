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

    // The sum of all dependants' points.
    public int DependantsPointsTotal { get; private set; }

    //-------------------------------------------------------------------------

    public EntityMetrics( Entity entity )
    {
      Entity = entity;
    }

    //-------------------------------------------------------------------------

    public void Calculate()
    {
      DependantCount = 0;
      DependantsPointsTotal = 0;

      CalculateMetrics( Entity );
    }

    //-------------------------------------------------------------------------

    private void CalculateMetrics( Entity entity,
                                   List< Entity > countedEntities = null )
    {
      if( countedEntities == null )
      {
        countedEntities = new List< Entity >();
      }

      List< Entity > dependants;
      entity.GetDependants( out dependants );

      foreach( Entity dependant in dependants )
      {
        if( countedEntities.Contains( dependant ) == false )
        {
          DependantCount++;
          DependantsPointsTotal += dependant.Points;

          // Add to list so we don't process this entity again.
          countedEntities.Add( dependant );

          // Recurse into dependant's dependants.
          CalculateMetrics( dependant, countedEntities );
        }
      }
    }

    //-------------------------------------------------------------------------
  }
}
