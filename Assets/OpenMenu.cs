using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenMenu : MonoBehaviour
{
    public void KeMenu()
    {
        Debug.Log("LoadScene");
        SceneManager.LoadScene("MainMenuScene");
    }
}
