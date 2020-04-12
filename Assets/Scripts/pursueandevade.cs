using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class pursueandevade : MonoBehaviour
{
    public Camera cam;
    public NavMeshAgent agentPrefab;
    public Transform Agent1EmptyGO;
    private float moveSpeed = 0.1f;
    public Transform Agent2EmptyGO;
    NavMeshAgent agent1;
    NavMeshAgent agent2;
   
    
    void Start()
    {
        agent1 = (NavMeshAgent) Instantiate(agentPrefab, Agent1EmptyGO.position, Quaternion.identity);
        var agentScript = agent1.GetComponent<Agent>();
            agentScript.radius = 0.3f;
            agentScript.mass = 1;
            agentScript.perceptionRadius = 3;

        agent2 = (NavMeshAgent) Instantiate(agentPrefab, Agent2EmptyGO.position , Quaternion.identity);
        var agentScript1 = agent2.GetComponent<Agent>();
            agentScript1.radius = 0.3f;
            agentScript1.mass = 1;
            agentScript1.perceptionRadius = 3;
      
        
    }
    
    void Update()
    {
        if(Input.GetMouseButtonDown(0)){
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit)){
                agent2.SetDestination(hit.point);
            }
        }
       
       agent1.SetDestination(agent2.transform.position);
    }
}
