using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class ClockNumbers : MonoBehaviour

{
    [SerializeField] TextMesh number;
    [SerializeField] List<TextMesh> numbers = new List<TextMesh>();
    Quaternion control;
    Vector3 spawnOne;
    int stop = 360;
    int counter;
    int start = 3;
    bool contain = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       while( stop != 0 ) 
       {
          if(start <= 12)
          {
                number.text = start.ToString();

          }
            float x = Mathf.Cos(stop * Mathf.PI/180) * 3;
            float y = Mathf.Sin(stop * Mathf.PI/180) * 3;
            spawnOne.x = x;
            spawnOne.y = y;
            Instantiate(number, spawnOne,Quaternion.identity);
            numbers.Add(number);
            stop = stop - 30;
            counter++;
            start= start + 1;
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
