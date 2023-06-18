using UnityEngine;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNewScene : MonoBehaviour
{
    public int sceneNr;

    public string levelToLoad;

    public string exitPoint;

    private PlayerController thePlayer;

    // Use this for initialization
    void Start()
    {
        thePlayer = FindObjectOfType<PlayerController>();

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)

    {
        if (other.gameObject.name == "player")
        {
            SceneManager.LoadScene(sceneNr);
            Application.LoadLevel(levelToLoad);
            thePlayer.startPoint = exitPoint;
            Debug.Log(exitPoint);
        }
    }
}