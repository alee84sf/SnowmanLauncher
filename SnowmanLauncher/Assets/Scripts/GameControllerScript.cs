using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControllerScript : MonoBehaviour
{
    private GameObject controlPanelCanvas;
    [SerializeField] GameObject loseCanvas;
    [SerializeField] GameObject winCanvas;

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
        //you win
    }

    //vvv Triggers when the player or friendly is hit
    public void LoseGame(string reason)
    {
        //(might need to do if(!won) in case u launch a snowball that hits AFTER winning but idk if it matters)

        //disable mortar canvas via FindWithTag("ControlPanel"); 
        //actually just do it with SerializeField

        //enable inactive loss screen via SerializeField (pass in da reason)
    }
}
