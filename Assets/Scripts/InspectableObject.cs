using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InspectableObject : MonoBehaviour
{
    public string line="Yeah that sounds bad.";

    void OnMouseOver()
    {
        if (!GameManager.conditionsMeet[GameManager.ConditionNames.hasFlashlight] && PlayerController.player.transform.position.x <= -20)
        {
            CommentController.commentor.Comment("I can't hear anything, it's too dark!");
            return;
        }
        if (Input.GetMouseButtonUp(1) && GameManager.gameState == 1)
        {
            CommentController.commentor.Comment(line);
        }
    }
}
