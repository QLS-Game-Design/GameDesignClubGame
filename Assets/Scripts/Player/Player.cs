using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player:MonoBehaviour
{
    // Start is called before the first frame update
    public int MaxHealth; // absolute maximum health: 10000
    public int Health;
    public int MaxEnergy; // absolute maximum energy: 10000
    public int Energy;
    public int WeaponEnergy; // energy used for each shot/bullet
    public float WeaponDownTime; // time between each shot
    public int MaxSpeed; // percentage max-100
    public int Speed;
    public int MaxDamage;
    public int Damage;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
public class PlayerSniper: Player{
    MaxHealth = 1000;
	MaxSpeed = 30;
	MaxEnergy = 1000;
}

public class PlayerSniperWeapon: PlayerSniper{
	MaxDamage = 700;
	Damage = 500;
	WeaponDownTime = 2;
	WeaponEnergy = 50;
}
