using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    // Start is called before the first frame update
    void Start()
    {
        controlPanelCanvas = GameObject.FindGameObjectWithTag("ControlPanel");

    }

    // Update is called once per frame
    void Update()
    {
        
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

    }

    //vvv Triggers when the player or friendly is hit
    public void LoseGame(string reason)
    {
        if(!lost)
        {
            //(might need to do if(!won) in case u launch a snowball that hits AFTER winning but idk if it matters)

            //disable mortar canvas via FindWithTag("ControlPanel"); 
            //actually just do it with SerializeField

            //enable inactive loss screen via SerializeField (pass in da reason)
            Debug.Log("LOSE: " + reason);
            lost = true;
        }
        
    }
}
