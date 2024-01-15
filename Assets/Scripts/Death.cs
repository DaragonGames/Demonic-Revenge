using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{

    public static Death main;
    private float deathTimer=0;

    void Awake()
    {
        main=this;
        gameObject.SetActive(false);
    }

    void Update()
    {
        deathTimer += Time.deltaTime;
        float o= (deathTimer*0.25f)-0.25f;
        transform.GetChild(2).GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, o); 
        transform.GetChild(3).GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, o); 

        if (deathTimer > 5)
        {
            transform.GetChild(1).gameObject.SetActive(false);
            transform.GetChild(2).gameObject.SetActive(false);
            transform.GetChild(3).gameObject.SetActive(false);
        }
    }

    public static void Now()
    {
        PlayerController.player.gameObject.SetActive(false);
        main.transform.GetChild(0).transform.position = PlayerController.player.transform.position + Vector3.up*2;        
        main.transform.GetChild(0).transform.localScale = PlayerController.player.transform.GetChild(0).localScale;        
        main.gameObject.SetActive(true);
        GameManager.gameState=2;
        main.deathTimer=0;
    }
}
