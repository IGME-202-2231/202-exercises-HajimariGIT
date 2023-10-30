using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsObject : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector3 Direction;
    public  Vector3 Velocity;
    public  Vector3 Position;
    public Vector3 Acelleration = Vector3.zero;
    public float mass;
    public float maxSpeed;
    private float totalCamheight;
    int test;
    private float totalCamwidth;
    public bool useGravity;
    public bool useFriction;
    public float gravity;
    public float friction;


    
    void Start()
    {
        Position = transform.position;
        totalCamheight = 2f * Camera.main.orthographicSize;
        totalCamwidth = totalCamheight * Camera.main.aspect;
        gravity = .98f;
    }

    // Update is called once per frame
    void Update()
    {

        if (useGravity)
        {
            ApplyGrav(Vector3.down * gravity);
        }
        if(useFriction)
        {
            ApplyFriction(friction);
        }
        Velocity += Acelleration * Time.deltaTime;
        Velocity = Vector3.ClampMagnitude(Velocity, maxSpeed);
        Position += Velocity * Time.deltaTime;
        Direction = Velocity.normalized;
        transform.position = Position;
        Acelleration = Vector3.zero;



        if (Position.y > totalCamheight / 2f)
        {
            Velocity.y *= -1f;
        }
        else if (Position.y < -totalCamheight / 2f)
        {
            Velocity.y *= -1f;
        }

        if (Position.x > totalCamwidth / 2f)
        {
            Velocity.x *= -1f;
        }
        else if (Position.x < -totalCamwidth / 2f)
        {
            Velocity.x *= -1f;
        }







    }



    public void ApplyForce(Vector3 force)
    {
        Acelleration += force / mass;
    }

    public void ApplyGrav(Vector3 force)
    {
        Acelleration += force;
    }

    void ApplyFriction(float coeff)
    {
        Vector3 friction = Velocity * -1;
        friction.Normalize();
        friction = friction * coeff;
        ApplyForce(friction);
    }

}
