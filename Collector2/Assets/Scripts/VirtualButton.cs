using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class VirtualButton : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{
    private Image buttonImage;
    public bool isPressed;

    public void OnStart()
    {
        isPressed = false;
    }
    public virtual void OnDrag(PointerEventData ped)
    {
        Debug.Log("OnDrag");
    }

    public virtual void OnPointerDown(PointerEventData ped)
    {
        Debug.Log("Down");
        isPressed = true;
    }

    public virtual void OnPointerUp(PointerEventData ped)
    {
        Debug.Log("UP");
        isPressed = false;
    }
}