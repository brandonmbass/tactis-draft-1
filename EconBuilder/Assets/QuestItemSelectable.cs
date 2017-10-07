using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class QuestItemSelectable : Selectable {

    public EconEvent SelectEvent { get; set; }

    public QuestItemSelectable()
    {
        SelectEvent = new EconEvent();
    }

    public override void OnSelect(BaseEventData eventData)
    {
        SelectEvent.Invoke();
    }
}
