using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteInfo : MonoBehaviour
{

   //controls the render
    [SerializeField] SpriteRenderer renderer;
    //collider value
    bool isColliding = false;
    //size of rectangle
    [SerializeField] Vector2 ractSize = Vector2.one;
    //refrebce if needed
    CollisionManager test = new CollisionManager();

    /// <summary>
    /// property for radius 
    /// </summary>
    public float Radius
    {
        //added a buffer to make it bigger 
        get { return renderer.bounds.size.x / 2 + 0.3f; }
    }
   
   /// <summary>
   /// property for collide
   /// </summary>
    public bool IsColliding
    {
        set { isColliding = value; }
    }

    /// <summary>
    /// property for min rectangle
    /// </summary>
    public Vector3 RectMin
    {
        get { return renderer.bounds.min; }
    }
    /// <summary>
    /// property for mac rectangle
    /// </summary>
    public Vector3 RectMax
    {
        get { return renderer.bounds.max; }
    }
    /// <summary>
    /// property for center of circle
    /// </summary>
    public Vector3 center
    {
        get { return renderer.bounds.center; }
    }
   


    // Update is called once per frame
    void Update()
    {
        //changes color
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
