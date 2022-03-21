using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GameManager : MonoBehaviour
{
    
    public GameObject[] wayPoints;
    GameObject player;
    [SerializeField]int currentWayPoint = 0;
    NavMeshAgent agent;
    //WayPoint wp;
    [SerializeField] bool startGame;
    Animator animatorPlayer;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        agent = player.GetComponent<NavMeshAgent>();
        player.transform.position = wayPoints[currentWayPoint].transform.position;
        animatorPlayer = player.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.Space) || Input.touchCount > 0)
        {
            startGame = true;
            currentWayPoint = 1;
            
            agent.destination = wayPoints[currentWayPoint].transform.position;
            //animatorPlayer.SetTrigger("Run");
            //agent.SetDestination(wayPoints[currentWayPoint].transform.position);
            /*
            if (Vector3.Distance(player.transform.position, wayPoints[currentWayPoint].transform.position) > 0)
            {
                agent.SetDestination(wayPoints[currentWayPoint].transform.position);
                animatorPlayer.SetBool("Run", true);
            }
            else
            {
                animatorPlayer.SetBool("Run", false);
            }
            */
            //if(Vector3.MoveTowards(agent.transform.position, wayPoints[currentWayPoint].transform.position)) > 0)
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
                //agent.destination = wayPoints[currentWayPoint].transform.position;
                
                
                    agent.SetDestination(wayPoints[currentWayPoint].transform.position);
                
                
                
            }

        }
       


    }
    
    
}
