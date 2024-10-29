using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleCollisions : MonoBehaviour
{
    //PUT THIS IN THE COLLECTIBLE TO HAVE IT PICK ITSELF UP

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("I just got picked up by Player");

            //win logic here
            GameObject.FindWithTag("GameController").GetComponent<GameControllerScript>().CheckWinConditions();
        }
        else
        {
            Debug.Log("I, " + gameObject.name + ", touched " + collision.gameObject.name);
        }
    }
}
