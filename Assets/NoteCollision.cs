using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteCollision : MonoBehaviour
{
    public PlayLogic Logic;
    public bool intersecting;


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (this.GetComponent<Note>().initialPress)
        {
            // Effects Spawn
            ParticleSystem emit = gameObject.GetComponentInChildren<ParticleSystem>();
            emit.Play();

            // Change color of note
            collision.gameObject.GetComponent<SpriteRenderer>().color = Color.blue;

            Debug.Log("Intersecting? " + intersecting);
            if (intersecting)
            {
                IncrementNotesHit();
                intersecting = false;
            }
        }
        
    }

    void IncrementNotesHit()
    {
            // Note successfully hit
            Logic.numNotesHit += 1;

        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.tag == "Note")
        {
            intersecting = true;
            
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Note")
        {
            intersecting = false;

        }
    }
}
