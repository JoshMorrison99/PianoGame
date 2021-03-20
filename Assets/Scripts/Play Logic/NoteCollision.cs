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

    /*private void Update()
    {
        if (this.GetComponent<Note_Mine>().isPressed && detector.overlapScore == false) // Stops the user from holding down the key to hit all the notes
        {
            this.GetComponent<Note_Mine>().initialPress = false;
        }
    }*/

    private void OnTriggerStay2D(Collider2D collision)
    {

        

        /*if (this.GetComponent<Note_Mine>().initialPress && detector.overlapNote) // Make it so it only updates 1 point
        {


            *//*if (collision.gameObject.tag == "Note") // Get the UID when the user hit the note
            {

                this.GetComponent<Note_Mine>().initalPressID = collision.GetComponentInParent<Note_Falling>().uid;
            }*//*

            if ( this.GetComponent<Note_Mine>().noteName == collision.GetComponentInParent<Note_Falling>().noteName) // makes it so the user cannot hit a note correctly and then hold down the note to hit additional notes and stops the user from being able to hit 2 notes at a time becasue of overlapping UI such as A and A#. Since they are so close together, the user could hit A and also hit A#. This stops that from happeninng by making sure the note names are the same.
            {

                IncrementNotesHit();

                // Effects Spawn
                ParticleSystem emit = gameObject.GetComponentInChildren<ParticleSystem>();
                emit.Play();

                this.GetComponent<Note_Mine>().initialPress = false;
                detector.overlapNote = false;

            }
            
        }
        

        if (this.GetComponent<Note_Mine>().initialPress && detector.overlapScore)
        {

            *//*if (collision.gameObject.tag == "Note") // Get the UID when the user hit the note
            {

                this.GetComponent<Note_Mine>().initalPressID = collision.GetComponentInParent<Note_Falling>().uid;
            }*//*

            if ( this.GetComponent<Note_Mine>().noteName == collision.GetComponentInParent<Note_Falling>().noteName) // makes it so the user cannot hit a note correctly and then hold down the note to hit additional notes and stops the user from being able to hit 2 notes at a time becasue of overlapping UI such as A and A#. Since they are so close together, the user could hit A and also hit A#. This stops that from happeninng by making sure the note names are the same.
            {
                // Increment score
                Logic.currentScore += 1;
            }
        }*/

    }

    void IncrementNotesHit()
    {
        
        
        

        // Note successfully hit
        Logic.numNotesHit += 1;

        // Increment exp
        PersistentData.data.exp += 1;

        
    }
}
