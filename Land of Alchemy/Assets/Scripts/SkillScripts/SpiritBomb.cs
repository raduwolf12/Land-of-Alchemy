using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class SpiritBomb : Ability
{
    public float distance;
    public float time;
    public GameObject prefab;
    public override void Activate(GameObject parent)
    {
        PlayerController playerController = parent.GetComponent<PlayerController>();
        Rigidbody2D rigidbody = parent.GetComponent<Rigidbody2D>();

        //Rigidbody p = Instantiate(prefab, rigidbody.position, rigidbody.rotation);
        // p.velocity = rigidbody.forward * distance;


        Vector2 worldanonymousousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector2 direction = (Vector2)((worldanonymousousePos - rigidbody.position));
        direction.Normalize();

        // Creates the bullet locally
        GameObject bullet = (GameObject)Instantiate(
                                prefab,
                                rigidbody.position + (Vector2)(direction * 0.5f),
                                Quaternion.identity);

        // Adds velocity to the bullet
        bullet.GetComponent<Rigidbody2D>().velocity = direction * distance;


        //Vector2 pos = rigidbody.position + new Vector2(x, z);

        //instantiatedObj = (GameObject)Instantiate(prefab, rigidbody.position.x, rigidbody.position.y);
        Destroy(bullet, time);
    }

}
