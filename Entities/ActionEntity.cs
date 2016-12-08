namespace Roadmap.Entities
{
  class ActionEntity : Entity
  {
    //-------------------------------------------------------------------------

    public ActionEntity( EntityRelationshipManager relationshipManager )
    :
      base( relationshipManager )
    {
      // Specify the entities this type of entity can depend on.
      Relationships.AddAllowedDependency( typeof( ActionEntity ), typeof( ActionEntity ) );
    }

    //-------------------------------------------------------------------------
  }
}
