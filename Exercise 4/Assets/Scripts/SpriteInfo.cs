using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteInfo : MonoBehaviour
{
    [SerializeField] float raidus = 1f;

    public float Radius
    {
        get { return Radius; }
    }
    [SerializeField] Vector2 ractSize = Vector2.one;


    // Properties for min/max
    [SerializeField] SpriteRenderer renderer;
    bool isColliding = false;
    
    public bool IsColliding
    {
        set { isColliding = value; }
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
