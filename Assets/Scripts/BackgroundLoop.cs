using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundLoop : MonoBehaviour
{
    //create a var that will be unique
    public static BackgroundLoop instance;
    private void Awake()
    {
        //make sure that there is only 1 instance of music at all time
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }
}
