﻿using UnityEngine;
using System.Collections;

public class EnemyHealthManager : MonoBehaviour {

    public int MaxHealth;
    public int CurrentHealth;

    // Use this for initialization
    void Start()
    {
       CurrentHealth =MaxHealth;

    }

    // Update is called once per frame
    void Update()
    {

        if (CurrentHealth <= 0)
        {
            //gameObject.SetActive(false);
            Destroy(gameObject);

        }

    }

    public void HurtEnemy(int damageToGive)
    {
        CurrentHealth -= damageToGive;
    }

    public void SetMaxHealth()
    {
        CurrentHealth = MaxHealth;
    }

}