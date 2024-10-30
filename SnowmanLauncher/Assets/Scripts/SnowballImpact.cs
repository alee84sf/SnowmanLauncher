using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowballImpact : MonoBehaviour
{
    private SpriteRenderer sprite;
    private Coroutine stuff;
    private GameControllerScript controller;

    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        stuff = StartCoroutine(DespawnSnowball());
        controller = GameObject.FindWithTag("GameController").GetComponent<GameControllerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator DespawnSnowball()
    {
        yield return new WaitForSeconds(0.1f);
        //disable the collider
        GetComponent<Collider2D>().enabled = false;

        //fade it out in a while loop
        //Fade-out reference: https://www.youtube.com/watch?v=RNccTrsgO9g
        float time = 0;
        float duration = 1.3f;

        //Color opaque = new Color();

        while(time<duration)
        {
            sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, Mathf.Lerp(1,0,time/duration));
            time += Time.deltaTime;
            yield return null;
        }
        sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, 0);
        Debug.Log("Impact done fading out");
        Destroy(gameObject);
    }

    //snowball hitting the thing
    private void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log("Hit something");
        //hitting yourself: (lose)
        //hitting friend: (lose)
        //hitting enemies:
        
        if(other.gameObject.CompareTag("Player"))
        {
            controller.LoseGame("YOU HIT YOURSELF");
            //Debug.Log("hit YOURSELF");
        }
        if(other.gameObject.CompareTag("Collectible"))
        {
            controller.LoseGame("YOU HIT A SNOWMAN");
            //Debug.Log("hit FRIEND");
        }
        if(other.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("hit enemy " + other.gameObject.name);
            SprinklerScript s = other.gameObject.GetComponent<SprinklerScript>();
            if(s != null)
            {
                s.Explode();
            }
        }
    }
}
