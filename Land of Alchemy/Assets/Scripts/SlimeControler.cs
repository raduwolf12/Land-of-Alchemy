using UnityEngine;
using System.Collections;

public class SlimeControler : MonoBehaviour {

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
    void Start()
    {
        anim = GetComponent<Animator>();

        myrigid = GetComponent<Rigidbody2D>();

        //timeBetweenMoveCounter = Random.Range(timeBetweenMove * 0.75f, timeBetweenMove * 1.25f);
        //timeToMoveCounter = Random.Range(timeToMove * 0.75f, timeToMove * 1.25f);

        timeBetweenMoveCounter = Random.Range(timeBetweenMove * 0.75f, timeBetweenMove * 1.25f);
        timeToMoveCounter = Random.Range(timeToMove * 0.75f, timeBetweenMove * 1.25f);

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
            anim.SetFloat("moveX", getX);
            anim.SetFloat("moveY", getY);
        }
        else
        {
            timeBetweenMoveCounter -= Time.deltaTime;
            myrigid.velocity = Vector2.zero;
            if (timeBetweenMoveCounter < 0f)
            {
                moving = true;
                timeToMoveCounter = Random.Range(timeToMove * 0.75f, timeToMove * 1.25f);

                getX = Random.Range(-1f, 1f);
                getY = Random.Range(-1f, 1f);
                moveDirection = new Vector3(getX * moveSpeed, getY * moveSpeed, 0f);
            }

        }

       if(reloading)
        {
            waitToReload -= Time.deltaTime;
            if(waitToReload<0f)
            {
                Application.LoadLevel(Application.loadedLevel);

                thePlayer.SetActive(true);
             }
        }

    }

    void OnCollisionEnter2D(Collision2D other)
    {
        /*
         //this code insta kill the player
        if (other.gameObject.name=="player")
        {
            // Destroy(other.gameObject);
            other.gameObject.SetActive(false);
            reloading = true;
            thePlayer = other.gameObject;
        }
        */
    }


}