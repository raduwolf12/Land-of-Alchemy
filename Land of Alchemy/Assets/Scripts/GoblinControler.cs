using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinControler : MonoBehaviour
{
    public float moveSpeed;
    public float timeBetweenMove;
    private float timeBetweenMoveCounter;
    public float timeToMove;
    private float timeToMoveCounter;
    private Rigidbody2D myrigid;
    private bool moving;
    private Vector3 moveDirection;
    private Animator anim;
    private float getX;
    private float getY;

    public float waitToReload;
    private bool reloading;
    private GameObject thePlayer;

    float maxX = 0;
    float maxY = 0;

    float StartX = 0;
    float StartY = 0;

    void Start()
    {
        anim = GetComponent<Animator>();

        myrigid = GetComponent<Rigidbody2D>();

        timeBetweenMoveCounter = Random.Range(timeBetweenMove * 0.75f, timeBetweenMove * 1.25f);
        timeToMoveCounter = Random.Range(timeToMove * 0.75f, timeBetweenMove * 1.25f);

        StartX = transform.position[0];
        StartY = transform.position[1];
        maxX = StartX + 3;
        maxY = StartY + 3;

    }
    void Update()
    {
  

        if (moving)
        {
            timeToMoveCounter -= Time.deltaTime;
            myrigid.velocity = moveDirection;

            if (timeToMoveCounter < 0f)
            {
                moving = false;
                timeBetweenMoveCounter = Random.Range(timeBetweenMove * 0.75f, timeBetweenMove * 1.25f);

            }
            anim.SetFloat("movex", getX);
            anim.SetFloat("movey", getY);
            anim.SetBool("GoblinMoving", true);
        }
        else
        {
            anim.SetBool("GoblinMoving", false);

            timeBetweenMoveCounter -= Time.deltaTime;
            myrigid.velocity = Vector2.zero;
            if (timeBetweenMoveCounter < 0f)
            {
                moving = true;
                timeToMoveCounter = Random.Range(timeToMove * 0.75f, timeToMove * 1.25f);

                getX = Random.Range(-1f, 1f);
                //getY = Random.Range(-1f, 1f);
                getY = 0;
                float curentX =  transform.position[0];
                float curentY = transform.position[1];

                //if (getX + curentX > maxX)
                //{
                //    if (getY + curentY > maxY)
                //    {
                //        moveDirection = new Vector3(-getX * moveSpeed, -getY * moveSpeed, 0f);

                //    }
                //    else
                //    {
                //        moveDirection = new Vector3(-getX * moveSpeed, getY * moveSpeed, 0f);

                //    }
                //}
                ////else if (getX + curentX < maxX)
                ////{
                ////    if (getY + curentY < maxY)
                ////    {
                ////        moveDirection = new Vector3(-getX * moveSpeed, -getY * moveSpeed, 0f);

                ////    }
                ////    else
                ////    {
                ////        moveDirection = new Vector3(-getX * moveSpeed, getY * moveSpeed, 0f);

                ////    }
                ////}
                //else 
                //{
                    moveDirection = new Vector3(getX * moveSpeed, getY * moveSpeed, 0f);

                //}


            }

        }

        if (reloading)
        {
            waitToReload -= Time.deltaTime;
            if (waitToReload < 0f)
            {
                Application.LoadLevel(Application.loadedLevel);

                thePlayer.SetActive(true);
            }
        }

    }

    void OnCollisionEnter2D(Collision2D other)
    {
        anim.SetBool("GoblinMoving", false);
        anim.SetBool("Attack", true);
        moving = false;

        /*
         //this code insta kill the player        */
        if (other.gameObject.name=="player")
        {

     

            float x = other.contacts[0].point[0];
            float y = other.contacts[0].point[1];
            float x1 = transform.position[0];
            float y1 = transform.position[1];


            anim.SetFloat("movex", x-x1);
            anim.SetFloat("movey", y-y1);
            //other.gameObject.GetComponent<PlayerHealthManager>().HurtPlayer(5);
            float c = x - x1;
            float d = -y - y1;


            print("First point that collided: " + c +','+ d);

            // Destroy(other.gameObject);
            //other.gameObject.SetActive(false);
            //reloading = true;
            //thePlayer = other.gameObject;
        }
        if (other.gameObject.name == "warp")
        {
            moveDirection = new Vector3(-getX * moveSpeed, getY * moveSpeed, 0f);
            print("da");
        }


    }
    void OnCollisionExit2D(Collision2D other)
    {
        moving = true;

        anim.SetBool("Attack", false);
        anim.SetBool("GoblinMoving", true);
    }

}
