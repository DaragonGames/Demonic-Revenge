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
                    comment("Nobody needs curtains in an attic. I’m a cultist now, baby!");  
                }
            break;
            case "drain":
                comment("Don’t know why there would be a drain here, but then I’m no interior designer.");  
                if (!readBook) {return;}
                if (Inventory.heldItem=="rope")
                {
                    comment("Right, I’m just gonna abseil into this here tiny hole. Not!");    
                }
                if (Inventory.heldItem=="magnet")
                {
                    comment("The grate is not magnetic.");    
                }
                if (Inventory.heldItem=="magnetrope") 
                {
                    GainItem("lighter");
                    UseItem();
                    comment("I don’t smoke, but these lighters are fun to use.");                                                      
                }
            break;
            case "paintbucket":
                if (!readBook) {return;}
                if (Inventory.heldItem=="screwdriver") 
                {
                    TransformOriginObject(obj);
                    UseItem();
                    comment("Yes, the bucket is open. I'm a genius, I could even solve a double labyrinth!"); 
                }
            break;
            case "openPaintbucket":
                if (!readBook) {return;}
                if (Inventory.heldItem=="candle") 
                {
                    TransformItem("redCandle");
                    comment("Now I don’t have red candles. —- Now I do.");  
                }
            break;
            case "chest":
                if (!readBook) {return;}
                TransformOriginObject(obj);
                GainItem("bat");    
                comment("Well, well, well, if it isn’t my old baseball bat. I used to love BONKing stuff.");   
            break;
            case "fakeSkeleton":
                if (!readBook) {return;}
                if (Inventory.heldItem=="bat") 
                {
                    TransformOriginObject(obj);
                    GainItem("fakeSkull");
                    comment("2B or not 2B...");
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
                    comment("The book said I need a summoning circle, this should do.");                                             
                }
            break;
            case "pentagram":
                if (!readBook) {return;}
                if (Inventory.heldItem=="redCandle") 
                {
                    TransformOriginObject(obj);
                    UseItem();
                }
                if (Inventory.heldItem=="candle")
                {
                    comment("Wait, the book said I need candles in the color of blood. It’s gotta look authentic!");    
                }
            break;
            case "unlitPentagram":
                if (!readBook) {return;}
                if (Inventory.heldItem=="lighter") 
                {
                    TransformOriginObject(obj);
                    comment("AND THUS I AM BECOME PROMETHEUS!");
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
                comment("A creepy dagger. Wonder if I could quickstep with this.");
            break;
            case "rope":
                if (!readBook) {return;}
                comment("Found some rope.");
                PickupItem(obj);
            break;
            case "magnet":
                if (!readBook) {return;}
                comment("It’s mine now —- my precious...");
                PickupItem(obj);
            break;
            case "screwdriver":
                if (!readBook) {return;}
                comment("A screwdriver, sadly not the kind you can drink.");
                PickupItem(obj);
            break;
            case "candle":
                if (!readBook) {return;}
                comment("Found some candles.");
                PickupItem(obj);
            break;
            case "chalk":
                if (!readBook) {return;}
                PickupItem(obj);
                comment("This is chalk or 5 white pixels, I`m not sure.");
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
