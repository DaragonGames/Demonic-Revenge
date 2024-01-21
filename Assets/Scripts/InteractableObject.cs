using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.EventSystems;

public class InteractableObject : MonoBehaviour
{
    public string name;
    public GameObject alternativePrefab;
    private bool selected;
    public float reach=1;
    private float animationTimer;

    void Update()
    {  
        if (animationTimer < 0.2f)
        {
            animationTimer+=Time.deltaTime;
        }
        else
        {
            Animator animator = GetComponentInChildren<Animator>();
            if (animator != null)
            {
                animator.SetBool("AnimationStart", false);
            }
        }
        if (Input.GetMouseButtonDown(0))
        {
            if (EventSystem.current.IsPointerOverGameObject() || GameManager.gameState != 1)
            {
                return;
            }
            selected=false;
        }
        if (selected)
        {
            Vector3 playerPositions = new Vector3(PlayerController.player.transform.position.x,0,PlayerController.player.transform.position.z);
            Vector3 thisObjectPositions = new Vector3(transform.position.x,0,transform.position.z);
            float distance= Vector3.Distance(playerPositions, thisObjectPositions);
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
            if (EventSystem.current.IsPointerOverGameObject() || GameManager.gameState != 1)
            {
                return;
            }
            selected=true;
        }
    }

    public void StartAnimation() {
        GetComponentInChildren<Animator>().SetBool("AnimationStart", true);
        animationTimer=0;
    }
}
