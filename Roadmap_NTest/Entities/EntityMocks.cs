using Roadmapp.Entities;

namespace Roadmapp_NTest.Entities
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

      public EntityMock1( int id, EntityRelationshipManager relationshipManager )
      :
        base( id, relationshipManager )
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

      public EntityMock2( int id, EntityRelationshipManager relationshipManager )
      :
        base( id, relationshipManager )
      {

      }
    }

    //-------------------------------------------------------------------------
  }
}
