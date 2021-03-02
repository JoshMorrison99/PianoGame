using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteCollision : MonoBehaviour
{
    public PlayLogic Logic;
    public bool intersecting;


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (this.GetComponent<Note>().isPressed)
        {
            // Effects Spawn
            ParticleSystem emit = gameObject.GetComponentInChildren<ParticleSystem>();
            emit.Play();

            // Change color of note
            collision.gameObject.GetComponent<SpriteRenderer>().color = Color.blue;

            if (intersecting)
            {
                IncrementNotesHit();
                intersecting = false;
            }
        }
        
    }

    void IncrementNotesHit()
    {
        if (GetComponent<Note>().isPressed)
        {
            // Note successfully hit
            Logic.numNotesHit += 1;
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.tag == "Note")
        {
            Debug.Log("true enter");
            intersecting = true;
            
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Note")
        {
            Debug.Log("true exit");
            intersecting = false;

        }
    }
}
