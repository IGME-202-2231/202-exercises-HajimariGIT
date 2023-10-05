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
        DestroyAnimal();
        for(int i = 0; i< 100; ++i)
        {
            spawnedAnimals.Add(SpawnCreature());


            //do random
            spawnedAnimals[i].color = Random.ColorHSV(0f, 1f, 1f, 1f, 1f, 1f);

            //set position 
            Vector2 spawnpos;
            spawnpos.x = Random.Range(-4f, 4f);
            spawnpos.y = Random.Range(-2f, 2f);

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

    float Gaussian(float mean, float std)
    {
        return 1f;
    }
}
