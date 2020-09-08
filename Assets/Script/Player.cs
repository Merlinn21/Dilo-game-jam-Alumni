using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Transform SpawnLocation;
    public GhostPlayer gp;

    public void PlayerRespawn()
    {
        this.gameObject.transform.position = SpawnLocation.position;
        gp.StartReplay();
        gp.StartRecord();

    }
}
