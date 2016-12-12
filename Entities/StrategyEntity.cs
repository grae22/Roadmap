namespace Roadmapp.Entities
{
  class StrategyEntity : Entity
  {
    //-------------------------------------------------------------------------

    public override string TypeName
    {
      get
      {
        return "Strategy";
      }
    }

    //-------------------------------------------------------------------------

    static StrategyEntity()
    {
      // Specify the entities this type of entity can depend on.
      EntityRelationshipManager.AddAllowedDependency( typeof( StrategyEntity ), typeof( StrategyEntity ) );
      EntityRelationshipManager.AddAllowedDependency( typeof( StrategyEntity ), typeof( RealisationEntity ) );
      EntityRelationshipManager.AddAllowedDependency( typeof( StrategyEntity ), typeof( GoalEntity ) );
    }

    //-------------------------------------------------------------------------

    public StrategyEntity( int id,
                           EntityRelationshipManager relationshipManager )
    :
      base( id, relationshipManager )
    {
    }

    //-------------------------------------------------------------------------
  }
}
