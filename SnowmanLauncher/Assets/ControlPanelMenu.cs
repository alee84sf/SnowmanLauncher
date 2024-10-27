using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlPanelMenu : MonoBehaviour
{
    public bool controlPanelOpen = false;
    public GameObject controlPanelUI;
    public GameObject player;
    private PlayerMovement playerScript;

    //Snowball positioning
    public int xCoords; //A-F will send 1-6 as well
    public int yCoords; //Reminder: SUBTRACT 1 FROM BOTH X AND Y
    [SerializeField] Sprite[] letterDisplaySprites;
    [SerializeField] Sprite[] numberDisplaySprites;
    [SerializeField] GameObject letterDisplay;
    [SerializeField] GameObject numberDisplay;  //<-- ^^ set as their respective sprites/objects in the Unity editor
    [SerializeField] Slider xSlider;
    [SerializeField] Slider ySlider;

    private bool fireEnabled = true; //is the fire button on/off?
    Coroutine fireCooldown;

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
     * pressing fire button checks fireable in ControlPanelMenu, ControlPanel never gets disabled so it will always know (get by tag ControlPanel)
     * 
     * will worry about a READY TO FIRE button later
     * (if active, update state, also update state on open)
     *      
     * 
     */

    // Update is called once per frame
    void Update()
    {
        //Open/closing the menu referred to this video: https://www.youtube.com/watch?v=JivuXdrIHK0
        if (Input.GetKeyDown(KeyCode.Space))
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

    public void SetCoords(int n, bool isLetter)
    {
        //TODO: Don't forget to -1 when doing the actual calculations
        if(isLetter)
        {
            xCoords = n;
            //UPDATE LETTER SPRITE
            letterDisplay.GetComponent<UnityEngine.UI.Image>().sprite = letterDisplaySprites[n-1];
        } else
        {
            yCoords = n;
            //UPDATE NUMBER SPRITE
            numberDisplay.GetComponent<UnityEngine.UI.Image>().sprite = numberDisplaySprites[n - 1];
        }
        //update display based on what was set above
    }

    public void FireSnowball()
    {
        if(fireEnabled)
        {
            //actually fire the snowball
            Debug.Log("SNOWBALL FIRED");
            fireCooldown = StartCoroutine(FireCooldown());
        } else
        {
            Debug.Log("Fire button cooldown");
        }
    }

    private IEnumerator FireCooldown()
    {
        Debug.Log("cooling down...");
        fireEnabled = false;
        yield return new WaitForSeconds(4);
        fireEnabled = true;
        Debug.Log("ready to go!");
    }
}
