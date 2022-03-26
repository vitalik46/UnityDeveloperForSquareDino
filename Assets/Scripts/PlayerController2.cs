using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2 : MonoBehaviour
{
    public UnityEngine.AI.NavMeshAgent agent;
    //public ThirdPersonCharacter character;

    public GameObject bulletPrefab;
    public Transform spawner;

    Quaternion rotation;
    Vector3 direction;
    bool startGame;
    public float speedRotation;
    RaycastHit m_HitInfo = new RaycastHit();
    RaycastHit m_HitInfo2 = new RaycastHit();
    //[SerializeField] float force;
    public float angleInDegrees;
    float g = Physics.gravity.y;
    // Start is called before the first frame update
    void Start()
    {
        agent.updateRotation = false;
    }

    // Update is called once per frame
    void Update()
    {
        spawner.localEulerAngles = new Vector3(-angleInDegrees, 0f, 0f);

        /*
        if (agent.remainingDistance > agent.stoppingDistance)
        {
            character.Move(agent.desiredVelocity, false, false);
        }
        else
        {
            character.Move(Vector3.zero, false, false);
        }
        */
        if (Input.GetMouseButtonDown(0))
        {
            //startGame = true;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray.origin, ray.direction, out m_HitInfo))
            {
                m_HitInfo2 = m_HitInfo;
                Shot(m_HitInfo2);
            }
        }
        /*
        if (startGame)
        {
            direction = m_HitInfo2.point - transform.position;
            rotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Lerp(transform.rotation, rotation, speedRotation * Time.deltaTime);


            if (Input.GetKeyDown(KeyCode.Space))
            {
                Shot(m_HitInfo2);
            }
        }
        */
    }
    void Shot(RaycastHit hit)
    {
        Vector3 fromTo = hit.point - transform.position;
        Vector3 fromToXZ = new Vector3(fromTo.x, 0f, fromTo.z);

        transform.rotation = Quaternion.LookRotation(fromToXZ, Vector3.up);

        float x = fromToXZ.magnitude;
        float y = fromTo.y;

        float angleInRadians = angleInDegrees * Mathf.PI / 180;

        float v2 = (g * x * x) / (2 * (y - Mathf.Tan(angleInRadians) * x) * Mathf.Pow(Mathf.Cos(angleInRadians), 2));
        float v = Mathf.Sqrt(v2);

        //GameObject newBullet = Instantiate(bulletPrefab, spawner.transform.position, Quaternion.identity);
        GameObject newBullet = BulletPool.SharedInstance.GetPooledObject();
        if (newBullet != null)
        {
            newBullet.transform.position = spawner.transform.position;
            //newBullet.transform.rotation = spawner.transform.rotation;


            newBullet.SetActive(true);
        }
        newBullet.GetComponent<Rigidbody>().velocity = spawner.transform.forward * v;
    }
}
