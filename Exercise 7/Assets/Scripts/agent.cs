using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public abstract class agent : MonoBehaviour
{
    [SerializeField] protected PhysicsObject PhysicsObject;
    public float MaxForce;
    public Vector3 myPos;
    public Vector3 currentVelocity;
    public float maxSpeed =10f;





    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        CalcSteeringForce();
    }




    protected abstract void CalcSteeringForce();

    public Vector3 Seek(Vector3 targetPos)
    {
        // Calculate desired velocity
        Vector3 desiredVelocity = targetPos - transform.position;

        // Set desired = max speed
        desiredVelocity = desiredVelocity.normalized * maxSpeed;

        // Calculate seek steering force
        Vector3 seekingForce = desiredVelocity - PhysicsObject.Velocity;

        // Return seek steering force
        return seekingForce;
    }

    public Vector3 Seek(GameObject target)
    {
        // Call the other version of Seek 
        //   which returns the seeking steering force
        //  and then return that returned vector. 
        return Seek(target.transform.position);
    }




}
