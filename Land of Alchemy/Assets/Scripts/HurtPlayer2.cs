using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtPlayer2 : MonoBehaviour
{

    public int damageToGive;

    public GameObject damageBurst;
    public Transform hitPoint;
    public GameObject damageNumber;



    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D other)
    {

        if (other.gameObject.name == "player")
        {
            other.gameObject.GetComponent<PlayerHealthManager>().HurtPlayer(damageToGive);
            Instantiate(damageBurst, hitPoint.position, hitPoint.rotation);
            var clone = (GameObject)Instantiate(damageNumber, hitPoint.position, Quaternion.Euler(Vector3.zero));
            clone.GetComponent<FloatingNumbers>().damageNumber = damageToGive;
        }

    }


}

