using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class Human : MonoBehaviour
{
    public static int score = 0;

    void Start()
    {
        gameObject.tag = "Enemy";
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("WOOOOOAHHH");
        
        if (!other.CompareTag("Player"))
        {
            return;  // Ignore anything that isn't the Player
        }

        Debug.Log("Player hit a Human!");
    }
}