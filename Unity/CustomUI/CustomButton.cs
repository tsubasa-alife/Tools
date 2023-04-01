using System;
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
	[SerializeField] private Image image;
	[SerializeField] private TextMeshProGUI buttonText;
	public Action onClickEvent;

	// クリック or タップした時の挙動は必ず実装する
	public abstract void OnPointerClick(PointerEventData eventData);

	// ボタンを押し込んだ時と離した時の挙動は任意
	public virtual void OnPointerDown(PointerEventData eventData){}

	public virtual void OnPointerUp(PointerEventData eventData){}
}
