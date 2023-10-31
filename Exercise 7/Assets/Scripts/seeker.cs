using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class seeker : agent
{
    public GameObject target;




    // Start is called before the first frame update
    void Start()
    {
        
    }

   


    protected override void CalcSteeringForce()
    {
        PhysicsObject.ApplyForce(Seek(target));
    }
}
