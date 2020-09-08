using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

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
    private bool startPatrol = true;

    public Transform[] paths;
    private int index = 0;
    private bool indexBool = true;

    private void Update()
    {
        if (startPatrol)
        {
            startChase = false;
            Patrol();
        }

        if (startChase)
        {
            startPatrol = false;
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
    }

    public void StartShoot()
    {
        startShoot = true;
    }

    public void EndShoot()
    {
        startShoot = false;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!lockTarget)
        {
            if (collision.tag == "Ghost" || collision.tag == "Player")
            {
                startPatrol = false;
                SetTarget(collision.transform);
                lockTarget = true;
            }
        }   
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player" || collision.tag == "Ghost")
        {
            startChase = false;
            startPatrol = true;
            lockTarget = false;
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

    private void Patrol()
    {
        transform.position = Vector2.MoveTowards(transform.position, paths[index].position, speed * Time.deltaTime);
        if (Vector3.Distance(transform.position, paths[index].position) < 0.5f)
        {
            NextTarget();
        }
    }

    private void NextTarget()
    {
        if (indexBool)
            index++;
        else
            index--;

        if (index + 1 == paths.Length)
            indexBool = false;
        if (index == 0)
            indexBool = true;

    }
}
