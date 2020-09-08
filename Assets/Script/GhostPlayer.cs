using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostPlayer : MonoBehaviour
{
    List<Vector2> recordGhostPositions;

    public GhostReplay ghost;
    private bool startReplay = false;
    public bool startRecord = true;

    private void Start()
    {
        recordGhostPositions = new List<Vector2>();
    }


    public void StartReplay()
    {
        //membuat ghost baru
        GhostReplay newGhost = Instantiate(ghost);
        //simpan value?
        foreach (Vector2 x in recordGhostPositions)
        {
            newGhost.saveGhostPosition.Add(x);
        }
        newGhost.StartGhost();    // setActive Ghost    
    }

    private void FixedUpdate()
    {
        if(startRecord)
            RecordPositions();
    }

    private void RecordPositions()
    {
        recordGhostPositions.Add(transform.position);
    }


    public void StartRecord()
    {
        startRecord = true;
        ClearRecord();
    }

    private void ClearRecord()
    {
        recordGhostPositions.Clear();
    }
}
