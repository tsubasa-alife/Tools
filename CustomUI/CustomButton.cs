using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Image))]
public class CustomButton : MonoBehaviour,IPointerClickHandler,IPointerDownHandler,IPointerUpHandler
{
    public Image image;
    public System.Action onClickEvent;
    public System.Action onDownEvent;
    public System.Action onUpEvent;

    void Awake()
    {
        image = GetComponent<Image>();
        onClickEvent = () => {
            Debug.Log("Clicked");
        };
        onDownEvent = () => {
            Debug.Log("Down");
        };
        onUpEvent = () => {
            Debug.Log("Up");
        };
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        onClickEvent?.Invoke();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        onDownEvent?.Invoke();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        onUpEvent?.Invoke();
    }
}
