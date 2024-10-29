using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SprinklerBullet : MonoBehaviour
{
    Coroutine stuff;
    [SerializeField] float lifetime;
    //private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        stuff = StartCoroutine(fireSelf());
        //rb = this.gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator fireSelf()
    {
        //give bullet its speed
        //nvm, done in SprinklerScript when instantiated

        //wait for lifetime seconds
        yield return new WaitForSeconds(2);
        //destroy bullet
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }
}
