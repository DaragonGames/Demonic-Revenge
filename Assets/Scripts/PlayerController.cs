using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    private NavMeshAgent agent;
    public static PlayerController player;
    public Vector3 lastPosition;

    // Start is called before the first frame update
    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        player=this;
        lastPosition=transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (agent.velocity.magnitude>0)
        {
            GetComponentInChildren<Animator>().SetBool("isMoving", true);
        }
        else
        {
            GetComponentInChildren<Animator>().SetBool("isMoving", false);
        }
        if (agent.velocity.x >0)
        {
            transform.GetChild(0).localScale = Vector3.one - Vector3.right*2;
        }
        if (agent.velocity.x <0)
        {
            transform.GetChild(0).localScale = Vector3.one;
        }
        if (GameManager.conditionsMeet[GameManager.ConditionNames.wearingRobe])
        {
            GetComponentInChildren<Animator>().SetBool("hasRobe", true);
        }

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
        Vector3 goal = new Vector3(transform.position.x, 0.5f, transform.position.z);
        agent.SetDestination(goal);
    }
}
