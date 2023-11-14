using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class agent : MonoBehaviour
{
    [SerializeField] protected PhysicsObject PhysicsObject; 
    public float MaxForce;
    public Vector3 myPos;
    public Vector3 currentVelocity;
    public float maxSpeed;
    public  AgentManager manager;
    public float seperateRange=1f;





    // Start is called before the first frame update
    void Start()
    {
        maxSpeed = PhysicsObject.max;
    }

    // Update is called once per frame
   protected void Update()
    {

        CalcSteeringForce();
       



    }




    protected abstract void CalcSteeringForce();

    protected Vector3 Seek(Vector3 targetPos)
    {
        // Calculate desired velocity
        Vector3 desiredVelocity = targetPos - transform.position;

        // Set desired = max speed
        desiredVelocity = desiredVelocity.normalized * PhysicsObject.maxSpeed;

        // Calculate seek steering force
        Vector3 seekingForce = desiredVelocity - PhysicsObject.Velocity;
     


        

        // Return seek steering force
        return seekingForce;
    }

    protected Vector3 Seek(GameObject target)
    {
        // Call the other version of Seek 
        //   which returns the seeking steering force
        //  and then return that returned vector. 

       
        return Seek(target.transform.position); 
    }

    protected Vector3 Flee(Vector3 targetPos)
    {
        // Calculate desired velocity
        Vector3 desiredVelocity = transform.position - targetPos;

        // Set desired = max speed
        desiredVelocity = desiredVelocity.normalized * PhysicsObject.maxSpeed;

        // Calculate seek steering force
        Vector3 seekingForce = desiredVelocity - PhysicsObject.Velocity;

        // Return seek steering force
        return seekingForce;
    }

    protected Vector3 Flee(GameObject target)
    {
        // Call the other version of Seek 
        //   which returns the seeking steering force
        //  and then return that returned vector. 

       
      
        return Flee(target.transform.position);
    }

    protected Vector3 Flee(agent target)
    {
        // Call the other version of Seek 
        //   which returns the seeking steering force
        //  and then return that returned vector. 



        return Flee(target.transform.position);
    }


    protected Vector3 Wander(float time,float radius)
    {
        Vector3 targetPos = CalcFuturePosition(time);
        float ranAngle = Random.Range(0, Mathf.PI * 2f);
        targetPos.x += Mathf.Cos(ranAngle) * radius;
        targetPos.y += Mathf.Sin(ranAngle) * radius;
        return Seek(targetPos);

    }

    public Vector3 CalcFuturePosition(float time)
    {
        return PhysicsObject.Velocity * time + transform.position;
    }
     

    protected Vector3 StayInBounds()
    {
       /* if (transform.position.y > PhysicsObject.totalCamheight / 2f)
        {
           Velocity.y *= -1f;
        }
       else if (transform.position.y < -PhysicsObject.totalCamheight / 2f)
       {
           Velocity.y *= -1f;
       }

       if (transform.position.x > PhysicsObject.totalCamwidth / 2f)
       {
           Velocity.x *= -1f;
       }
       else if (transform.position.x > -PhysicsObject.totalCamwidth / 2f)
       {
           Velocity.x *= -1f;
       }*/



       if(transform.position.y >= PhysicsObject.totalCamheight /2 - 2.5|| transform.position.y <= -PhysicsObject.totalCamheight /2 +2.5
            || transform.position.x >= PhysicsObject.totalCamwidth /2 -2.3 || transform.position.x <= -PhysicsObject.totalCamwidth /2 +2.3)
       {
            return Seek(Vector3.zero);
       }
       else
        {
            return Vector3.zero;

        }
       



    }



    protected Vector3 Seperate()
    {
        Vector3 steeringforce = Vector3.zero;
        foreach(agent agent in manager.agents)
        {
            float dis = Vector3.Distance(transform.position, agent.transform.position);
            if (Mathf.Epsilon < dis)
                steeringforce += Flee(agent) * (seperateRange / dis);//0.3

        }

        return steeringforce;
    }




}
