using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class ClockNumbers : MonoBehaviour

{
    [SerializeField] TextMesh number;
    Vector3 spawnOne;
    private int stop = 360;
    private int start = 3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //outer loop to control when numbers hit 0 in the unit circle
       while( stop != 0 ) 
       {
          //create the number's text in ascending order
          if(start <= 12)
          {
                //makes the text that number
                number.text = start.ToString();

          }
            //equation to find X
            float x = Mathf.Cos(stop * Mathf.PI/180) * 3;
            //equation to find y
            float y = Mathf.Sin(stop * Mathf.PI/180) * 3;
            //store the values in the vector 3
            spawnOne.x = x;
            spawnOne.y = y;
            //instantiate the number 
            Instantiate(number, spawnOne,Quaternion.identity);
            //decrease around the unit cirle by 30
            stop = stop - 30;
            //stores number we are on currently
            start= start + 1;
            //handles the last two numbers
            if(start == 13)
            {
                number.text="1";
            }
            if(start == 14)
            {
                number.text="2";
            }


        }
      
       
    }
}
