using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TabButton : MonoBehaviour, IPointerClickHandler, IPointerExitHandler
{
    public Tabbar tabbar;
    public Body body;

    public void OnPointerClick(PointerEventData eventData)
    {
        tabbar.OnTapSelected(this);
        body.MoveTo(gameObject.name);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        tabbar.OnTapExit(this);
    }
}
