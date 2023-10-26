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
    private float totalCamheight;
    int test;
    private float totalCamwidth;


    public bool useGravity = true;
    void Start()
    {
        position = transform.position;
        totalCamheight = 2f * Camera.main.orthographicSize;
        totalCamwidth = totalCamheight * Camera.main.aspect;
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



        if (position.y > totalCamheight / 2f)
        {
            velocity.y *= -1f;
        }
        else if (position.y < -totalCamheight / 2f)
        {
            velocity.y *= -1f;
        }

        if (position.x > totalCamwidth / 2f)
        {
            velocity.x *= -1f;
        }
        else if (position.x < -totalCamwidth / 2f)
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
