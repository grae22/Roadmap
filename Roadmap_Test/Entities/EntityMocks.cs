using Roadmapp.Entities;

namespace Roadmapp_Test.Entities
{
  class EntityMocks
  {
    //-------------------------------------------------------------------------

    public class EntityMock1 : Entity
    {
      public override string TypeName
      {
        get
        {
          return "Mock1";
        }
      }

      public EntityMock1( EntityRelationshipManager relationshipManager )
      :
        base( relationshipManager )
      {

      }
    }

    //-------------------------------------------------------------------------
    
    public class EntityMock2 : Entity
    {
      public override string TypeName
      {
        get
        {
          return "Mock2";
        }
      }

      public EntityMock2( EntityRelationshipManager relationshipManager )
      :
        base( relationshipManager )
      {

      }
    }

    //-------------------------------------------------------------------------
  }
}
