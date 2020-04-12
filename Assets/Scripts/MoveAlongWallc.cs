using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveAlongWallc : MonoBehaviour
{
    public NavMeshAgent aprefab;
    NavMeshAgent agent;
    public Transform MWGO;


    void Start()
    {
        agent = (NavMeshAgent) Instantiate (aprefab, MWGO.position, Quaternion.identity);
        var agentScript = agent.GetComponent<Agent>();
            agentScript.radius = 0.3f;
            agentScript.mass = 1;
            agentScript.perceptionRadius = 3;
        
    }

    
    void Update()
    {
        FindClosestWall();
    }

    void FindClosestWall(){
        float disttoclosestwall = Mathf.Infinity;
        Wall closestwall = null;
        Wall[] allwalls = GameObject.FindObjectsOfType<Wall>();

        foreach (Wall cwall in allwalls){
            float disttowall = (cwall.transform.position - agent.transform.position).sqrMagnitude;
            if(disttowall < disttoclosestwall){
                disttoclosestwall = disttowall;
                closestwall = cwall;
				Debug.Log(cwall);

            }
			
        }
		
		agent.SetDestination(closestwall.transform.position);

        


    }
}
