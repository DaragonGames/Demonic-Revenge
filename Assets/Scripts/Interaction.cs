using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    public static void TryToInteract(InteractableObject obj)
    {
        string worldObject = obj.name;

        // This List helds all Interactions beetwenn the world objects and 
        switch (worldObject) {
            case "Chair":
                // Either do something immediate
                // Or check for a specific held item
                if (Inventory.heldItem=="candle") {}
                // and or certain condition that has to be meet
                if (GameManager.conditionsMeet[GameManager.ConditionNames.testing]) {}
            break;
            case "screwdriver":
                PickupItem(obj);
            break;
        }
    }

    public static void GainItem(string itemName)
    {
        Inventory.addItem(itemName);
    }
    public static void UnlockCondition(GameManager.ConditionNames condition)
    {
        GameManager.conditionsMeet[condition] = true;
    }
    public static void comment(string line)
    {
        CommentController.commentor.Comment(line);
    }
    public static void DestroyOriginObject(InteractableObject obj)
    {
        Destroy(obj.gameObject);
    }
    public static void TransformOriginObject(InteractableObject obj)
    {
        Instantiate(obj.alternativePrefab, obj.transform);
        DestroyOriginObject(obj);
    }
    public static void UseItem()
    {
        Inventory.removeItem(Inventory.heldItem);
        Inventory.heldItem="";
    }
    public static void PickupItem(InteractableObject obj)
    {
        GainItem(obj.name);
        DestroyOriginObject(obj);
    }
    public static void TransformItem(string itemName)
    {
        GainItem(itemName);
        UseItem();
    }
}
