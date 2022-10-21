using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceShardPop : MonoBehaviour
{
    public float time;
    public int damageToGive;

    public GameObject damageBurst;
    public Transform hitPoint;
    public GameObject damageNumber;

    public GameObject popPrefab;



    // Update is called once per frame
    void Update()
    {
 
    }


    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            foreach (ContactPoint2D missileHit in other.contacts)
            {
                Vector2 hitPoint = missileHit.point;

                GameObject bullet = (GameObject)Instantiate(popPrefab, new Vector3(hitPoint.x, hitPoint.y, 0), Quaternion.identity);
                Destroy(bullet, time);
            }

            other.gameObject.GetComponent<EnemyHealthManager>().HurtEnemy(damageToGive);
            Instantiate(damageBurst, hitPoint.position, hitPoint.rotation);
            var clone = (GameObject)Instantiate(damageNumber, hitPoint.position, Quaternion.Euler(Vector3.zero));
            clone.GetComponent<FloatingNumbers>().damageNumber = damageToGive;
            Debug.Log("hit!");

        }
    }
}
