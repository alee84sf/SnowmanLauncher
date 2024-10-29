using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CoordinateButton : MonoBehaviour,IPointerDownHandler
{
    public bool isLetter; //TRUE if A-F, FALSE if 1-6
    public int buttonValue; //range from 1-6
    //A=1, B=2...       1=1,2=2...
    private ControlPanelMenu controlScript;

    //Button functionality reference: https://www.youtube.com/watch?v=lF26yGJbsQk ~13:38

    public void OnPointerDown(PointerEventData eventData)
    {
        controlScript.SetCoords(buttonValue, isLetter);
        Debug.Log("button pressed, " + buttonValue + " " + isLetter);

        //Put button press sound HERE if I have time
        //throw new System.NotImplementedException();
    }

    // Start is called before the first frame update
    void Start()
    {
        controlScript = GameObject.FindWithTag("ControlPanel").GetComponent<ControlPanelMenu>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
