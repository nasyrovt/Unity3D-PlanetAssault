using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Enemy Preferences")]
    [SerializeField] int maxHealth = 100;

    [Header("Visual Effects")]
    [SerializeField] GameObject damageVFX;
    [SerializeField] GameObject deathFX;
    [SerializeField] int scorePerHit = 15;
    ScoreBoard scoreBoard;
    GameObject spawnAtRuntime;
    int currentHealth;
    void Start()
    {
        currentHealth = maxHealth;
        scoreBoard = FindObjectOfType<ScoreBoard>();
        Rigidbody rb = gameObject.AddComponent<Rigidbody>();
        spawnAtRuntime = GameObject.FindWithTag("SpawnAtRuntime");
        rb.useGravity = false;
    }

    void Update()
    {
        Death();
    }

    private void OnCollisionEnter(Collision other)
    {
        GameObject vfx = Instantiate(deathFX, transform.position, Quaternion.identity);
        vfx.transform.parent = spawnAtRuntime.transform;
        Death();

    }
    void OnParticleCollision(GameObject other)
    {
        GameObject vfx = Instantiate(damageVFX, transform.position, Quaternion.identity);
        vfx.transform.parent = spawnAtRuntime.transform;
        currentHealth -= 10;
        scoreBoard.IncreaseScore(scorePerHit);
    }

    void Death()
    {
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
