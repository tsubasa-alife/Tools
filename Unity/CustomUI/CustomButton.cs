using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

/// <summary>
/// 自作ボタン用の抽象クラス
/// </summary>
[RequireComponent(typeof(Image))]
public abstract class CustomButton : MonoBehaviour,IPointerClickHandler,IPointerDownHandler,IPointerUpHandler
{
	public enum ButtonType
	{
		Default
	}

	public ButtonType buttonType;
	private Image image;
	private TextMeshProGUI buttonText;
	public System.Action onClickEvent;

	public Image Image
	{
		get
		{
			return image;
		}
	}

	public TextMeshProGUI ButtonText
	{
		get
		{
			return buttonText;
		}
	}

	private void Awake()
	{
		image = this.gameObject.GetComponent<Image>();
		buttonText = this.gameObject.GetComponentInChildren<TextMeshProUGUI>();
	}

	// クリック or タップした時の挙動は必ず実装する
	public abstract void OnPointerClick(PointerEventData eventData);

	// ボタンを押し込んだ時と離した時の挙動は任意
	public virtual void OnPointerDown(PointerEventData eventData){}

	public virtual void OnPointerUp(PointerEventData eventData){}
}
