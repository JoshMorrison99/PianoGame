using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class detectorScript : MonoBehaviour
{
    public bool overlapping = false;
    public bool intersecting = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.tag == "Note")
        {
            overlapping = true;
            intersecting = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.tag == "Note")
        {
            overlapping = false;
            intersecting = false;
            //this.GetComponent<Note>().concurrentPress = false;
        }
    }
}
