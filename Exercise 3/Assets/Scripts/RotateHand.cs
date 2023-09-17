using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateHand : MonoBehaviour
{
    // Start is called before the first frame update
    public float turnAmount = 6f;
    [SerializeField] bool useDeltaTime;
    private float control;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //id delta time is on
       if(useDeltaTime)
       {
            //multiply turnamount by time.delta time
            control -= turnAmount * Time.deltaTime;
            //plug the value in a quaternion
            Quaternion roundAbout = Quaternion.Euler(0f, 0f, control);
            //apply it
            transform.rotation = roundAbout;
       }
      else
      {
            //decrease the turnamount not dependent on delta time
            turnAmount--;
            //apply to Quaternion 
            Quaternion roundAbout = Quaternion.Euler(0f, 0f, turnAmount);
            //apply the transform 
            transform.rotation = roundAbout;
            

      }
       
    }
}
