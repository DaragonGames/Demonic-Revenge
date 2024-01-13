using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public string slotItem="";
    public Sprite[] frames;
    private int position=-1;

    public void UpdateDisplay(string item, int position)
    {
        slotItem=item;
        this.position=position;
        // Update Frame
        if (Inventory.heldItem==slotItem && slotItem!="")
        {
            GetComponent<SpriteRenderer>().sprite=frames[1];
        }
        else
        {
            GetComponent<SpriteRenderer>().sprite=frames[0];
        }
        // Update displayed Item
        transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = InventoryDisplay.main.GetSpriteByName(slotItem);
    }

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (Inventory.heldItem==slotItem)
            {
                Inventory.heldItem="";
                InventoryDisplay.main.UpdateDisplayedInventory();
            }
            else
            {
                if (Inventory.heldItem=="")
                {
                    Inventory.heldItem=slotItem;
                    InventoryDisplay.main.UpdateDisplayedInventory();
                    return;
                }
                if (slotItem=="")
                {
                    Inventory.changeItemPosition(Inventory.heldItem,position);
                    Inventory.heldItem="";
                    InventoryDisplay.main.UpdateDisplayedInventory();
                return;
                }
                Inventory.crafting(slotItem, Inventory.heldItem);
            }        
        }
    }
}
