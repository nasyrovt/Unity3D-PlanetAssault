using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Volcano : MonoBehaviour
{
    [SerializeField] GameObject[] volcanoParticles;
    GameObject spawnAtRuntime;
    void Start()
    {
        spawnAtRuntime = GameObject.FindWithTag("SpawnAtRuntime");
        InvokeRepeating("SpawnParticle", 0f, .08f);
    }

    private void SpawnParticle()
    {
        Vector3 spawnPos = GetComponent<Transform>().position;
        float xRandom = UnityEngine.Random.Range(-25.0f, 25.0f);
        float zRandom = UnityEngine.Random.Range(-25.0f, 25.0f);
        Vector3 offsetPos = new Vector3(xRandom, 20, zRandom);
        GameObject volcanoParticle = Instantiate(volcanoParticles[UnityEngine.Random.Range(0, volcanoParticles.Length)], spawnPos + offsetPos, new Quaternion(1, 1, 1, 0));
        volcanoParticle.transform.parent = spawnAtRuntime.transform;
    }
}
