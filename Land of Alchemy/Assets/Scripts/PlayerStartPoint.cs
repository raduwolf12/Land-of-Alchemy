﻿using UnityEngine;
using System.Collections;

public class PlayerStartPoint : MonoBehaviour {

    private PlayerController thePlayer;
    private CameraControler theCamera;

    public Vector2 startDirection;


    public string pointName;


    // Use this for initialization
    void Start()
    {
        thePlayer = FindObjectOfType<PlayerController>();

        if (thePlayer.startPoint == pointName)
        {


            thePlayer.transform.position = transform.position;
            thePlayer.lastMove = startDirection;


            theCamera = FindObjectOfType<CameraControler>();
            theCamera.transform.position = new Vector3(transform.position.x, transform.position.y, theCamera.transform.position.z);
        }
    }
	// Update is called once per frame
	void Update () {
	
	}
}
