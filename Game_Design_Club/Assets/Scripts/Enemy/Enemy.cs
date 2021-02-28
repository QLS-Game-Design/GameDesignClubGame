using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int startingHealth;
    private int health;
    protected bool dead;

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
        
    }
}
