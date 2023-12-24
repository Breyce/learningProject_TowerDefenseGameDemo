using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public static int EnemyAlive = 0;
    public Wave[] waves;
    public GameManager gameManager;

    //public Transform enemyPrefab;
    public Transform spawnPoint;
    public TextMeshProUGUI waveCountDownText;
    public TextMeshProUGUI waveCountText;
    public TextMeshProUGUI moneyLeft;
    public float timeBetweenWaves = 2f;
    public float timeBetweenEnemy = .5f;

    private float countdown = 2f;
    private int waveIndex = 0;
    private int waveCount = 0;


    private void Update()
    {
        waveCountText.text = "Wave:\n" + waveCount;
        moneyLeft.text = "Money Left:\n" + PlayerStates.Money;

        if(EnemyAlive > 0)
        {
            return;
        }


        if(countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
            waveCount++;
            return;
        }

        if (waveIndex == waves.Length)
        {
            Debug.Log("finish");
            gameManager.WinLevel();
            this.enabled = false;
        }

        countdown -= Time.deltaTime;
        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);
        waveCountDownText.text = "Next Wave:\n" + string.Format("{0:00.00}",countdown);
    }

    IEnumerator SpawnWave()
    {
        //Debug.Log("Wave Incomming");
        PlayerStates.Rounds++;
        Wave wave = waves[waveIndex];
        EnemyAlive = wave.count;

        for (int i = 0; i < wave.count; i++)
        {
            SpawnEnemy(wave.enemy);
            yield return new WaitForSeconds(1 / wave.rate);
        }

        waveIndex++;
    }

    void SpawnEnemy(GameObject enemy)
    {
        Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
    }
}
