using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    public static void TryToInteract(InteractableObject obj)
    {
        string worldObject = obj.name;
        bool readBook=GameManager.conditionsMeet[GameManager.ConditionNames.readBook];

        switch (worldObject) {
            case "pictureCovered":
                //if (Inventory.heldItem!="" && Inventory.heldItem!="")
                TransformOriginObject(obj);
                comment("Well that’s a dull painting. She’s just sitting there. Creepy smile tho. Who painted this affront to the visual arts?");  
                break;
            case "necroBook":
                UnlockCondition(GameManager.ConditionNames.readBook);
                NecroBook.Read();
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
                if (Inventory.heldItem=="bat")
                {
                    comment("I'm not a hooligan.");  
                } 
            break;
            case "drain": 
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
                    
                    PlayerController.player.StartAnimation("fishing", obj);
                    UseItem();
                    GainItem("lighter");
                    //comment("I don’t smoke, but these lighters are fun to use.");                                                      
                }
            break;
            case "paintbucket":
                if (!readBook) {return;}
                if (Inventory.heldItem=="bat")
                {
                    PlayerController.player.StartAnimation("hitting", obj);
                }  
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
                if (Inventory.heldItem=="bat")
                {
                    PlayerController.player.StartAnimation("hitting", obj);
                } 
            break;
            case "chest":
                if (!readBook) {return;}
                if (Inventory.heldItem=="chestKey") 
                {
                    TransformOriginObject(obj);
                    GainItem("bat");    
                    comment("Well, well, well, if it isn’t my old baseball bat. I used to love BONKing stuff."); 
                    UseItem();
                }
                else{
                    comment("It's locked, but at least it's not a mimic.");
                }
                if (Inventory.heldItem=="bat")
                {
                    PlayerController.player.StartAnimation("hitting", obj);
                }   
            break;
            case "box":
                if (!readBook) {return;}
                TransformOriginObject(obj);
                GainItem("batterie");    
                comment("I'm in charge now."); 
                if (Inventory.heldItem=="bat")
                {
                    PlayerController.player.StartAnimation("hitting", obj);
                }   
            break;
            case "fakeSkeleton":
                if (!readBook) {return;}
                if (Inventory.heldItem=="bat") 
                {
                    PlayerController.player.StartAnimation("hitting", obj);
                    TransformOriginObject(obj);
                    GainItem("fakeSkull");
                    comment("2B or not 2B...");
                    UseItem();
                }
            break;
            case "jackInTheBox":
                if (!GameManager.conditionsMeet[GameManager.ConditionNames.hasFlashlight]) {return;}
                if (Inventory.heldItem=="bat")
                {
                    PlayerController.player.StartAnimation("hitting", obj);
                }
                else
                {
                    PlayerController.player.StartAnimation("panic", obj);
                    StartAnimation(obj);
                }                
            break;
            case "chestKey":
                if (!readBook) {return;}
                if (!GameManager.conditionsMeet[GameManager.ConditionNames.hasFlashlight]) {return;}
                if (Inventory.heldItem == "broom")
                {
                    PickupItem(obj);
                    comment("I hope I did not make that spider my mortal enemy.");
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
                    UseItem();
                    Death.Now();
                }
            break;    
            //
            // Room Chnagers like Doors, Ladder etc
            // 
            case "ladderDown":
                ChangeRoom("cellar",0);  
                return;                
            break;
            case "ladderUp":
                ChangeRoom("attic",0); 
                return;               
            break;
            // 
            // Only Pickup Items
            // 
            case "dagger":
                if (!GameManager.conditionsMeet[GameManager.ConditionNames.hasFlashlight]) {return;}
                PickupItem(obj);
                comment("A creepy dagger. Wonder if I could quickstep with this.");
                return;
            break;
            case "rope":
                comment("Found some rope.");
                PickupItem(obj);
                return;
            break;
            case "magnet":
                if (!GameManager.conditionsMeet[GameManager.ConditionNames.hasFlashlight]) {return;}
                comment("It’s mine now —- my precious...");
                PickupItem(obj);
                return;
            break;
            case "screwdriver":
                comment("A screwdriver, sadly not the kind you can drink.");
                PickupItem(obj);
                return;
            break;
            case "candle":
                comment("Found some candles.");
                PickupItem(obj);
                return;
            break;
            case "chalk":
                PickupItem(obj);
                comment("This is chalk or five white pixels, I`m not sure.");
                return;
            break;
            case "flashLightEmpty":
                PickupItem(obj);                
                comment("Great news! You've picked up a flashlight. Prepare for a bright future – or at least, a better-lit present. Say goodbye to shadows, and hello to your new beacon of 'I-can-see-what-I'm-doing' empowerment! Oh shit, its batteries are empty...");
                return;
            break;
            case "broom":
                if (!GameManager.conditionsMeet[GameManager.ConditionNames.hasFlashlight]) {return;}
                PickupItem(obj);
                comment("Ah, the mighty broom, truly the Gandalf of cleaning tools.");
                return;
            break;
        }

        // This List helds all Interactions beetwenn the world objects and the player
        if (!readBook && worldObject != "necroBook") {
            comment("Just some old thingamajigs.");    
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

    public static void StartAnimation(InteractableObject obj)
    {
        obj.StartAnimation();
    }

    public static void ChangeRoom(string room, int entrance)
    {
        switch (room) {
            case "attic":
                GameManager.camera.transform.position = new Vector3(0,25,-1);
                PlayerController.player.Warp(new Vector3(-6,1.2f,-3.5f));
                break;
            case "cellar":
                GameManager.camera.transform.position = new Vector3(-30,25,-1);
                PlayerController.player.Warp(new Vector3(-36.2f,1.2f,-0.5f));
                break;
        }
    }

}
