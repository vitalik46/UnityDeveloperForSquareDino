using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GameManager : MonoBehaviour
{
    [SerializeField] float distance = 0.5f;
    [SerializeField] GameObject startBackground;
    [SerializeField] GameObject[] wayPoints;
    GameObject player;
    [SerializeField]int currentWayPoint = 0;
    NavMeshAgent agent;
    public bool startGame;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        agent = player.GetComponent<NavMeshAgent>();
        player.transform.position = wayPoints[currentWayPoint].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.touchCount > 0 || Input.GetMouseButtonDown(0))
        {
            startBackground.SetActive(false);
            currentWayPoint = 1;
            agent.SetDestination(wayPoints[currentWayPoint].transform.position);

            if(Vector3.Distance(agent.transform.position, wayPoints[currentWayPoint].transform.position) < distance)
            {
                startGame = true;
            }
        }
        
        if (startGame)
        {

            if (currentWayPoint >= wayPoints.Length)
            {
                currentWayPoint = 0;
            }

            if (wayPoints[currentWayPoint].GetComponent<WayPoint>().wayPoint—ompleted)
            {
                currentWayPoint++;
                agent.SetDestination(wayPoints[currentWayPoint].transform.position);
 
            }
        }
    }
   

}
