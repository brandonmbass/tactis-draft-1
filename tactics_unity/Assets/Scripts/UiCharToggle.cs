using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections;

public class UiCharToggle : Toggle
{
    public Image BackgroundImage;

    protected override void Start()
    {
        base.Start();
        BackgroundImage = GetComponent<Image>();
    }

    public void Toggle(bool isToggled) {
        if (isToggled)
        {
            BackgroundImage.color = new Color32(18, 184, 39, 92);
        }
        else
        {
            BackgroundImage.color = new Color32(129, 129, 129, 92);
        }        
    }

    public override void OnSelect(BaseEventData eventData)
    {
        base.OnSelect(eventData);
        
    }

    public override void OnDeselect(BaseEventData eventData)
    {
        base.OnDeselect(eventData);
        
    }
}
