﻿using UnityEngine;
using System.Collections;

public class HurtEnemy : MonoBehaviour {



    public int damageToGive;

    public GameObject damageBurst;
    public Transform hitPoint;
    public GameObject damageNumber;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    private void OnTriggerEnter2D (Collider2D other)
    {
        if (other.gameObject.tag ==  "Enemy")
        {
            //Destroy(other.gameObject);
            other.gameObject.GetComponent<EnemyHealthManager>().HurtEnemy(damageToGive);
            Instantiate(damageBurst, hitPoint.position, hitPoint.rotation);
            var clone = (GameObject)Instantiate(damageNumber, hitPoint.position, Quaternion.Euler(Vector3.zero));
            clone.GetComponent<FloatingNumbers>().damageNumber= damageToGive;
        }

    }
}
