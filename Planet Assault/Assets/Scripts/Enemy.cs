using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Enemy Preferences")]
    [SerializeField] int maxHealth = 100;

    [SerializeField] GameObject damageVFX;
    [SerializeField] Transform parent;
    [SerializeField] int scorePerHit;
    ScoreBoard scoreBoard;
    int currentHealth;
    void Start()
    {
        currentHealth = maxHealth;
        scoreBoard = FindObjectOfType<ScoreBoard>();
    }

    void Update()
    {
        Death();
    }

    void OnParticleCollision(GameObject other)
    {
        GameObject vfx = Instantiate(damageVFX, transform.position, Quaternion.identity);
        vfx.transform.parent = parent;
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
