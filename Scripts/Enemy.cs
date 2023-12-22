using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float startSpeed = 10f;
    [HideInInspector]
    public float speed;
    public float health = 100;
    public int worth = 50;
    public GameObject enemyDeathEffect;

    private void Start()
    {
        speed = startSpeed;
    }

    public void TakeDamage(float amount)
    {
        health -= amount;
        if(health <= 0)
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
        PlayerStates.Money += worth;
        Destroy(gameObject);
        Destroy(Instantiate(enemyDeathEffect, transform.position, Quaternion.identity),5f);
    }
}
