namespace Roadmapp.Entities
{
  class ActionEntity : Entity
  {
    //-------------------------------------------------------------------------

    static ActionEntity()
    {
      // Specify the entities this type of entity can depend on.
      EntityRelationshipManager.AddAllowedDependency( typeof( ActionEntity ), typeof( ActionEntity ) );
    }

    //-------------------------------------------------------------------------

    public ActionEntity( EntityRelationshipManager relationshipManager )
    :
      base( relationshipManager )
    {
    }

    //-------------------------------------------------------------------------
  }
}
