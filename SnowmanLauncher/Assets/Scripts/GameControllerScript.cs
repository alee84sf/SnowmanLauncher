using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameControllerScript : MonoBehaviour
{
    private GameObject controlPanelCanvas;
    //these probably need to be serialized in case I can't refer to them when deactivated
    //TODO: search it up
    //Or if I can't, I can leave them enabled, refer to them in start, then disable them
    // :)
    [SerializeField] GameObject loseCanvas;
    [SerializeField] GameObject winCanvas;

    bool lost = false;
    public string lossReason = "unknown reason";

    //npc spawning
    [SerializeField] int friendlyCount;
    [SerializeField] int enemyCount;
    [SerializeField] GameObject friendly;
    [SerializeField] GameObject enemy;

    // Start is called before the first frame update
    void Start()
    {
        controlPanelCanvas = GameObject.FindGameObjectWithTag("ControlPanel");

        //Spawning in friendlies/enemies
        GameObject[] fSpawns = GameObject.FindGameObjectsWithTag("FriendlySpawn");
        List<GameObject> list = new List<GameObject>(fSpawns);
        while (friendlyCount > 0)
        {
            int i = Random.Range(0, list.Count);
            Instantiate(friendly, list[i].transform.position, list[i].transform.rotation);
            list.RemoveAt(i);
            friendlyCount--;
        }
        GameObject[] eSpawns = GameObject.FindGameObjectsWithTag("EnemySpawn");
        list = new List<GameObject>(eSpawns);
        while (enemyCount > 0)
        {
            int i = Random.Range(0, list.Count);
            Instantiate(enemy, list[i].transform.position, list[i].transform.rotation);
            list.RemoveAt(i);
            enemyCount--;
        }

    }

    // Update is called once per frame
    void Update()
    {
        //reload scene
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        //main menu
        if (Input.GetKeyDown(KeyCode.BackQuote))
        {
            Debug.Log("main menu");
        }
    }

    //vvv Triggers when the player kills enemy and/or saves friend
    public void CheckWinConditions()
    {
        //if GetObjectByTag("Enemy") and GetObjectByTag("Collectible") = null:
        //delete all bullets
        //you win
        Debug.Log("checking win conditions...");
        GameObject[] friends = GameObject.FindGameObjectsWithTag("Collectible");
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        //debugging: prints full list
        /*
        string result = "";
        foreach(GameObject g in friends)
        {
            result += g.name + "|";
        }
        Debug.Log("friends: " + result);
        result = "";
        foreach (GameObject g in enemies)
        {
            result += g.name + "|";
        }
        Debug.Log("enemies: " + result);
        */

        //debugging contents
        //Final version: if(friends.Length == 0 && enemies.Length == 0)
        //PROBLEM: friends/enemies include themselves in the check
        //Might need to make this an IENumerator?
        /*
        if (friends.Length == 0)
        {
            Debug.Log("No friends left");
        } else
        {
            Debug.Log("friends left");
        }
        if (enemies.Length == 0)
        {
            Debug.Log("No enemies left");
        }
        else
        {
            Debug.Log("enemies left");
        }
        */

        if (friends.Length == 0 && enemies.Length == 0)
        {
            Debug.Log("You win!");
            lost = true;
            winCanvas.SetActive(true);
        }

    }

    //vvv Triggers when the player or friendly is hit
    public void LoseGame(string reason)
    {
        if(!lost)
        {
            lossReason = reason;
            //(might need to do if(!won) in case u launch a snowball that hits AFTER winning but idk if it matters)

            //disable mortar canvas via FindWithTag("ControlPanel"); 
            //actually just do it with SerializeField

            //enable inactive loss screen via SerializeField (pass in da reason)
            //*instead of passing in the reason, have the loss screen get the reason
            //from this script
            Debug.Log("LOSE: " + reason);
            lost = true;

            //enable loss screen
            loseCanvas.SetActive(true);


        }
        
    }
}
