using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SprinklerScript : MonoBehaviour
{
    private bool visible;
    private Transform child;
    [SerializeField] GameObject sprinklerBullet;
    [SerializeField] float moveSpeed;
    public enum Direction {up, down, left, right};

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
                child.Rotate(0, 0, 70f, Space.Self);
                //Vector3 v = child.position;

                SpawnBullet(Direction.up);
                SpawnBullet(Direction.down);
            }
            yield return new WaitForSeconds(0.2f);
        }
    }

    public void SpawnBullet(Direction dir)
    {
        GameObject bullet = Instantiate(sprinklerBullet, child.position, child.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        Vector2 v = new Vector2();
        if(dir == Direction.up)
        {
            v = child.transform.up;
        } 
        else if (dir == Direction.down)
        {
            v = -child.transform.up;
        }
        else if (dir == Direction.left)
        {
            v = -child.transform.right;
        }
        else if (dir == Direction.right)
        {
            v = child.transform.right;
        }

        rb.velocity = v * moveSpeed;
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
