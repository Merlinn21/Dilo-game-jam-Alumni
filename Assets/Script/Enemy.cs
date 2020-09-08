using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 3f;
    public float stoppingDistance = 5f;
    private float timeBtwShots;
    public float startTimeBtwShots;

    public Projectile projectile;
    private Projectile newProjectile;
    private Transform target;

    private bool startChase = false;
    private bool startShoot = false;
    private bool lockTarget = false;

    private void Update()
    {
        if (startChase)
        {
            if (Vector2.Distance(transform.position, target.position) > stoppingDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
            }
        }

        if(startShoot)
            Shoot();
    }

    public void SetTarget(Transform _target)
    {
        target = _target;
        startChase = true;
        startShoot = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Ghost")
        {
            SetTarget(collision.transform);
            lockTarget = true;
        }

        if(collision.tag == "Player")
        {
            SetTarget(collision.transform);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player" || collision.tag == "Ghost")
        {
            startChase = false;
            startShoot = false;
        }
    }

    private void Shoot()
    {
        if (timeBtwShots <= 0)
        {
            newProjectile = Instantiate(projectile,transform.position,Quaternion.identity);
            newProjectile.Activate();
            newProjectile.SetTarget(target);
            
            timeBtwShots = startTimeBtwShots;
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }
    }
}
