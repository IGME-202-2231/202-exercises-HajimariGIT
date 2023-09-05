using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Week2Demo : MonoBehaviour
{

    [SerializeField]
    int health=10;

   [SerializeField] 
    string name = "Bob";

    [SerializeField]
    GameObject creaturePrefab;

    // Start is called before the first frame update
    void Start()
    {
        health = 10;
      
        //Instantiate(creaturePrefab);
    }

    // Update is called once per frame
    void Update()
    {
        ++health;

    }

    private void Awake()
    {
        
    }

    private void OnEnable()
    {
        
    }
}
