using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleCollisions : MonoBehaviour
{
    //PUT THIS IN THE COLLECTIBLE TO HAVE IT PICK ITSELF UP
    private SpriteRenderer sprite;
    private Coroutine stuff;

    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            //Debug.Log("I just got picked up by Player");

            //temporary tag excludes this object from counting itself when checking win conditions
            //reference https://discussions.unity.com/t/exclude-self-in-findgameobjectswithtag/39187/3
            this.gameObject.tag = "PickedUpAlready";

            //fade out
            stuff = StartCoroutine(DespawnCollectible());

            //win logic here
            GameObject.FindWithTag("GameController").GetComponent<GameControllerScript>().CheckWinConditions();
        }
        /*else
        {
            Debug.Log("I, " + gameObject.name + ", touched " + collision.gameObject.name);
        }*/
    }

    //I COPIED THIS DIRECTLY FROM THE SNOWBALL SCRIPT
    IEnumerator DespawnCollectible()
    {
        //yield return new WaitForSeconds(0.1f);
        //disable the collider
        GetComponent<Collider2D>().enabled = false;

        //fade it out in a while loop
        //Fade-out reference: https://www.youtube.com/watch?v=RNccTrsgO9g
        float time = 0;
        float duration = 0.4f;

        //Color opaque = new Color();

        while (time < duration)
        {
            sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, Mathf.Lerp(1, 0, time / duration));
            time += Time.deltaTime;
            yield return null;
        }
        sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, 0);
        //Debug.Log("Collectible done fading out");
        Destroy(gameObject);
    }
}
