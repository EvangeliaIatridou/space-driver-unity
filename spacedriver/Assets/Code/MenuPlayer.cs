using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Application = UnityEngine.Application;
using Debug = UnityEngine.Debug;
using Speed;

public class MenuPlay : MonoBehaviour
{
  
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        SharedSpeed.speed = 5f;
        
    }

    public void PlayGame() {
        SceneManager.LoadSceneAsync(1);
    }

    public void LoadInstructions() {
        SceneManager.LoadSceneAsync(2);
    }

    public void QuitGame()
    {
        PlayerPrefs.DeleteKey("SavedHS");
        SharedSpeed.speed = 5f;
        Debug.Log("quitted:(");
        Application.Quit();
        UnityEditor.EditorApplication.isPlaying = false; // Stops play mode in editor

    }
}
