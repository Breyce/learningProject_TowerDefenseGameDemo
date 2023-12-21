using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public Transform enemyPrefab;
    public Transform spawnPoint;
    public TextMeshProUGUI waveCountDownText;
    public float timeBetweenWaves = 5f;
    public float timeBetweenEnemy = .5f;

    private float countdown = 2f;
    private int waveIndex = 0;


    private void Update()
    {
        if(countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
        }

        countdown -= Time.deltaTime;

        waveCountDownText.text = "Time: " + Mathf.Floor(countdown).ToString();
    }

    IEnumerator SpawnWave()
    {
        //Debug.Log("Wave Incomming");
        waveIndex++;

        for (int i = 0; i < waveIndex; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(timeBetweenEnemy);
        }

    }

    void SpawnEnemy()
    {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
