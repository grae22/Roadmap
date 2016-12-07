using System;

namespace Roadmap.Entities
{
  class EntityFactory
  {
    //-------------------------------------------------------------------------

    private EntityRelationshipManager EntityRelationships { get; set; } =
      new EntityRelationshipManager();

    //-------------------------------------------------------------------------

    public Entity GetEntity< T >() where T : Entity
    {
      return
        (Entity)Activator.CreateInstance(
          typeof( T ),
          new object[] { EntityRelationships } );
    }

    //-------------------------------------------------------------------------

    public GoalEntity GetGoalEntity()
    {
      return new GoalEntity( EntityRelationships );
    }

    //-------------------------------------------------------------------------

    public StrategyEntity GetStrategyEntity()
    {
      return new StrategyEntity( EntityRelationships );
    }

    //-------------------------------------------------------------------------

    public RealisationEntity GetRealisationEntity()
    {
      return new RealisationEntity( EntityRelationships );
    }

    //-------------------------------------------------------------------------
  }
}
