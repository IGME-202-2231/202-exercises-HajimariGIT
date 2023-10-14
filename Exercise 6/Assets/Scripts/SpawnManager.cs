using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : Singleton<SpawnManager>
{

    [SerializeField] SpriteRenderer animalPrefab;

    [SerializeField] List<Sprite> animalImages = new List<Sprite>();

    List<SpriteRenderer> spawnedAnimals = new List<SpriteRenderer> ();

    public float std;





    // (Optional) Prevent non-singleton constructor use.
    protected SpawnManager() { }

    // Start is called before the first frame update
    void Start()
    {
        Spawn();
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    //makes animalPrefab 
    public  SpriteRenderer SpawnCreature()
    {
        return Instantiate(animalPrefab); 
    }

    /// <summary>
    /// spawns random animals
    /// </summary>
    public void Spawn()
    {
        //while any number between 0-50
        int numberAnimals = Random.Range(0, 50);
        //destroy previous
        DestroyAnimal();
        //spawn said number from 0-50
        for(int i = 0; i< numberAnimals; ++i)
        {
            spawnedAnimals.Add(SpawnCreature());


            //do random color
            spawnedAnimals[i].color = Random.ColorHSV(0f, 1f, 1f, 1f, 1f, 1f);

            //set position 
            Vector2 spawnpos;
            spawnpos.x = Gaussian(.5f, 1f);
            spawnpos.y = Gaussian(-.5f,1f);

            //transforms the position
            spawnedAnimals[i].transform.position = spawnpos;

            //holds spawn random values
            float ranValue = Random.value;


            //25 % chance for elephant 
            if(ranValue < 0.25f)
            {
                spawnedAnimals[i].sprite = animalImages[1];

            }
            //20% chance for tutrle
            else if (ranValue < 0.45f)
            {
                spawnedAnimals[i].sprite = animalImages[2];
            }
            //15% chance for snail
            else if (ranValue < 0.60f)
            {
                spawnedAnimals[i].sprite = animalImages[3];
            }
            //10% chance for ocotopus
            else if (ranValue < 0.70f)
            {
                spawnedAnimals[i].sprite = animalImages[4];
            }
            //30% chance for kangaroo
            else
            {
                spawnedAnimals[i].sprite = animalImages[0];
            }




        }
    }

    /// <summary>
    /// Destroys animals in list
    /// </summary>

    public void DestroyAnimal()
    {
        //destroyes each animal in the list
        foreach(SpriteRenderer animal in spawnedAnimals)
        {
            Destroy(animal.gameObject);
        }

        spawnedAnimals.Clear();

    }
    /// <summary>
    /// Gaussian distrubution
    /// </summary>
    /// <param name="mean"></param>
    /// <param name="stdDev"></param>
    /// <returns></returns>
    private float Gaussian(float mean, float stdDev)
    {
        float val1 = Random.Range(0f, 1f);
        float val2 = Random.Range(0f, 1f);

        float gaussValue =
        Mathf.Sqrt(-2.0f * Mathf.Log(val1)) *
        Mathf.Sin(2.0f * Mathf.PI * val2);

        return mean + stdDev * gaussValue;
    }


}
