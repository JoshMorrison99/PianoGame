using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class detectorScript : MonoBehaviour
{
    public bool overlapScore = false;
    public bool overlapNote = false;
    public int initalId;

    public PlayLogic Logic;

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Note")
        {
            overlapScore = true;
            overlapNote = true;
            initalId = collision.GetComponentInParent<Note_Falling>().uid;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Note")
        {
            overlapScore = false;
            overlapNote = false;
            this.GetComponentInParent<Note_Mine>().initialPress = false; // Stops the user from being able to hit a note correctly and then continuously hit additional notes by holding down the key
        }
    }

    private void Update()
    {
        if (this.GetComponentInParent<Note_Mine>().isPressed && this.overlapScore == false) // Stops the user from holding down the key to hit all the notes
        {
            this.GetComponentInParent<Note_Mine>().initialPress = false;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (this.GetComponentInParent<Note_Mine>().initialPress) // Make it so it only updates 1 point
        {
            if (this.GetComponentInParent<Note_Mine>().noteName == collision.GetComponentInParent<Note_Falling>().noteName) // makes it so the user cannot hit a note correctly and then hold down the note to hit additional notes and stops the user from being able to hit 2 notes at a time becasue of overlapping UI such as A and A#. Since they are so close together, the user could hit A and also hit A#. This stops that from happeninng by making sure the note names are the same.
            {

                if (overlapNote)
                {
                    IncrementNotesHit();
                    //this.GetComponentInParent<Note_Mine>().initialPress = false;
                }

                if (overlapScore)
                {
                    // Increment score
                    Logic.currentScore += 1;
                }
            }
           
        }



        


    }
    void IncrementNotesHit()
    {




        // Note successfully hit
        Logic.numNotesHit += 1;

        // Increment exp
        PersistentData.data.exp += 1;

        this.overlapNote = false;

    }
}
