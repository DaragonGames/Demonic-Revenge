using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;

public class Picture : MonoBehaviour
{

    private float counter = 0;

    // Update is called once per frame
    void Update()
    {
        Vector3 playerPositions = new Vector3(PlayerController.player.transform.position.x,0,PlayerController.player.transform.position.z);
        Vector3 thisObjectPositions = new Vector3(transform.position.x,0,transform.position.z);
        float distance= Vector3.Distance(playerPositions, thisObjectPositions);

        if (distance>5)
        {
            counter+=Time.deltaTime;
        }
        else if(distance<4)
        {
            counter=0;
        }

        float o= (counter-4f)*0.2f;
        GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, o); 
    }
}
