using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class EarthBump : Ability
{
    public GameObject prefab;
    public int numberOfObjects = 20;
    public float radius = 1f;
    public float time;
    private GameObject instantiatedObj;

    public override void Activate(GameObject parent)
        {
            PlayerController playerController = parent.GetComponent<PlayerController>();
            Rigidbody2D rigidbody = parent.GetComponent<Rigidbody2D>();

        for (int i = 0; i < numberOfObjects; i++)
        {
            float angle = i * Mathf.PI * 2 / numberOfObjects;
            float x = Mathf.Cos(angle) * radius;
            float z = Mathf.Sin(angle) * radius;
            Vector2 pos = rigidbody.position + new Vector2(x,  z);
            float angleDegrees = -angle * Mathf.Rad2Deg;
            Quaternion rot = Quaternion.Euler(0, angleDegrees, 0);
            instantiatedObj = (GameObject) Instantiate(prefab, pos, rot);
            Destroy(instantiatedObj, time);
        }
        


    }

}