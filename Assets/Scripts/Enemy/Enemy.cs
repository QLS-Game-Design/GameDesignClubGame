using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float startingHealth;
    private float health;
    public float damage;
    public float speed;

    public Transform player;
    
    public event System.Action OnDeath;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        health = startingHealth;
    }

    void OnCollisionEnter2D(Collision2D c)
    {

        // If the object we hit is the enemy
        if (c.gameObject.tag != "Enemy")
        {
            Debug.Log(c.gameObject.tag);
        }
        if (c.gameObject.tag == "Player")
        {
            // we can add bounce back later
            //Debug.Log("collided with player");
            //Vector2 dir = c.contacts[0].point - new Vector2(transform.position.x, transform.position.y);
            //dir = -dir.normalized;
            //transform.Translate(dir);
        } else if (c.gameObject.tag == "Bullet")
        {
            TakeDamage(1);
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    protected void Die()
    {
        // we can add more death effects here
        if (OnDeath != null)
        {
            OnDeath();
        }
        GameObject.Destroy(gameObject);

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
    }
}
