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
            case "screwdriver":
                return possibleItems[0];
            default:
                return null;
        }
    }
}
