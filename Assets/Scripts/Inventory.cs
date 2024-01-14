using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Inventory
{
    public static int maxItems = 8;
    private static string[] items = new string[maxItems];
    public static string heldItem;

    public static void SetItems()
    {
        Array.Fill<string>(items, "");
    }

    public static void addItem(string item) {
        for (int i=0; i<maxItems;i++)
        {
            if (items[i]=="")
            {
                items[i]=item;
                break;
            }
        }
        InventoryDisplay.main.UpdateDisplayedInventory();
    }

    public static void changeItemPosition(string item, int id)
    {
        if (items[id]=="")
        {
            removeItem(item);
            items[id]=item;
            InventoryDisplay.main.UpdateDisplayedInventory();
        }
    }

    public static void removeItem(string item)
    {
        for (int i=0; i<maxItems;i++)
        {
            if (items[i]==item)
            {
                items[i]="";
                break;
            }
        }
        InventoryDisplay.main.UpdateDisplayedInventory();
    }

    public static string GetItemName(int id)
    {
        return items[id];
    }

    public static void crafting(string item, string item2)
    {
        string result = checkRecepies(item, item2);
        if (result=="")
        {
            result = checkRecepies(item2, item);
        }
        if (result=="")
        {
            return;
        }
        removeItem(item);
        removeItem(item2);
        addItem(result);
    }

    public static string checkRecepies(string item, string item2)
    {
        switch (item) {
            case "magnet":
                if (item2=="rope")
                {
                    heldItem="";
                    CommentController.commentor.Comment("Rope... magnet... Rope magnet!!");
                    return "magnetrope";                    
                }
                break;
        }
        return "";
    }

}
