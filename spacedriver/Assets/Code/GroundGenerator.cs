using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Speed;

public class LevelGenerator : MonoBehaviour
{
    public GameObject Tile1;
    public GameObject Tile2;
    public GameObject StartTile;

    //public float speed = 5f;
    public float speed = SharedSpeed.speed;

    private int samplePos = -8;
    private float Index = 0;

    private void Start()
    {
        
        for (int i = 0; i < 8; i++)
        {
            GameObject startTile = Instantiate(StartTile, transform);
            startTile.transform.position = new Vector3((i * 7), 0, 0);
        }
        InvokeRepeating(nameof(Update), 2f, 2f);

    }

    private void Update() //maybe change the random thing and have it be more deterministic -- looks weird with texture & too many start instances
    {
        transform.position += Vector3.right * speed * Time.deltaTime;
        System.Random rnd = new System.Random();

        if (transform.position.x >= Index)
        {
            int RandomInt1 = rnd.Next(0, 2);

            if (RandomInt1 == 0|| RandomInt1 == 1)
            {
                
                GameObject TempTile1 = Instantiate(Tile1, new Vector3(samplePos, 0, 0), Quaternion.identity, transform);
                GameObject TempTile2 = Instantiate(Tile1, new Vector3(samplePos-8, 0, 0), Quaternion.identity, transform);

            }

            int RandomInt2 = rnd.Next(0, 2);

            if (RandomInt2 == 0|| RandomInt2 == 1)
            {
              
                GameObject TempTile3 = Instantiate(Tile2, new Vector3(samplePos-16, 0, 0), Quaternion.identity, transform);
                GameObject TempTile4 = Instantiate(Tile2, new Vector3(samplePos-24, 0, 0), Quaternion.identity, transform);

            }

            samplePos = samplePos - 8;

            Index = Index + 15.95f;
        }
    }
}