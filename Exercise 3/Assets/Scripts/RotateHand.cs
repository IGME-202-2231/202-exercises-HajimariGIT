using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateHand : MonoBehaviour
{
    // Start is called before the first frame update
    public float turnAmount = 6f;
    [SerializeField] bool useDeltaTime;
    float control;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if(useDeltaTime)
       {
            control -= turnAmount * Time.deltaTime;
            Quaternion roundAbout = Quaternion.Euler(0f, 0f, control);
            transform.rotation = roundAbout;
       }
      else
      {
            turnAmount--;
            Quaternion roundAbout = Quaternion.Euler(0f, 0f, turnAmount);
            transform.rotation = roundAbout;
            

      }
       
    }
}
