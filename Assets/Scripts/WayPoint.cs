using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoint : MonoBehaviour
{
    [SerializeField] List<GameObject> enemies;
    public bool wayPoint—ompleted;

    
    private void Update()
    {
        foreach(GameObject enemy in enemies)
        {
            if(enemy.activeSelf)
            {
                wayPoint—ompleted = false;
                break;
            }
            wayPoint—ompleted = true;
        }
        
  
    }
}
