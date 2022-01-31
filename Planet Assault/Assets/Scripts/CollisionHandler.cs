using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float reloadTime = 1f;
    [SerializeField] ParticleSystem[] explosionsVFX;

    private void OnTriggerEnter(Collider other)
    {
        StartCrashSequence();
    }

    private void StartCrashSequence()
    {
        foreach (var particleSystem in explosionsVFX)
        {
            particleSystem.Play();
        }
        DisableComponentsIfDie();
        //SFX        
        StartCoroutine(ReloadLevel(reloadTime));
    }

    void DisableComponentsIfDie()
    {
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<PlayerControls>().enabled = false;
        GetComponent<BoxCollider>().enabled = false;
    }

    IEnumerator ReloadLevel(float reloadTime)
    {
        yield return new WaitForSeconds(reloadTime);
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
}
