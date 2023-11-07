using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class wanderer : agent
{
    // Start is called before the first frame update
    public float time = 1f;
    public float radius = 1f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected override void CalcSteeringForce()
    {
        PhysicsObject.ApplyForce(Wander(time,radius));
    }



}
