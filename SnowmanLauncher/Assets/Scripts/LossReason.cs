using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LossReason : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //script literally just exists to fill the reason
        //GameObject.FindWithTag("LossReason").GetComponent<Text>().text = GameObject.FindWithTag("GameController").GetComponent<GameControllerScript>().lossReason;
        //gameObject.GetComponent<Text>().text = GameObject.FindWithTag("GameController").GetComponent<GameControllerScript>().lossReason;
        gameObject.GetComponent<TMP_Text>().text = GameObject.FindWithTag("GameController").GetComponent<GameControllerScript>().lossReason;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
