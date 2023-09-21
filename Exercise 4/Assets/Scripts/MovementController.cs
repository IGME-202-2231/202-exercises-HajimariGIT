using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovementController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Vector3 objectPosition = new Vector3 (0, 0, 0);
    [SerializeField] float speed = 4f;
    [SerializeField] Vector3 direction = new Vector3(1,0,0);
    [SerializeField] Vector3 velocity = new Vector3(0,0,0);
    void Start()
    {
        objectPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        SetDirection(direction);
        velocity = direction * speed * Time.deltaTime;
        objectPosition += velocity;
        transform.position = objectPosition;
        transform.rotation = Quaternion.LookRotation(Vector3.forward, direction); // for 2D rotation
        


    }


    public void SetDirection(Vector3 directionInput)
    {
        direction += directionInput;
        


    }


}
