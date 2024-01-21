using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DelayedAction : MonoBehaviour
{

    private float delayTime;
    private float delayTimer;

    private Type type;
    private Func<string,Null> delayedAction;

    // Start is called before the first frame update
    void SetValues(float time, Func<string,Null> function)
    {
        delayedAction=function;
        delayTime=time;
        delayTimer=0;
    }

    // Update is called once per frame
    void Update()
    {
        delayTimer+= Time.deltaTime;
        if (delayTimer>= delayTime)
        {
            delayedAction("");
        }
    }
}
