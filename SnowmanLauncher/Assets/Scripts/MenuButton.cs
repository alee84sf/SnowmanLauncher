using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButton : MonoBehaviour
{
    //just put this script on the main camera for every menu scene with buttons

    public void Load(string scene)
    {
        if(scene != null)
        {
            SceneManager.LoadScene(scene);
        }
        else
        {
            Debug.Log("scene to load is null");
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
