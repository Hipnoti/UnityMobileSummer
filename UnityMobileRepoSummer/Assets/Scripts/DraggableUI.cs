using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DraggableUI : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    [SerializeField] private GameObject highlightObject;
    [SerializeField] private Image itemIconImage;
    
    public void OnBeginDrag(PointerEventData eventData)
    {
        itemIconImage.color = new Color(itemIconImage.color.r, itemIconImage.color.g, itemIconImage.color.b,
            0.5f);
        highlightObject.SetActive(true);
    }
    
    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
    }
    

    public void OnEndDrag(PointerEventData eventData)
    {
        itemIconImage.color = new Color(itemIconImage.color.r, itemIconImage.color.g, itemIconImage.color.b,
            1f);
        highlightObject.SetActive(false);
    }
}
