using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mirror : MonoBehaviour
{
    public Sprite[] sprites;
    private float counter;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerPositions = new Vector3(PlayerController.player.transform.position.x,0,PlayerController.player.transform.position.z);
        float xDistance = Math.Abs(playerPositions.x - transform.position.x);
        float zDistance = Math.Abs(playerPositions.z - transform.position.z);
        if (xDistance < 0.4f & zDistance < 2.5f)
        {
            GetComponent<SpriteRenderer>().sprite = sprites[1];
            if (counter >2)
            {
                GetComponent<SpriteRenderer>().sprite = sprites[2];
            }
            counter += Time.deltaTime;
        }
        else
        {
            GetComponent<SpriteRenderer>().sprite = sprites[0];
            counter = 0;
        }
    }
}
