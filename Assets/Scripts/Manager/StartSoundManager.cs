using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartSoundManager : MonoBehaviour
{
    public string soundsName;
    public AudioManager audioManager;

    public void Awake()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    public void OnSceneLoaded(Scene scenename, LoadSceneMode mode)
    {
        Debug.Log("SoundStart");

        AudioManager audioManager = FindAnyObjectByType<AudioManager>();
        audioManager.Play(soundsName);
    }

    public void PlaySound(string SoundNameToPlay)
    {
        AudioManager audioManager = FindAnyObjectByType<AudioManager>();
        audioManager.Play(SoundNameToPlay);
    }
}
