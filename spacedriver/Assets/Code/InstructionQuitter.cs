using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InstructionQuitter : MonoBehaviour
{
    public void GoBack()
    {
        SceneManager.LoadSceneAsync(0);
    }
}
