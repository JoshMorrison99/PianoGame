using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Video;

public class PlayVideoMouseHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public void OnPointerEnter(PointerEventData data)
    {
        data.pointerEnter.gameObject.GetComponent<VideoPlayer>().Play();
    }

    public void OnPointerExit(PointerEventData data)
    {
        data.pointerEnter.gameObject.GetComponent<VideoPlayer>().Pause(); ;
    }
}
