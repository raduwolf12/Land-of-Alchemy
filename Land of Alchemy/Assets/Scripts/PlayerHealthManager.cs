﻿using UnityEngine;
using System.Collections;

public class PlayerHealthManager : MonoBehaviour {

    public int playerMaxHealth;
    public int playerCurrentHealth;

	// Use this for initialization
	void Start () {
        playerCurrentHealth = playerMaxHealth;
          
	}
	
	// Update is called once per frame
	void Update () {

        if (playerCurrentHealth <= 0)
        {
            gameObject.SetActive(false);
        }
	
  	}

    public void HurtPlayer(int damageToGive)
    {
        playerCurrentHealth -= damageToGive;
    }

    public void SetMaxHealth()
    {
        playerCurrentHealth = playerMaxHealth;
    }

}
