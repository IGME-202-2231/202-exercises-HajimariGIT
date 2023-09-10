using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureSpawner : MonoBehaviour
{

    [SerializeField] GameObject creaturePrefab;
    

    [SerializeField] Vector3 spawnPositionOne = new Vector3();
    [SerializeField] Vector3 spawnPositionTwo = new Vector3();
    [SerializeField] Vector3 spawnPositionThree = new Vector3();


    // Start is called before the first frame update
    void Start()
    {
        creaturePrefab = GameObject.Find("Spider");
        Instantiate(creaturePrefab,spawnPositionOne,Quaternion.identity);
        Instantiate(creaturePrefab, spawnPositionTwo, Quaternion.identity);
        Instantiate(creaturePrefab, spawnPositionThree, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

