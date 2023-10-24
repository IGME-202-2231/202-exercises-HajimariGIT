using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsObject : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector3 Direction;
    public  Vector3 velocity;
    public  Vector3 position;
    public Vector3 Acelleration = Vector3.zero;
    float mass = 1.0f;
    float maxSpeed = 10f;

    bool useGravity = true;
    void Start()
    {
        position = transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        if (useGravity)
        {
            ApplyGrav(Vector3.down * 9.8f);
        }
        velocity += Acelleration * Time.deltaTime;
        velocity = Vector3.ClampMagnitude(velocity, maxSpeed);
        Direction = velocity.normalized;
        Acelleration = Vector3.zero;

        


    }

   

    public void Apply(Vector3 force)
    {
        Acelleration += force / mass;
    }

    public void ApplyGrav(Vector3 force)
    {
        Acelleration += force;
    }
}
