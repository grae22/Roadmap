namespace Roadmap.Entities
{
  class RealisationEntity : Entity
  {
    //-------------------------------------------------------------------------

    public RealisationEntity( EntityRelationshipManager relationshipManager )
    :
      base( relationshipManager )
    {
      // Specify the entities this type of entity can depend on.
      Relationships.AddAllowedDependency( typeof( RealisationEntity ), typeof( RealisationEntity ) );
    }

    //-------------------------------------------------------------------------
  }
}
