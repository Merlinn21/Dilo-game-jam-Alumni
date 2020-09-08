using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostReplay : MonoBehaviour
{
    public List<Vector2> saveGhostPosition;
    private List<Vector2> ghostPosition;
    private List<Vector2> recordGhost;

    public Transform spawn;
    public bool startReplay = false;
    private bool record = true;

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

                recordGhost.Add(transform.position);
                
                ghostPosition.RemoveAt(0);
            }
        }
        else if(ghostPosition.Count == 0)
        {
            startReplay = false;
            ghostPosition = recordGhost;
            record = false;
            startReplay = true;
            
        }
    }

    private void Start()
    {
        ghostPosition = new List<Vector2>();
        recordGhost = new List<Vector2>();
        ghostPosition = saveGhostPosition;
    }

    public void StartGhost()
    {
        this.gameObject.SetActive(true);
        StartReplay();
    }

    
}
