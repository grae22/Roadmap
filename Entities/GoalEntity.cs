﻿namespace Roadmapp.Entities
{
  class GoalEntity : Entity
  {
    //-------------------------------------------------------------------------

    static GoalEntity()
    {
      // Specify the entities this type of entity can depend on.
      EntityRelationshipManager.AddAllowedDependency( typeof( GoalEntity ), typeof( GoalEntity ) );
      EntityRelationshipManager.AddAllowedDependency( typeof( GoalEntity ), typeof( StrategyEntity ) );
    }

    //-------------------------------------------------------------------------

    public GoalEntity( EntityRelationshipManager relationshipManager )
    :
      base( relationshipManager )
    {
    }

    //-------------------------------------------------------------------------
  }
}
