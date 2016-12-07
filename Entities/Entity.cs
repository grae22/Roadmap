namespace Roadmap.Entities
{
  abstract class Entity
  {
    //-------------------------------------------------------------------------

    // General.
    public string Title { get; set; }
    public string Description { get; set; }

    // Entity relationships.
    protected EntityRelationshipManager Relationships { get; private set; }

    //-------------------------------------------------------------------------

    public Entity( EntityRelationshipManager relationshipManager )
    {
      Relationships = relationshipManager;
    }

    //-------------------------------------------------------------------------

    public bool AddDependency( Entity dependency )
    {
      bool isDependencyAllowed =
        Relationships.GetIsDependencyAllowed(
          this.GetType(),
          dependency.GetType() );

      if( isDependencyAllowed == false )
      {
        return false;
      }

      return Relationships.AddDependency( this, dependency );
    }

    //-------------------------------------------------------------------------
  }
}
