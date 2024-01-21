using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    private NavMeshAgent agent;
    public static PlayerController player;
    private float animationLockTime=0;

    public float facingDirection=1;

    // Start is called before the first frame update
    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        player=this;
    }

    // Update is called once per frame
    void Update()
    {
        //
        // Handels general Animations like Moving and Standing
        //
        if (agent.velocity.x >0)
        {
            facingDirection=-1;
            transform.GetChild(0).localScale = Vector3.one - Vector3.right*2;
        }
        if (agent.velocity.x <0)
        {
            facingDirection=1;
            transform.GetChild(0).localScale = Vector3.one;
        }
        if (agent.velocity.magnitude>0)
        {
            GetComponentInChildren<Animator>().SetBool("isMoving", true);
        }
        else
        {
            GetComponentInChildren<Animator>().SetBool("isMoving", false);
        }
        if (GameManager.conditionsMeet[GameManager.ConditionNames.wearingRobe])
        {
            GetComponentInChildren<Animator>().SetBool("hasRobe", true);
        }

        //
        // Handels special Animations like Hitting, fishing
        //
        if (animationLockTime>0)
        {
            animationLockTime-=Time.deltaTime;
            return;
        }
        else
        {
            player.GetComponentInChildren<Animator>().SetBool("isHitting", false);
            player.GetComponentInChildren<Animator>().SetBool("isFishing", false);
            player.GetComponentInChildren<Animator>().SetBool("isPanicking", false);
        }

        //
        // Handeling Input for Movement
        //
        if (Input.GetMouseButtonUp(0))
        {
            if (EventSystem.current.IsPointerOverGameObject() || GameManager.gameState != 1)
            {
                return;
            }
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray,out hit))
            {
                agent.SetDestination(hit.point);
            }
        }
    }

    public void StopMovement()
    {
        Vector3 goal = new Vector3(transform.position.x, 1.2f, transform.position.z);
        agent.SetDestination(goal);
    }

    public void Warp(Vector3 goal)
    {
        agent.Warp(goal);
    }

    public void StartAnimation(string animationName, InteractableObject obj)
    {
        switch(animationName)
        {
            case "hitting":
                player.GetComponentInChildren<Animator>().SetBool("isHitting", true);
                player.animationLockTime=1;
                break;
            case "fishing":                
                Vector3 goal = new Vector3(obj.transform.position.x -0.8f, transform.position.y, obj.transform.position.z+0.5f);
                agent.SetDestination(goal);
                player.animationLockTime=4f;
                StartCoroutine(FishingDelay(goal));
                break;
            case "panic":
                player.GetComponentInChildren<Animator>().SetBool("isPanicking", true);
                player.animationLockTime=3;
                break;
        }
    }

    IEnumerator FishingDelay(Vector3 goal)
    {
        yield return new WaitForSeconds(1f);
        agent.Warp(goal);
        GetComponentInChildren<Animator>().SetBool("isFishing", true);
        facingDirection=-1;
        transform.GetChild(0).localScale = Vector3.one - Vector3.right*2;
    }


}
