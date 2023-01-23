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
	[SerializeField] private bool isActive = true;
	private Image image = null;
	private TextMeshProGUI buttonText = null;
	public System.Action onClickEvent;

	public bool IsActive
	{
		get
		{
			return isActive;
		}
		set
		{
			isActive = value;
			Activate();
		}
	}

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

	private void Activate()
	{
		if(IsActive)
		{
			if(Image != null)
			{
				Image.color = new Color(Image.color.r,Image.color.g,Image.color.b,1);
			}
			if(ButtonText != null)
			{
				ButtonText.color = new Color(ButtonText.color.r,ButtonText.color.g,ButtonText.color.b,1);
			}
		}
		else
		{
			if(Image != null)
			{
				Image.color = new Color(Image.color.r,Image.color.g,Image.color.b,0.5f);
			}
			if(ButtonText != null)
			{
				ButtonText.color = new Color(ButtonText.color.r,ButtonText.color.g,ButtonText.color.b,0.5f);
			}
		}
	}

	// クリック or タップした時の挙動は必ず実装する
	public abstract void OnPointerClick(PointerEventData eventData);

	// ボタンを押し込んだ時と離した時の挙動は任意
	public virtual void OnPointerDown(PointerEventData eventData){}

	public virtual void OnPointerUp(PointerEventData eventData){}
}
