namespace Roadmap.Entities
{
  class StrategyEntity : Entity
  {
    //-------------------------------------------------------------------------

    public StrategyEntity( EntityRelationshipManager relationshipManager )
    :
      base( relationshipManager )
    {
      // Specify the entities this type of entity can depend on.
      Relationships.AddAllowedDependency( typeof( StrategyEntity ), typeof( StrategyEntity ) );
      Relationships.AddAllowedDependency( typeof( StrategyEntity ), typeof( RealisationEntity ) );
    }

    //-------------------------------------------------------------------------
  }
}
