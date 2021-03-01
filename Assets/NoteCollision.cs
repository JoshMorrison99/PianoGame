using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteCollision : MonoBehaviour
{
    public PlayLogic Logic;


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (this.GetComponent<Note>().isPressed)
        {
            // Effects Spawn
            ParticleSystem emit = gameObject.GetComponentInChildren<ParticleSystem>();
            emit.Play();

            // Change color of note
            collision.gameObject.GetComponent<SpriteRenderer>().color = Color.blue;

            // Note successfully hit
            Logic.numNotesHit += 1;
        }
        
    }
}
