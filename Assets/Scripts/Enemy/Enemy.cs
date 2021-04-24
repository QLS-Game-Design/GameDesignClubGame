using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int startingHealth;
    private int health;
    protected bool dead;

    public GameObject projectile;
    public Transform player;

    public float speed;
    public float stoppingDistance;
    public float retreatingDistance;

    private float timeBtwShots;
    public float startTimeBtwShots;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        health = startingHealth;
        timeBtwShots = startTimeBtwShots;
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
        if (Vector2.Distance(transform.position, player.position) > stoppingDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        } else if (Vector2.Distance(transform.position, player.position) < stoppingDistance && Vector2.Distance(transform.position, player.position) > retreatingDistance)
        {
            transform.position = this.transform.position;
        } else if (Vector2.Distance(transform.position, player.position) < retreatingDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);
        }

        if (timeBtwShots <= 0)
        {
            Instantiate(projectile, transform.position, Quaternion.identity);
            timeBtwShots = startTimeBtwShots; 
        } else
        {
            timeBtwShots -= Time.deltaTime;
        }
    }
}
