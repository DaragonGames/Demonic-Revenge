using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cursor : MonoBehaviour
{
    public Sprite[] sprites;

    // Update is called once per frame
    void Update()
    {
        Vector3 cameraPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(cameraPosition.x, 23, cameraPosition.z);
        
        Sprite usedSprite= InventoryDisplay.main.GetSpriteByName(Inventory.heldItem);
        if (usedSprite == null)
        {
            usedSprite=sprites[0];
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit raycastHit, float.MaxValue))
            {                
                if (raycastHit.transform.GetComponent<InspectableObject>() != null)
                {
                    usedSprite=sprites[1];
                }   
                if (raycastHit.transform.GetComponent<InteractableObject>() != null)
                {
                    usedSprite=sprites[2];
                }              
            }
        }
        GetComponent<SpriteRenderer>().sprite = usedSprite;
    }
}
