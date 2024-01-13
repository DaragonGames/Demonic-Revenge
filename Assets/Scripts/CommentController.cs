using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CommentController : MonoBehaviour
{
    public static CommentController commentor;
    private float timer=0;    
    private string displayText = "";

    private float charPerSecond=8;
    private float lingeringTime=3;

    // Start is called before the first frame update
    void Awake()
    {
        commentor=this;
    }

    // Update is called once per frame
    void Update()
    {
        timer+= Time.deltaTime;
        if (timer >=displayText.Length/charPerSecond+lingeringTime)
        {
            gameObject.SetActive(false);
        }

        string outMessage = "";
        for (int i= 0; i < Math.Min(displayText.Length, timer*charPerSecond); i++ )
        {
            outMessage += displayText[i];
        }
        GetComponentInChildren<TMP_Text>().text= outMessage;
    }

    public void Comment(string comment)
    {
        timer=0;
        gameObject.SetActive(true);
        displayText = comment;
    }
}
