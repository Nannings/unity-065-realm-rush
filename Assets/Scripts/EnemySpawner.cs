using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour
{
    [Range(0.1f, 120f)]
    [SerializeField] float secondsBetweenSpawn = 2f;
    [SerializeField] EnemyMovement enemyPrefab;
    [SerializeField] Text scoreText;
    int score;

    private void Start()
    {
        StartCoroutine(RepeatedlySpawnEnemies());
        scoreText.text = score.ToString();
    }

    IEnumerator RepeatedlySpawnEnemies()
    {
        while (true)
        {
            Instantiate(enemyPrefab, transform.position, Quaternion.identity, transform);
            score += 10;
            scoreText.text = score.ToString();
            yield return new WaitForSeconds(secondsBetweenSpawn);
        }
    }
}
