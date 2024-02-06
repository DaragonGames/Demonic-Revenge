using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Scripting;

public class GameManager : MonoBehaviour
{
    public static int gameState=1;
    public static GameObject camera;

    public enum ConditionNames {readBook, wearingRobe, hasFlashlight};

    public static Dictionary<ConditionNames, bool> conditionsMeet = new Dictionary<ConditionNames, bool>();

    void Awake()
    {
        conditionsMeet = new Dictionary<ConditionNames, bool>();
        foreach (var e in Enum.GetValues(typeof(ConditionNames)))
        {
            conditionsMeet.Add((ConditionNames)e, false);
        }
        Inventory.SetItems();
        camera = gameObject;
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("StartScreen");
        };
    }

}
