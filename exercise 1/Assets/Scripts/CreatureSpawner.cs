using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureSpawner : MonoBehaviour
{
    //Gameobject for prefab
    [SerializeField] GameObject creaturePrefab;
    
    //the three spawn locations that the objects will be using
    [SerializeField] Vector3 spawnPositionOne = new Vector3();
    [SerializeField] Vector3 spawnPositionTwo = new Vector3();
    [SerializeField] Vector3 spawnPositionThree = new Vector3();


    // Start is called before the first frame update
    void Start()
    {
       //Instantiate all creatures at their spawn points
        Instantiate(creaturePrefab,spawnPositionOne,Quaternion.identity);
        Instantiate(creaturePrefab, spawnPositionTwo, Quaternion.identity);
        Instantiate(creaturePrefab, spawnPositionThree, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
         
    }
}

