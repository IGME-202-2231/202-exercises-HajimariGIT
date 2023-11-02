using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class fleer : agent
{
    public GameObject target;




    // Start is called before the first frame update
    void Start()
    {

    }




    protected override void CalcSteeringForce()
    {
        PhysicsObject.ApplyForce(Flee(target));
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;
    }

  
}
