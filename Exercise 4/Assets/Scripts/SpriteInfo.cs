using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteInfo : MonoBehaviour
{

    // Properties for min/max
    [SerializeField] SpriteRenderer renderer;
    bool isColliding = false;
    [SerializeField] Vector2 ractSize = Vector2.one;
    CollisionManager test = new CollisionManager();

    public float Radius
    {
        get { return renderer.bounds.size.x / 2 + 0.07f; }
    }
   
    
    public bool IsColliding
    {
        set { isColliding = value; }
    }

    public Vector3 RectMin
    {
        get { return renderer.bounds.min; }
    }

    public Vector3 RectMax
    {
        get { return renderer.bounds.max; }
    }

    public Vector3 center
    {
        get { return renderer.bounds.center; }
    }
   


    // Update is called once per frame
    void Update()
    {
      if(isColliding)
      {
            renderer.color = Color.red;
            
      } 
      else
      {
            renderer.color = Color.white;
      }
    }
    


}
