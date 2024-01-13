using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cursor : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        Vector3 cameraPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(cameraPosition.x, 25, cameraPosition.z);
        
        Sprite heldItemSprite= InventoryDisplay.main.GetSpriteByName(Inventory.heldItem);
        GetComponent<SpriteRenderer>().sprite = heldItemSprite;
    }
}
