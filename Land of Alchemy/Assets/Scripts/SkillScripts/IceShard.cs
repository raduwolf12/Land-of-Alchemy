using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class IceShard : AbilityMono
{
    public float distance;
    public float time;
    public GameObject prefab;
    public GameObject popPrefab;

     float cdTime;
     float acTime;

    public KeyCode key;


    enum AbilityState
    {
        ready,
        active,
        cooldown
    }

    AbilityState state = AbilityState.ready;


    // Update is called once per frame
    void Update()
    {
        Debug.Log(cooldownTime);
        switch (state)
        {
            case AbilityState.ready:
                if (Input.GetKeyDown(key))
                {
                    Activate(gameObject);
                    state = AbilityState.active;
                    acTime = activeTime;
                }
                break;
            case AbilityState.active:
                if (acTime > 0)
                {
                    acTime -= Time.deltaTime;
                }
                else
                {
                    state = AbilityState.cooldown;
                    cdTime = cooldownTime;
                   
                }
                break;
            case AbilityState.cooldown:
                Debug.Log(cdTime);
                if (cdTime > 0)
                {
                    cdTime -= Time.deltaTime;
                }
                else
                {
                    state = AbilityState.ready;
                }
                break;
        }



    }

    public override void Activate(GameObject parent)
    {
        PlayerController playerController = parent.GetComponent<PlayerController>();
        Rigidbody2D rigidbody = parent.GetComponent<Rigidbody2D>();


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

        Destroy(bullet, time);
    }
   // void OnCollisionEnter2D(Collision2D other)
   // {
   //     Debug.Log(other.gameObject.tag);

      //  foreach (ContactPoint2D missileHit in other.contacts)
      //  {
       //     Vector2 hitPoint = missileHit.point;     

      //      GameObject bullet = (GameObject)Instantiate(popPrefab, new Vector3(hitPoint.x, hitPoint.y, 0), Quaternion.identity); 
      //      Destroy(bullet, time);
      //  }

        //GameObject bullet = (GameObject)Instantiate(prefab, other.position.x, other.position.y);
       // Destroy(bullet, time);
    //}

}
