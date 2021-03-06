using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health;
    Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(health == 0)
        {
            anim.SetTrigger("DeathTrigger");
            Invoke("DisableEnemy", 2f);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Bullet")
        {
            health--;
        }
    }
    
    void DisableEnemy()
    {
        gameObject.SetActive(false);
    }


}
