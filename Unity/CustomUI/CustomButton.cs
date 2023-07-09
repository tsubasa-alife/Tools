using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

/// <summary>
/// 自作ボタン用の抽象クラス
/// </summary>
[RequireComponent(typeof(Image))]
public abstract class CustomButton : MonoBehaviour,IPointerClickHandler,IPointerDownHandler,IPointerUpHandler
{
	// クリック or タップした時の挙動は必ず実装する
	public abstract void OnPointerClick(PointerEventData eventData);

	// ボタンを押し込んだ時と離した時の挙動は任意
	public virtual void OnPointerDown(PointerEventData eventData){}

	public virtual void OnPointerUp(PointerEventData eventData){}
}
