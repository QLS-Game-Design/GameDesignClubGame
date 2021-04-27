using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player:MonoBehaviour
{
    // Start is called before the first frame update
    public float MaxHealth = 1000; // absolute maximum health: 10000
    public float Health;
    public float MaxEnergy; // absolute maximum energy: 10000
    public float Energy;
    public float WeaponEnergy; // energy used for each shot/bullet
    public float WeaponDownTime; // time between each shot
    public float MaxSpeed; // percentage max-100
    public float Speed = 1f; // Speed will have to be less than 1 otherwise things will go too fast
    public float MaxDamage;
    public float Damage;
    public float theta;
    public bool isDead;
    public Text text;

    // Vector2 mousePos;
    // public RigidBody2D rb;
    // public Keycode W;
    // public Keycode A;
    // public Keycode S;
    // public Keycode D;

    void Start()
    {
        Health = MaxHealth;
        text.text = "Health " + Health.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        // W = 0,1
        // S = 0,-1
        // A = -1,0
        // D = 1,0
        if (Health>0)
        {
            if (Input.GetKey(KeyCode.W))
            {
                transform.Translate(new Vector2(0, 0.1f * Speed));
            }
            if (Input.GetKey(KeyCode.S))
            {
                transform.Translate(new Vector2(0, -0.1f * Speed));
            }
            if (Input.GetKey(KeyCode.A))
            {
                transform.Translate(new Vector2(-0.1f * Speed, 0));
                GetComponent<SpriteRenderer>().flipX = true;
            }
            if (Input.GetKey(KeyCode.D))
            {
                transform.Translate(new Vector2(0.1f * Speed, 0));
                GetComponent<SpriteRenderer>().flipX = false;
            }
        } else
        {
            SceneManager.LoadScene(0);
        }


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Health-=collision.gameObject.GetComponent<Enemy>().damage;
            text.text = "Health " + Health.ToString();
            Debug.Log(Health);
        }
    }
}
// public class PlayerSniper{
//     public float MaxHealth = 1000 ; // absolute maximum health: 10000
//     public float Health = 1000;
//     public float MaxEnergy = 1000; // absolute maximum energy: 10000
//     public float Energy = 1000;
//     public float WeaponEnergy = 1000; // energy used for each shot/bullet
//     public float WeaponDownTime = 1000; // time between each shot
//     public float MaxSpeed = 1000; // percentage max-100
//     public float Speed = 1000;
//     public float MaxDamage = 1000;
//     public float Damage = 1000;
//     playerPos = transform.position;
    
// }

// public class PlayerSniperWeapon: PlayerSniper{
//     MaxDamage = 700;
//     Damage = 500;
//     WeaponDownTime = 2;
//     WeaponEnergy = 50;
// }
