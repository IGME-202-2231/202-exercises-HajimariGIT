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
        //loop through all objects for collisions while do while for each 
        //when collsion change color
    }

    bool AABBCheck(SpriteInfo spriteA, SpriteInfo spriteB)
    {
       

        return false;

    }
}
