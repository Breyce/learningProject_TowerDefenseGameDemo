using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public float startSpeed = 10f;
    public float startHealth = 100f;
    [HideInInspector]
    public float speed;
    public float health = 100;
    public int worth = 50;
    public GameObject enemyDeathEffect;

    [Header("Unity Stuff")]
    public Image healthBar;

    private bool isDead;

    private void Start()
    {
        speed = startSpeed;
    }

    public void TakeDamage(float amount)
    {
        health -= amount;
        healthBar.fillAmount = health / startHealth;

        if(health / startHealth < 0.2f) healthBar.color = Color.red;

        if(health <= 0 && !isDead)
        {
            Die();
        }
    }

    public void Slow(float pct)
    {
        speed = startSpeed * pct;
    }

    void Die()
    {
        isDead = true;

        PlayerStates.Money += worth;
        WaveSpawner.EnemyAlive--;
        Destroy(gameObject);
        Destroy(Instantiate(enemyDeathEffect, transform.position, Quaternion.identity),5f);
    }
}
