using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health;
    public bool dead;
    //GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        //gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(health == 0)
        {
            gameObject.GetComponent<Animator>().SetTrigger("DeathTrigger");
            //Destroy(gameObject, 3f);
            dead = true;
            Invoke("DisableEnemy", 3f);
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
