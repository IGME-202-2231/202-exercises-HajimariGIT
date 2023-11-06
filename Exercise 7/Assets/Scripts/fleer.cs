using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class fleer : agent
{
    public GameObject target;
    public bool hit;




    // Start is called before the first frame update
    void Start()
    {

    }




    protected override void CalcSteeringForce()
    {
      if(hit == false)
      {
            Vector3 distaceSeek = target.transform.position;
            Vector3 agentPosition = transform.position;
            float total = (distaceSeek.magnitude - agentPosition.magnitude);
            float touch = 1.0f * 1.0f;

            if(total < touch)
            {
                hit = true;
            }

      }

        PhysicsObject.ApplyForce(Flee(target));
      


    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;
    }

  
}
