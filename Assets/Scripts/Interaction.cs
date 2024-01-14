using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    public static void TryToInteract(InteractableObject obj)
    {
        if (Inventory.heldItem=="bat")
        {
            PlayerController.hitStuff();
        }

        string worldObject = obj.name;
        bool readBook=GameManager.conditionsMeet[GameManager.ConditionNames.readBook];

        // This List helds all Interactions beetwenn the world objects and the player
        switch (worldObject) {
            case "necroBook":
                UnlockCondition(GameManager.ConditionNames.readBook);
                DestroyOriginObject(obj);
            break;
            case "curtains":
                if (!readBook) {return;}
                if (Inventory.heldItem=="dagger") 
                {
                    UnlockCondition(GameManager.ConditionNames.wearingRobe);
                    UseItem();
                    TransformOriginObject(obj);
                }
            break;
            case "drain":
                if (!readBook) {return;}
                if (Inventory.heldItem=="magnetrope") 
                {
                    GainItem("lighter");
                    UseItem();
                }
            break;
            case "paintbucket":
                if (!readBook) {return;}
                if (Inventory.heldItem=="screwdriver") 
                {
                    TransformOriginObject(obj);
                    UseItem();
                }
            break;
            case "openPaintbucket":
                if (!readBook) {return;}
                if (Inventory.heldItem=="candle") 
                {
                    TransformItem("redCandle");
                }
            break;
            case "chest":
                if (!readBook) {return;}
                TransformOriginObject(obj);
                GainItem("bat");    
            break;
            case "fakeSkeleton":
                if (!readBook) {return;}
                if (Inventory.heldItem=="bat") 
                {
                    TransformOriginObject(obj);
                    GainItem("fakeSkull");
                    UseItem();
                }
            break;
            //
            // Endgame
            //
            case "oldPentagram":
                if (!readBook) {return;}
                if (Inventory.heldItem=="chalk") 
                {
                    TransformOriginObject(obj);
                    UseItem();
                }
            break;
            case "pentagram":
                if (!readBook) {return;}
                if (Inventory.heldItem=="redCandle") 
                {
                    TransformOriginObject(obj);
                    UseItem();
                }
            break;
            case "unlitPentagram":
                if (!readBook) {return;}
                if (Inventory.heldItem=="lighter") 
                {
                    TransformOriginObject(obj);
                    UseItem();
                }
            break;
            case "litPentagram":
                if (!readBook) {return;}
                if (!GameManager.conditionsMeet[GameManager.ConditionNames.wearingRobe]) {return;}
                if (Inventory.heldItem=="fakeSkull") 
                {
                    // GameOver
                    Debug.Log("The End");
                }
            break;     
            // 
            // Only Pickup Items
            // 
            case "dagger":
                if (!readBook) {return;}
                PickupItem(obj);
            break;
            case "rope":
                if (!readBook) {return;}
                PickupItem(obj);
            break;
            case "magnet":
                if (!readBook) {return;}
                PickupItem(obj);
            break;
            case "screwdriver":
                if (!readBook) {return;}
                PickupItem(obj);
            break;
            case "candle":
                if (!readBook) {return;}
                PickupItem(obj);
            break;
            case "chalk":
                if (!readBook) {return;}
                PickupItem(obj);
                comment("Das wird nützlich");
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
        Instantiate(obj.alternativePrefab, obj.transform.position, Quaternion.identity);
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
