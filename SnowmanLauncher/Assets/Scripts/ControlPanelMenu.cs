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

    [SerializeField] GameObject indicator;
    [SerializeField] Sprite RTFOff;
    [SerializeField] Sprite RTFOn;

    //Snowball positioning
    public int xCoords; //A-F will send 1-6 as well
    public int yCoords; //Reminder: SUBTRACT 1 FROM BOTH X AND Y
    [SerializeField] Sprite[] letterDisplaySprites;
    [SerializeField] Sprite[] numberDisplaySprites;
    [SerializeField] GameObject letterDisplay;
    [SerializeField] GameObject numberDisplay;  //<-- ^^ set as their respective sprites/objects in the Unity editor
    [SerializeField] Slider xSlider;
    [SerializeField] Slider ySlider;
    private float measurementUnit;
    private Vector3 lowerLeftCoords;

    [SerializeField] GameObject snowball;
    private bool fireEnabled = true; //is the fire button on/off?
    Coroutine fireSnowball;
    Coroutine fireCooldown;

    // Start is called before the first frame update
    void Start()
    {
        //LLEFT'S COORDS ARE DIFFERENT IN EDITOR BC ITS LOCAL TO THE PARENT OBJECT IDFK WHY THEY DID IT LIKE THAT
        //but it works

        //!!! MAKE SURE EVERY MAP HAS A LOWERLEFT AND UPPERRIGHT POSITIONED PROPERLY !!!
        //and no non-square maps

        lowerLeftCoords = GameObject.FindWithTag("LowerLeft").transform.position;
        //Debug.Log(lowerLeftCoords.x + " " + lowerLeftCoords.y);
        measurementUnit = (((GameObject.FindWithTag("UpperRight").transform.position).x) - (lowerLeftCoords.x)) / 5;
        //Debug.Log(measurementUnit);

        //Initialize at A1 before u press anything
        xCoords = 1;
        yCoords = 1;

        //lowerLeftCoords += new Vector3(measurementUnit, 0, 0);
        //Instantiate(snowball, lowerLeftCoords, Quaternion.identity);
        
        

        player = GameObject.FindWithTag("Player");
        playerScript = player.GetComponent<PlayerMovement>();
    }

    /*
     * will worry about a READY TO FIRE button later
     * (if active, update state, also update state on open)
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
        UpdateRTF(fireEnabled);
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
            Debug.Log("SNOWBALL FIRED! " + "X: " + xCoords + "+" + xSlider.value + ", Y: " + yCoords + "+" + ySlider.value);

            float x = lowerLeftCoords.x + (measurementUnit * (xCoords - 1 + xSlider.value));
            float y = lowerLeftCoords.y + (measurementUnit * (yCoords - 1 + ySlider.value));
            Vector3 launchCoords = new Vector3(x,y,0);

            //vvv This may need to be a separate function or coroutine to facilitate spawning the snowball late
            //      made fireSnowball Coroutine for this purpose
            fireSnowball = StartCoroutine(SnowballCountdown(launchCoords));

            fireCooldown = StartCoroutine(FireCooldown());
        } else
        {
            Debug.Log("Fire button cooldown");
        }
    }

    private IEnumerator SnowballCountdown(Vector3 launchCoords)
    {
        yield return new WaitForSeconds(3.8f);
        Instantiate(snowball, launchCoords, Quaternion.identity);
    }

    private IEnumerator FireCooldown()
    {
        UpdateRTF(false);
        //Debug.Log("cooling down...");
        fireEnabled = false;
        yield return new WaitForSeconds(4);
        fireEnabled = true;
        Debug.Log("ready to go!");
        UpdateRTF(true);
    }

    private void UpdateRTF(bool on)
    {
        if (controlPanelOpen)
        {
            Sprite s;
            if (on)
            {
                s = RTFOn;
            } else
            {
                s = RTFOff;
            }
            indicator.GetComponent<UnityEngine.UI.Image>().sprite = s;
        }
    }
}
