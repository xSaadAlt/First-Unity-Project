using System.Drawing;
using System.Reflection;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class HoverHighlight : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler,IPointerClickHandler



{
[SerializeField] GameObject Ponitor;
[SerializeField] GameObject Press;

    public void Start()
    {
        Ponitor.SetActive(false);
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
            Ponitor.SetActive(true);
    }

public void OnPointerExit(PointerEventData eventData)
    {
            Ponitor.SetActive(false);
    }

public void OnPointerClick(PointerEventData eventData)
    {
        Press.SetActive(false);
        Invoke(nameof(afterclick),0.18f);
    }

public void afterclick()
    {
        Press.SetActive(true);
    }

}