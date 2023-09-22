using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovementController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Vector3 objectPosition = Vector3.zero;
    [SerializeField] float speed = 1.0f;
    [SerializeField] Vector3 direction = Vector3.right;
    [SerializeField] Vector3 velocity = Vector3.zero;
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
      if(directionInput != null)
        {
            direction = directionInput.normalized;
            if(direction != Vector3.zero)
            {
                transform.rotation = Quaternion.LookRotation(Vector3.back, direction);
            }
        }
        


    }


}
