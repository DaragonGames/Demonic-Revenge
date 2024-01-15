using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InspectableObject : MonoBehaviour
{
    public string line="Yeah that sounds bad.";

    void OnMouseOver()
    {
        if (Input.GetMouseButtonUp(1) && GameManager.gameState == 1)
        {
            CommentController.commentor.Comment(line);
        }
    }
}
