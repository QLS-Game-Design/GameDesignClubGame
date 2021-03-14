using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int startingHealth;
    private int health;
    protected bool dead;

    public Transform player;
    public int speed = 4;
    public int detectRange = 5;

    // Start is called before the first frame update
    void Start()
    {
        health = startingHealth;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0 && !dead)
        {
            Die();
        }
    }

    protected void Die()
    {
        dead = true;
        // we can add more death effects here
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = player.position - transform.position;

        // Normalize it so that it's a unit direction vector
        dir.Normalize();

        // Move ourselves in that direction
        transform.position += dir * speed * Time.deltaTime;
    }
}
