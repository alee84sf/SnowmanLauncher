using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlPanelMenu : MonoBehaviour
{
    public bool controlPanelOpen = false;
    public GameObject controlPanelUI;
    public GameObject player;
    private PlayerMovement playerScript;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        playerScript = player.GetComponent<PlayerMovement>();
    }

    /*
     * I probably need to keep track of the menu timers here
     * i.e. the fire button cooldown
     * On fire button press: fireable=false, change LED, start cooldown
     * 
     * when cooldown is done:
     * fireable=true
     * 
     * pressing fire button checks fireable in ControlPanelMenu, ControlPanel never gets disabled so it will always know
     * 
     * will worry about a READY TO FIRE button later
     *      
     * Open/closing the menu referred to this video: https://www.youtube.com/watch?v=JivuXdrIHK0
     */

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(controlPanelOpen)
            {
                ClosePanel();
                playerScript.movementEnabled = true;
            } else
            {
                OpenPanel();
                playerScript.movementEnabled = false;
            }

        } 
    }

    void OpenPanel()
    {
        controlPanelUI.SetActive(true);
        controlPanelOpen = true;
    }
    void ClosePanel()
    {
        controlPanelUI.SetActive(false);
        controlPanelOpen = false;
    }
}
