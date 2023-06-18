using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Dash : Ability
{
    public float dashVelocity;

    public override void Activate(GameObject parent)
    {
        PlayerController playerController = parent.GetComponent<PlayerController>();
        Rigidbody2D rigidbody = parent.GetComponent<Rigidbody2D>();
        playerController.curentMoveSpeed = playerController.curentMoveSpeed * dashVelocity;
    }

    
}
