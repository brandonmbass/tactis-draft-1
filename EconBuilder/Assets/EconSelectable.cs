using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class EconSelectable : Selectable {

    public EconEvent SelectEvent { get; set; }
    public EconEvent DeselectEvent { get; set; }

    public EconSelectable()
    {
        SelectEvent = new EconEvent();
        DeselectEvent = new EconEvent();
    }

    public override void OnSelect(BaseEventData eventData)
    {
        SelectEvent.Invoke();
    }

    public override void OnDeselect(BaseEventData eventData)
    {
        DeselectEvent.Invoke();
    }
}
