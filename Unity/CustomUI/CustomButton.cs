using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

/// <summary>
/// 自作ボタン用の抽象クラス
/// </summary>
[RequireComponent(typeof(Image))]
public abstract class CustomButton : MonoBehaviour,IPointerClickHandler,IPointerDownHandler,IPointerUpHandler
{
	// note:ButtonTypeを追加すると既存のボタンのButtonTypeがずれてしまうので要修正
	public enum ButtonType
	{
		Default,
		Toggle,
		Open,
		Close,
		Start,
		End
	}

	public ButtonType buttonType;
	private Image image;
	// isOnはトグルボタンとして扱う時用の変数
	private bool isOn;
	public System.Action onClickEvent;

	public Image Image
	{
		get {return image;}
		set {image = value;}
	}

	public bool IsOn
	{
		get {return isOn;}
		set {isOn = value;}
	}

	private void Awake()
	{
		image = GetComponent<Image>();
		if(buttonType == ButtonType.Toggle)
		{
			isOn = false;
		}
	}

	// クリック or タップした時の挙動は必ず実装する
	public abstract void OnPointerClick(PointerEventData eventData);

	// ボタンを押し込んだ時と離した時の挙動は任意
	public virtual void OnPointerDown(PointerEventData eventData){}

	public virtual void OnPointerUp(PointerEventData eventData){}
}
