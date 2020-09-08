using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetect : MonoBehaviour
{
    public Enemy enemy;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player" || collision.tag == "Ghost")
        {
            enemy.StartShoot();
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Ghost")
        {
            enemy.StartShoot();
            return;
        }
        if(collision.tag == "Player")
        {
            enemy.StartShoot();
        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player" || collision.tag == "Ghost")
        {
            enemy.EndShoot();
        }
    }

}
