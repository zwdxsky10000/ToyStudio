using System.Collections;
using System.Collections.Generic;
using ToyStudio.Engine.Logger;
using UnityEngine;

public class LogTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //Log.Info("this is log message");  
        
        Log.Info("this is log message num:{0}", 5);   
        Log.Info("this is log message num:{0} money:{1}", 5, 4.3f);

        PrintLog("this is log message num:{0}", 5);
        PrintLog("this is log message num:{0} money:{1}", 5, 4.3f);
    }

    void PrintLog(string format, params object[] args)
    {
        string message = string.Format(format, args);
        Debug.Log(message);
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
