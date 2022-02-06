using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{

    MusicPlayer instance;

    void Awake()
    {
        ManageSingleton();
    }

    private void ManageSingleton()
    {
        int numMusicPlayers = FindObjectsOfType<MusicPlayer>().Length;
        if (numMusicPlayers > 1)
            Destroy(gameObject);
        else
            DontDestroyOnLoad(gameObject);
    }
}
