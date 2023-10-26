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
   public float mass = 1.0f;
    public float maxSpeed = 10f;

    public bool useGravity = true;
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
        position += velocity * Time.deltaTime;
        Direction = velocity.normalized;
        transform.position = position;
        Acelleration = Vector3.zero;


        if(position.y  < -4.57)
        {
            velocity.y *= -1f;
           
        }
        if (position.y > 4.53)
        {
            velocity.y *= -1f;
         
        }
        if (position.x < -9.57)
        {
            velocity.x *= -1f;
          
        }
        if (position.x > 10.48)
        {
            velocity.x *= -1f;
           
        }


       




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
