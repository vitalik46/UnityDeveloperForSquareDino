using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GameManager : MonoBehaviour
{
    public GameObject startBackground;
    public GameObject[] wayPoints;
    GameObject player;
    [SerializeField]int currentWayPoint = 0;
    NavMeshAgent agent;
    public bool startGame;
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

        if (Input.GetKey(KeyCode.Space) || Input.touchCount > 0 || Input.GetMouseButtonDown(0))
        {
            startBackground.SetActive(false);
            startGame = true;
            currentWayPoint = 1;
            
            agent.destination = wayPoints[currentWayPoint].transform.position;
            
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
