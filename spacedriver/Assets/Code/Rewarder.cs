using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Debug = UnityEngine.Debug;
using Image = UnityEngine.UI.Image;
using Random = UnityEngine.Random;

public class Rewarder : MonoBehaviour
{
    public Image catImageUI;
    public Sprite[] catSprites;
    // Start is called before the first frame update
    void Start()
    {
        if (catImageUI == null)
        {
            catImageUI = GameObject.Find("CatImageUI")?.GetComponent<Image>();
            if (catImageUI == null)
            {
                Debug.LogWarning("Cat image UI not found after scene load.");
            }
        }
        int index = Random.Range(0, catSprites.Length);
        catImageUI.sprite = catSprites[index];
    }
    public void GoBack()
    {
        SceneManager.LoadSceneAsync(0);
    }

    public void ShowCat()
    {
        if (catSprites.Length == 0 || catImageUI == null)
        {
            Debug.LogWarning("Missing cat sprites or image UI!");
            return;
        }
        int index = Random.Range(0, catSprites.Length);
        catImageUI.sprite = catSprites[index];

    }
}
