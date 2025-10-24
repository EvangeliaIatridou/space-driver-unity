using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using Speed;
using Debug = UnityEngine.Debug;

public class pedestrianSpawner : MonoBehaviour
{

    public GameObject Player;
    public GameObject Human;
    public GameObject Cat;

    private float samplePos = 20f;
    private float spawnPos = -20f;

    private bool canSpawn = true;

    public int score = 0;

    void Awake()
    {
        if (Cat == null)
        {
            Cat = GameObject.Find("Cat"); // Finds it at runtime
            //Debug.Log("Cat auto-assigned: " + Cat);
        }
    }

    void Start()
    {
        if (Cat == null)
        {
            Debug.LogError("Error: Cat reference is missing in PedestrianSpawner!");
        }
        else
        {
            Debug.Log("Start: Cat is assigned correctly.");
        }
        InvokeRepeating(nameof(SpawnPedestrian), 2f, 2f);
    }


    void SpawnPedestrian()
    {

        System.Random rnd = new System.Random();
        int random = rnd.Next(0, 2);

        if (random == 0 || random == 1) {
            int random1 = rnd.Next(0, 9) - 4;
            int random2 = rnd.Next(0, 9) - 4;

            do
            {
                random2 = rnd.Next(-4, 5);
            } while (random1 == random2);

            GameObject tempCat = Instantiate(Cat, new Vector3(spawnPos+2, 0.42f, random1), Quaternion.identity);
            GameObject tempHuman = Instantiate(Human, new Vector3(spawnPos, 0, random2), Quaternion.identity);

            tempHuman.tag = "Enemy";

            tempCat.transform.localScale = new Vector3(0.2f, 0.3f, 0.3f); //changes size
            tempHuman.transform.localScale = new Vector3(1.5f, 2f, 1f); //changes size
            
            tempCat.AddComponent<AttachToFloor>();
            tempHuman.AddComponent<AttachToFloor>();



            spawnPos -= 17f;
        }
    }

}



