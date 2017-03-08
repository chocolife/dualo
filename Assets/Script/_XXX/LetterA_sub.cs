
using UnityEngine;
using UnityEngine.EventSystems;

public class LetterA_sub : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler{
	
	public static RectTransform obj;
	
	public void OnBeginDrag(PointerEventData e){
		obj = GetComponent<RectTransform>();
		obj.SetAsFirstSibling();
	}
	public void OnDrag(PointerEventData e){
		obj.position = e.position;
	}
	public void OnEndDrag(PointerEventData e){
		obj.SetAsLastSibling();
	}
}
