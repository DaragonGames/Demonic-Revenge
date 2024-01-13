using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InteractableObject : MonoBehaviour
{
    public string name;
    public GameObject alternativePrefab;
    private bool selected;
    private float reach=1;

    void Update()
    {  
        if (Input.GetMouseButtonDown(0))
        {
            selected=false;
        }
        if (selected)
        {
            float distance= Vector3.Distance(transform.position, PlayerController.player.transform.position);
            if (distance <reach)
            {
                PlayerController.player.StopMovement();
                Interaction.TryToInteract(this);
                selected=false;
                Inventory.heldItem="";
                InventoryDisplay.main.UpdateDisplayedInventory();
            }
        }
    }

    void OnMouseOver()
    {
        if (Input.GetMouseButtonUp(0))
        {
            selected=true;
        }
    }
}
