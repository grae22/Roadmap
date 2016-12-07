using Roadmap.Entities;

namespace Roadmap_Test.Entities
{
  class EntityMocks
  {
    //-------------------------------------------------------------------------

    public class EntityMock1 : Entity
    {
      public EntityMock1( EntityRelationshipManager relationshipManager )
      :
        base( relationshipManager )
      {

      }
    }

    //-------------------------------------------------------------------------
    
    public class EntityMock2 : Entity
    {
      public EntityMock2( EntityRelationshipManager relationshipManager )
      :
        base( relationshipManager )
      {

      }
    }

    //-------------------------------------------------------------------------
  }
}
