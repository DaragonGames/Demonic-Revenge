using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryDisplay : MonoBehaviour
{
    public static InventoryDisplay main;
    public Sprite[] possibleItems;

    void Start()
    {
        main = this;
    }

   
    public void UpdateDisplayedInventory()
    {
        for (int i=0; i<Inventory.maxItems;i++)
        {
            transform.GetChild(i).GetComponent<InventorySlot>().UpdateDisplay(Inventory.GetItemName(i),i);
        }
    } 

    public Sprite GetSpriteByName(string name)
    {
        switch (name) {
            case "bat":
                return possibleItems[0];
            case "candle":
                return possibleItems[1];
            case "chalk":
                return possibleItems[2];
            case "dagger":
                return possibleItems[3];
            case "lighter":
                return possibleItems[4];
            case "magnet":
                return possibleItems[5];
            case "magnetrope":
                return possibleItems[6];
            case "redCandle":
                return possibleItems[7];
            case "rope":
                return possibleItems[8];
            case "screwdriver":
                return possibleItems[9];
            case "fakeSkull":
                return possibleItems[10];
            case "batterie":
                return possibleItems[11];
            case "flashLightEmpty":
                return possibleItems[12];
            case "chestKey":
                return possibleItems[13];
            case "broom":
                return possibleItems[14];
            case "soggyMatches":
                return possibleItems[15];
            case "googlyEyes":
                return possibleItems[16];
            case "gameboy":
                return possibleItems[17];
            default:
                return null;
        }
    }
}
