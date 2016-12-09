using System;

namespace Roadmapp.Entities
{
  class ActionEntity : Entity
  {
    //-------------------------------------------------------------------------

    public override string TypeName
    {
      get
      {
        return "Action";
      }
    }

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
