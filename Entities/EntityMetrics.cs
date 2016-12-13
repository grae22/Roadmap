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
    public int DependantsValuePointsTotal { get; private set; }
    public int DependantsEffortPointsTotal { get; private set; }
    public int DependantsPriorityPointsTotal { get; private set; }

    //-------------------------------------------------------------------------

    public EntityMetrics( Entity entity )
    {
      Entity = entity;
    }

    //-------------------------------------------------------------------------

    public void Calculate()
    {
      DependantCount = 0;
      DependantsValuePointsTotal = Entity.ValuePoints;
      DependantsEffortPointsTotal = Entity.EffortPoints;
      DependantsPriorityPointsTotal = Entity.PriorityPoints;

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
      else if( countedEntities.Contains( entity ) )
      {
        return;
      }

      List< Entity > dependants;
      entity.GetDependants( out dependants );

      foreach( Entity dependant in dependants )
      {
        if( countedEntities.Contains( dependant ) == false )
        {
          DependantCount++;
          DependantsValuePointsTotal += dependant.ValuePoints;
          DependantsEffortPointsTotal += dependant.EffortPoints;
          DependantsPriorityPointsTotal += dependant.PriorityPoints;

          // Recurse into dependant's dependants.
          CalculateMetrics( dependant, countedEntities );

          // Add to list so we don't process this entity again.
          countedEntities.Add( dependant );
        }
      }
    }

    //-------------------------------------------------------------------------
  }
}
