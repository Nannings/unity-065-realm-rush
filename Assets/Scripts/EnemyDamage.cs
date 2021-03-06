﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] int hitPoints = 10;
    [SerializeField] ParticleSystem hitParticlePrefab;
    [SerializeField] ParticleSystem deadParticlePrefab;
    [SerializeField] AudioClip enemyDeathSFX;

    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();

        if (hitPoints <= 0)
        {
            KillEnemy();
        }
    }

    void ProcessHit()
    {
        hitPoints = hitPoints - 1;
        hitParticlePrefab.Play();
    }

    private void KillEnemy()
    {
        AudioSource.PlayClipAtPoint(enemyDeathSFX, Camera.main.transform.position);

        Instantiate(deadParticlePrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
