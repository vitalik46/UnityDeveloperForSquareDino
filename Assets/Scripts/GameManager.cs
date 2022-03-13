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
    //[SerializeField] bool startGame;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        agent = player.GetComponent<NavMeshAgent>();
        player.transform.position = wayPoints[currentWayPoint].transform.position;
        //wp = wayPoints[currentWayPoint].GetComponent<WayPoint>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.Space))
        {
            agent.destination = wayPoints[currentWayPoint++].transform.position;
        }
    }
    
    
}
