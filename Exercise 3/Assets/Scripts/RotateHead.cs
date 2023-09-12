using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateHead : MonoBehaviour
{
    // Start is called before the first frame update
    float an = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        an -= 200;
        Quaternion roundabout = Quaternion.Euler(0f,0f,an);

        transform.rotation = roundabout;
    }
}
