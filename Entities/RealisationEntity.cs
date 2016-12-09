namespace Roadmapp.Entities
{
  class RealisationEntity : Entity
  {
    //-------------------------------------------------------------------------

    public override string TypeName
    {
      get
      {
        return "Realisation";
      }
    }

    //-------------------------------------------------------------------------

    static RealisationEntity()
    {
      // Specify the entities this type of entity can depend on.
      EntityRelationshipManager.AddAllowedDependency( typeof( RealisationEntity ), typeof( RealisationEntity ) );
      EntityRelationshipManager.AddAllowedDependency( typeof( RealisationEntity ), typeof( ActionEntity ) );
    }

    //-------------------------------------------------------------------------

    public RealisationEntity( int id,
                              EntityRelationshipManager relationshipManager )
    :
      base( id, relationshipManager )
    {
    }

    //-------------------------------------------------------------------------
  }
}
