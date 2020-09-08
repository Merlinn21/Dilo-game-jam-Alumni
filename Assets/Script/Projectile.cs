using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;

    private Transform player;
    private Vector2 target;

    public void SetTarget(Transform _player)
    {
        player = _player;
        target = new Vector2(player.position.x, player.position.y);
    }

    public void Activate()
    {
        this.gameObject.SetActive(true);
    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);

        if (transform.position.x == target.x && transform.position.y == target.y)
            DestroyProjectile();
    }

    private void DestroyProjectile()
    {
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            DestroyProjectile();
            Player player = collision.gameObject.GetComponent<Player>();
            GhostPlayer gp = collision.gameObject.GetComponent<GhostPlayer>();
            gp.startRecord = false;
            player.PlayerRespawn();
        }

        if(collision.tag == "Ghost")
        {
            DestroyProjectile();
            GhostReplay gr = collision.gameObject.GetComponent<GhostReplay>();
            gr.Respawn();
            gr.StartReplay();
        }
    }
}
