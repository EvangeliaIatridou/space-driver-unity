using System.Diagnostics;
using System;
using UnityEngine;
using UnityEngine.UI;
//using static System.Net.Mime.MediaTypeNames;
using System.Collections;
using Image = UnityEngine.UI.Image;
using Random = UnityEngine.Random;
using Debug = UnityEngine.Debug;

//namespace Reward
//{
public class RewardProvider : MonoBehaviour
{
    public Image catImageUI;
    public Sprite[] catSprites; // Assign 7 cat sprites in Inspector
    public static RewardProvider Instance;

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
    }
    /*
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject); // Prevent duplicate managers
        }
    }
*/
    public void ShowRandomCat()
        {
            if (catSprites.Length == 0 || catImageUI == null)
            {
                Debug.LogWarning("Missing cat sprites or image UI!");
                return;
            }

            int index = Random.Range(0, catSprites.Length);
            catImageUI.sprite = catSprites[index];
            catImageUI.gameObject.SetActive(true);
            Debug.Log("Cat image displayed!");
    }

    public void ShowRandomCat(float hideAfterSeconds)
    {
            ShowRandomCat();
            StartCoroutine(HideAfterDelay(hideAfterSeconds));
            Debug.Log("Active? " + catImageUI.gameObject.activeSelf);
            Debug.Log("Sprite assigned? " + (catImageUI.sprite != null));
    }

    private IEnumerator HideAfterDelay(float seconds)
    {
            yield return new WaitForSeconds(seconds);
            catImageUI.gameObject.SetActive(false);
    }

    void Update()
    { 
           if (Input.GetKeyDown(KeyCode.C))
           {
              Debug.Log("asdasd");
              ShowRandomCat(3f);
           }
    }
}
//}

