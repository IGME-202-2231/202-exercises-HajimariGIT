using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionManager : MonoBehaviour
{
    [SerializeField]
    List<SpriteInfo> collideables = new List<SpriteInfo>();
    // Start is called before the first frame update
   

    // Update is called once per frame
    void Update()
    {

        for(int i = 0; i < collideables.Count; i++)
        {
            collideables[0].IsColliding = AABBCheck(collideables[0], collideables[i]);
            collideables[i].IsColliding = AABBCheck(collideables[i], collideables[0]);
          

        }
        checkTwo();

        
    }

     bool AABBCheck(SpriteInfo spriteA, SpriteInfo spriteB)
     {
      // Check for collisions

      if(spriteB.RectMin.x < spriteA.RectMax.x &&
          spriteB.RectMax.x > spriteA.RectMin.x &&
          spriteB.RectMin.y < spriteA.RectMax.y)
      {
            return true;
      }
      else
      {
            return false;
      }
        
      
     }

    void checkOne()
    {
        collideables[0].IsColliding = AABBCheck(collideables[0], collideables[1]);
        collideables[1].IsColliding= AABBCheck(collideables[0], collideables[1]);
    }

    void checkTwo()
    {
        collideables[0].IsColliding = AABBCheck(collideables[0], collideables[2]);
        collideables[2].IsColliding = AABBCheck(collideables[0], collideables[2]);
    }

    void checkThree()
    {
        
        
            collideables[0].IsColliding = AABBCheck(collideables[0], collideables[3]);
            collideables[3].IsColliding = AABBCheck(collideables[0], collideables[3]);
        
    }

}
