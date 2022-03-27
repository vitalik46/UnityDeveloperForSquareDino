using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityStandardAssets.Characters.ThirdPerson;

public class PlayerController : MonoBehaviour
{
    GameManager gameManager;
    [SerializeField] NavMeshAgent agent;
    [SerializeField] ThirdPersonCharacter character;

    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Transform spawner;

    [SerializeField] float speedRotation;
    RaycastHit m_HitInfo = new RaycastHit();
    RaycastHit m_HitInfo2 = new RaycastHit();
    [SerializeField] float angleInDegrees;
    float g = Physics.gravity.y;
    float v;
    float v2;
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    void Update()
    {
        spawner.localEulerAngles = new Vector3(-angleInDegrees, 0f, 0f);

        if (gameManager.startGame)
        {
            if (agent.remainingDistance > agent.stoppingDistance)
            {
                character.Move(agent.desiredVelocity, false, false);
            }
            else
            {
                if (Input.GetMouseButtonDown(0))
                {
                    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                    if (Physics.Raycast(ray.origin, ray.direction, out m_HitInfo))
                    {
                            m_HitInfo2 = m_HitInfo;
                            Shot(m_HitInfo2);
                    }
                }
                character.Move(Vector3.zero, false, false);
            }
        }
        else
        {
            if (agent.remainingDistance > agent.stoppingDistance)
            {
                character.Move(agent.desiredVelocity, false, false);
            }
            else
            {
                character.Move(Vector3.zero, false, false);
            }
        }
            

        
    }
    //Function shot
    void Shot(RaycastHit hit)
    {
        Vector3 fromTo = hit.point - transform.position;
        Vector3 fromToXZ = new Vector3(fromTo.x, 0f, fromTo.z);

        transform.rotation = Quaternion.LookRotation(fromToXZ, Vector3.up);

        float x = fromToXZ.magnitude;
        float y = fromTo.y;

        float angleInRadians = angleInDegrees * Mathf.PI / 180;

        v2 = (g * x * x) / (2 * (y - Mathf.Tan(angleInRadians) * x) * Mathf.Pow(Mathf.Cos(angleInRadians), 2));
        
        if(v2 > 0)
        {
            v = Mathf.Sqrt(v2);
            GameObject newBullet = BulletPool.SharedInstance.GetPooledObject();
            if (newBullet != null)
            {
                newBullet.transform.position = spawner.transform.position;
                newBullet.SetActive(true);
            }
            newBullet.GetComponent<Rigidbody>().velocity = spawner.transform.forward * v;
        }
        
    }
}