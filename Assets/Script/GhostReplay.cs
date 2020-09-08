using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostReplay : MonoBehaviour
{
    public List<Vector2> saveGhostPosition;
    private List<Vector2> ghostPosition;

    public Transform spawn;
    bool startReplay = false;

    public void StartReplay()
    {
        ghostPosition = saveGhostPosition;
        startReplay = true;
    }

    private void FixedUpdate()
    {
        if (ghostPosition.Count > 0)
        {
            if (startReplay)
            {
                transform.position = ghostPosition[0];
                ghostPosition.RemoveAt(0);
            }
            else
            {
                startReplay = false;
            }
        }

    }

    public void Respawn()
    {
        transform.position = spawn.position;
    }

    private void Start()
    {
        ghostPosition = saveGhostPosition;
    }

    public void StartGhost()
    {
        this.gameObject.SetActive(true);
    }

    
}
