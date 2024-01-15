using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NecroBook : MonoBehaviour
{
    public static NecroBook main;

    // Start is called before the first frame update
    void Awake()
    {
        main=this;
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            gameObject.SetActive(false);
        }
    }

    public static void Read()
    {
        main.gameObject.SetActive(true);
    }
}
