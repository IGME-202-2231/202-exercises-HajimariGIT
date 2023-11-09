using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class wanderer : agent
{
    // Start is called before the first frame update
    public float time = 0.48f;
    public float radius = 1.8f;


    protected override void CalcSteeringForce()
    {
        PhysicsObject.ApplyForce(Wander(time,radius));
        PhysicsObject.ApplyForce(StayInBounds());
    }



}
