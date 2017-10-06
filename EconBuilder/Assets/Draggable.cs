using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {
    Vector2 lastPosition;

    public void OnBeginDrag(PointerEventData eventData)
    {
        // TODO: for some reason, small mouse movements don't trigger this, so it feels a bit sluggish
        lastPosition = eventData.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
        var diff = eventData.position - lastPosition;        
        this.transform.position = this.transform.position + (Vector3)diff;
        lastPosition = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        
    }
}
