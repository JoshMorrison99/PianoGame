using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{

    private void Update()
    {
        /*if (initialPress)
        {
            StartCoroutine(ExecuteAfterTime(0.2f));
        }*/

    }

    public bool isPressed = false;
    //public bool initialPress = false;
    public bool concurrentPress = false;
    public string noteName;

/*    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);

        // Code to execute after the delay
        Debug.Log("Setting to false");
        initialPress = false;
    }*/

}
