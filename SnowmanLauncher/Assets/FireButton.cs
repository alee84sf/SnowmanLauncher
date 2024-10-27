using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class FireButton : MonoBehaviour, IPointerDownHandler
{
    //borrows some logic from CoordinateButton
    private ControlPanelMenu controlScript;

    public void OnPointerDown(PointerEventData eventData)
    {
        controlScript.FireSnowball();
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
