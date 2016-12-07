namespace Roadmap.Entities
{
  class GoalEntity : Entity
  {
    //-------------------------------------------------------------------------

    public GoalEntity( EntityRelationshipManager relationshipManager )
    :
      base( relationshipManager )
    {
      // Specify the entities this type of entity can depend on.
      Relationships.AddAllowedDependency( typeof( GoalEntity ), typeof( GoalEntity ) );
      Relationships.AddAllowedDependency( typeof( GoalEntity ), typeof( StrategyEntity ) );
    }

    //-------------------------------------------------------------------------
  }
}
