using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CommentController : MonoBehaviour
{
    public static CommentController commentor;
    public Transform playerPosition;
    private float timer=0;    
    private string displayText ="Alright, there’s tons of junk in the attic. Something here has to be cool enough to show off on TokTik. People love old crap. With enough luck, I might just go viral.";

    private float charPerSecond=15;
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
