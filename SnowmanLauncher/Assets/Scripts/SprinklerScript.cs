using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SprinklerScript : MonoBehaviour
{
    private bool visible;
    private Transform child;
    [SerializeField] GameObject sprinklerBullet;

    // Start is called before the first frame update
    void Start()
    {
        visible = false;
        child = this.gameObject.transform.GetChild(0);
        StartCoroutine(RotateAndFire());
    }

    // sup
    void FixedUpdate()
    {
        
    }

    public IEnumerator RotateAndFire()
    {
        while(true)
        {
            //rotate, fire, wait
            if(visible)
            {
                child.Rotate(0, 0, 30f, Space.Self);
                //Vector3 v = child.position;

                Instantiate(sprinklerBullet,child);
            }
            yield return new WaitForSeconds(0.2f);
        }
    }

    /*
     *  If the sprinklers bug out when exporting to OpenGL,
     *  determine visibility by checking distance from player
     *  in FixedUpdate
     *  instead of OnBecameVisible/Invisible
     */

    //flips visible/invisible based on camera render
    //BE WARNED, it starts as invisible, so
    //do NOT start sprinklers in LOS of the player
    private void OnBecameVisible()
    {
        visible = true;
        Debug.Log(gameObject.name + " is visible!");
    }
    private void OnBecameInvisible()
    {
        visible = false;
        Debug.Log(gameObject.name + " is invisible!");
    }
}
