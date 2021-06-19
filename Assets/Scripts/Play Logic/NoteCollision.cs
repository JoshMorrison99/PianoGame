using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteCollision : MonoBehaviour
{
    public PlayLogic Logic;

    public detectorScript detector;

    private void Start()
    {
        detector = gameObject.GetComponentInChildren<detectorScript>();
    }
}
