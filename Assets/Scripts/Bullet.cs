using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    
    RaycastHit m_HitInfo = new RaycastHit();
    Rigidbody rb;
    [SerializeField] float speed = 10.0f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray.origin, ray.direction, out m_HitInfo))
        {
            Vector3 direction = m_HitInfo.point - transform.position;
            rb.AddForce(direction  * speed * Time.deltaTime, ForceMode.Impulse);
        }
            
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Destroy(gameObject);
    }
}
