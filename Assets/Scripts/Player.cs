using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    public GameObject bulletPrefab;
    RaycastHit m_HitInfo = new RaycastHit();
    [SerializeField] float speedRotate = 10.0f;
    [SerializeField] GameObject gun;
    public NavMeshAgent agent;
    
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.DrawRay(gun.transform.position, Input.mousePosition.normalized, Color.grey);
        if (Input.GetMouseButtonDown(0) && !Input.GetKey(KeyCode.LeftShift))
        {
            
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            
            //if (Physics.Raycast(ray.origin, ray.direction, out m_HitInfo))
            if (Physics.Raycast(transform.position, ray.direction, out m_HitInfo))
            {

                agent.transform.LookAt(m_HitInfo.point);
                Instantiate(bulletPrefab, gun.transform.position, Quaternion.LookRotation(m_HitInfo.point));
            }
            
        }
        
    }

    
}
