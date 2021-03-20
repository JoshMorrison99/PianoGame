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

    private void Update()
    {
        if (this.GetComponent<Note_Mine>().isPressed && detector.overlapping == false)
        {
            this.GetComponent<Note_Mine>().concurrentPress = false;
        }
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (this.GetComponent<Note_Mine>().concurrentPress)
        {
            // Effects Spawn
            ParticleSystem emit = gameObject.GetComponentInChildren<ParticleSystem>();
            emit.Play();

            // Change color of note
            //collision.gameObject.GetComponent<SpriteRenderer>().color = Color.blue;

            if (detector.intersecting)
            {
                IncrementNotesHit();
                detector.intersecting = false;
            }
        }

        if (this.GetComponent<Note_Mine>().isPressed && detector.overlapping && this.GetComponent<Note_Mine>().concurrentPress)
        {
            // Increment score
            Logic.currentScore += 1;
        }

    }

    void IncrementNotesHit()
    {
       
        // Note successfully hit
        Logic.numNotesHit += 1;

        // Increment exp
        PersistentData.data.exp += 1;

        
    }
}
