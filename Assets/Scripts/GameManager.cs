using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting;

public class GameManager : MonoBehaviour
{
    public static int gameState=1;

    public enum ConditionNames { demonAngry, step5completed, testing};

    public static Dictionary<ConditionNames, bool> conditionsMeet = new Dictionary<ConditionNames, bool>();

    void Awake()
    {
        foreach (var e in Enum.GetValues(typeof(ConditionNames)))
        {
            conditionsMeet.Add((ConditionNames)e, false);
        }
        Inventory.SetItems();
    }

}
