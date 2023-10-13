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


    public  SpriteRenderer SpawnCreature()
    {
        return Instantiate(animalPrefab); 
    }


    public void Spawn()
    {
        int numberAnimals = Random.Range(0, 50);
        DestroyAnimal();
        for(int i = 0; i< numberAnimals; ++i)
        {
            spawnedAnimals.Add(SpawnCreature());


            //do random
            spawnedAnimals[i].color = Random.ColorHSV(0f, 1f, 1f, 1f, 1f, 1f);

            //set position 
            Vector2 spawnpos;
            spawnpos.x = Gaussian(.5f, 1f);
            spawnpos.y = Gaussian(-.5f,1f);

            spawnedAnimals[i].transform.position = spawnpos;


            float ranValue = Random.value;

            if(ranValue < 0.6f)
            {
                spawnedAnimals[i].sprite = animalImages[0];
            }
            else if(ranValue < 0.84)
            {
                spawnedAnimals[i].sprite = animalImages[2];
            }
            else
            {
                spawnedAnimals[i].sprite = animalImages[3];
            }



            if(ranValue < 0.25f)
            {
                spawnedAnimals[i].sprite = animalImages[1];

            }
            else if (ranValue < 0.45f)
            {
                spawnedAnimals[i].sprite = animalImages[2];
            }
            else if (ranValue < 0.60f)
            {
                spawnedAnimals[i].sprite = animalImages[3];
            }
            else if (ranValue < 0.70f)
            {
                spawnedAnimals[i].sprite = animalImages[4];
            }
            else
            {
                spawnedAnimals[i].sprite = animalImages[0];
            }




        }
    }

    public void DestroyAnimal()
    {
        foreach(SpriteRenderer animal in spawnedAnimals)
        {
            Destroy(animal.gameObject);
        }

        spawnedAnimals.Clear();

    }

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
