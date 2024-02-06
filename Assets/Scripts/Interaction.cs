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
                return;
                break;
            case "necroBook":
                UnlockCondition(GameManager.ConditionNames.readBook);
                NecroBook.Read();
                return;
            break;
            case "curtains":
                if (!readBook) {return;}
                if (Inventory.heldItem=="dagger") 
                {
                    UnlockCondition(GameManager.ConditionNames.wearingRobe);
                    UseItem();
                    TransformOriginObject(obj);
                    comment("Nobody needs curtains in an attic. I’m a cultist now, baby!"); 
                    return; 
                }
                if (Inventory.heldItem=="bat")
                {
                    comment("I'm not a hooligan.");  
                    return;
                } 
            break;
            case "drain": 
                if (!readBook) {return;}
                if (Inventory.heldItem=="rope")
                {
                    comment("Right, I’m just gonna abseil into this here tiny hole. Not!");   
                    return; 
                }
                if (Inventory.heldItem=="magnet")
                {
                    comment("The grate is not magnetic.");   
                    return; 
                }
                if (Inventory.heldItem=="magnetrope") 
                {                    
                    PlayerController.player.StartAnimation("fishing", obj);
                    UseItem();
                    GainItem("lighter");
                    //comment("I don’t smoke, but these lighters are fun to use.");   
                    return;                                                  
                }
            break;
            case "paintbucket":
                if (!readBook) {return;}
                if (Inventory.heldItem=="bat")
                {
                    PlayerController.player.StartAnimation("hitting", obj);
                    return;
                }  
                if (Inventory.heldItem=="screwdriver") 
                {
                    TransformOriginObject(obj);
                    UseItem();
                    comment("Yes, the bucket is open. I'm a genius, I could even solve a double labyrinth!"); 
                    return;
                }    
                comment("Even if I wanted to use the paint for something, the bucket is rusted shut.");  
                return;                    
            break;
            case "openPaintbucket":
                if (!readBook) {return;}
                if (Inventory.heldItem=="candle") 
                {
                    TransformItem("redCandle");
                    comment("Now I don’t have red candles. —- Now I do.");  
                    return;
                }
                if (Inventory.heldItem=="bat")
                {
                    PlayerController.player.StartAnimation("hitting", obj);
                    return;
                } 
                if (Inventory.heldItem=="")
                {
                    comment("No way am I gonna stain this marvelous PRIMARK/SHEIN combo just to have red clothes.");  
                    return;
                }
            break;
            case "chest":
                if (!readBook) {return;}
                if (Inventory.heldItem=="bat")
                {
                    PlayerController.player.StartAnimation("hitting", obj);
                    return;
                }   
                if (Inventory.heldItem=="chestKey") 
                {
                    TransformOriginObject(obj);
                    TransformItem("bat");    
                    comment("Well, well, well, if it isn’t my old baseball bat. I used to love BONKing stuff.");    
                    return;                 
                }
                else{
                    comment("It's locked, but at least it's not a mimic.");
                    return;
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
                    return;
                }   
            break;
            case "fakeSkeleton":
                if (!readBook) {return;}
                if (Inventory.heldItem=="bat") 
                {
                    PlayerController.player.StartAnimation("hitting", obj);
                    TransformOriginObject(obj);
                    TransformItem("fakeSkull");
                    comment("2B or not 2B...");
                    return;
                }
            break;
            case "jackInTheBox":
                if (!GameManager.conditionsMeet[GameManager.ConditionNames.hasFlashlight]) {comment("I'm not touching the darkness. I left my emo phase back in that highschool locker.");return;}
                if (Inventory.heldItem=="bat")
                {
                    PlayerController.player.StartAnimation("hitting", obj);
                    return;
                }
                else
                {
                    PlayerController.player.StartAnimation("panic", obj);
                    StartAnimation(obj);
                    return;
                }                
            break;
            case "chestKey":
                if (!readBook) {return;}
                if (!GameManager.conditionsMeet[GameManager.ConditionNames.hasFlashlight]) {comment("I'm not touching the darkness. I left my emo phase back in that highschool locker.");return;}
                if (Inventory.heldItem == "broom")
                {
                    UseItem();
                    PickupItem(obj);
                    comment("I hope I did not make that spider my mortal enemy.");
                    return;
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
                    return;                                           
                }
            break;
            case "pentagram":
                if (!readBook) {return;}
                if (Inventory.heldItem=="redCandle") 
                {
                    TransformOriginObject(obj);
                    UseItem();
                    return;
                }
                if (Inventory.heldItem=="candle")
                {
                    comment("Wait, the book said I need candles in the color of blood. It’s gotta look authentic!");    
                    return;
                }
            break;
            case "unlitPentagram":
                if (!readBook) {return;}
                if (Inventory.heldItem=="lighter") 
                {
                    TransformOriginObject(obj);
                    comment("AND THUS I AM BECOME PROMETHEUS!");
                    UseItem();
                    return;
                }
                if (Inventory.heldItem=="soggyMatches")
                {
                    comment("Yeah no, these matches are no good anymore. They’re all moldy and soggy.");
                    return;
                }
            break;
            case "litPentagram":
                if (!readBook) {return;}
                if (!GameManager.conditionsMeet[GameManager.ConditionNames.wearingRobe]) {return;}
                if (Inventory.heldItem=="fakeSkull") 
                {
                    UseItem();
                    Death.Now();
                    return;
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
                if (!GameManager.conditionsMeet[GameManager.ConditionNames.hasFlashlight]) {comment("I'm not touching the darkness. I left my emo phase back in that highschool locker.");return;}
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
                if (!GameManager.conditionsMeet[GameManager.ConditionNames.hasFlashlight]) {comment("I'm not touching the darkness. I left my emo phase back in that highschool locker.");return;}
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
                comment("Ah, a flashlight! My future's looking bright – or at least I'll have a better-lit present. Goodbye shadows, hello newfound 'I-can-see-what-I'm-doing' empowerment!");
                return;
            break;
            case "broom":
                if (!GameManager.conditionsMeet[GameManager.ConditionNames.hasFlashlight]) {comment("I'm not touching the darkness. I left my emo phase back in that highschool locker.");return;}
                PickupItem(obj);
                comment("Ah, the mighty broom, truly the Gandalf of cleaning tools.");
                return;
            break;
            case "soggyMatches":
                if (!GameManager.conditionsMeet[GameManager.ConditionNames.hasFlashlight]) {comment("I'm not touching the darkness. I left my emo phase back in that highschool locker.");return;}
                PickupItem(obj);                
                comment("Oof, they’re all moldy and soggy.");
                return;
            break;
            case "googlyEyes":
                if (!GameManager.conditionsMeet[GameManager.ConditionNames.hasFlashlight]) {comment("I'm not touching the darkness. I left my emo phase back in that highschool locker.");return;}
                PickupItem(obj);                
                comment("It’s a googly eye revoluuuution!");
                return;
            break;
            case "gameboy":
                if (!GameManager.conditionsMeet[GameManager.ConditionNames.hasFlashlight]) {comment("I'm not touching the darkness. I left my emo phase back in that highschool locker.");return;}
                PickupItem(obj);                
                comment("This is like.. an antique switch? My god, it’s bulky.");
                return;
            break;
        }

        // This List helds all Interactions beetwenn the world objects and the player
        if (!readBook && worldObject != "necroBook") {
            comment("Just some old thingamajigs.");   
            return; 
        }
        if (!GameManager.conditionsMeet[GameManager.ConditionNames.hasFlashlight] && PlayerController.player.transform.position.x >= -20) {
            if (Inventory.heldItem=="")
            {
                comment("Can't really do much here with my bare hands.");
            }
            else
            {
                stupidMove();
            }
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
        UseItem();
        GainItem(itemName);
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

    public static void stupidMove()
    {
        string[] lines = {"I’m stupid, but not that stupid.", 
            "That obviously won’t work, duh.", 
            "MacGuyver once made a submarine with just a paperclip and some gum, but I’m no MacGuyver.",
            "Right, I’ll just combine this and.. no.",
            "Not everything goes in the square hole.",
            "Why would I do this again?",
            "In Deponia this would work, but this is not Deponia."
        };
        comment(lines[(int)(lines.Length*Random.value)]);
    }

}
