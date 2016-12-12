using System;

namespace Roadmapp.Entities
{
  class EntityFactory
  {
    //-------------------------------------------------------------------------

    private EntityRelationshipManager EntityRelationships { get; set; }
    private int NextEntityId { get; set; } = 0;

    //-------------------------------------------------------------------------

    public EntityFactory( EntityRelationshipManager relationshipManager )
    {
      EntityRelationships = relationshipManager;
    }

    //-------------------------------------------------------------------------

    public Entity GetEntity< T >() where T : Entity
    {
      return
        (Entity)Activator.CreateInstance(
          typeof( T ),
          new object[] { NextEntityId++, EntityRelationships } );
    }

    //-------------------------------------------------------------------------

    public Entity GetEntity( string typeName )
    {
      try
      {
        return
          (Entity)Activator.CreateInstance(
            Type.GetType( typeName ),
            new object[] { NextEntityId++, EntityRelationships } );
      }
      catch( Exception )
      {
        return null;
      }
    }

    //-------------------------------------------------------------------------

    public GoalEntity GetGoalEntity()
    {
      return new GoalEntity( NextEntityId++, EntityRelationships );
    }

    //-------------------------------------------------------------------------

    public StrategyEntity GetStrategyEntity()
    {
      return new StrategyEntity( NextEntityId++, EntityRelationships );
    }

    //-------------------------------------------------------------------------

    public RealisationEntity GetRealisationEntity()
    {
      return new RealisationEntity( NextEntityId++, EntityRelationships );
    }

    //-------------------------------------------------------------------------

    public ActionEntity GetActionEntity()
    {
      return new ActionEntity( NextEntityId++, EntityRelationships );
    }

    //-------------------------------------------------------------------------

    public void SetNextId( int id )
    {
      NextEntityId = id;
    }

    //-------------------------------------------------------------------------
  }
}
