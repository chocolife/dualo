using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;


public class ScalableMask : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, ICanvasRaycastFilter
{

	private GameObject maskObj;
	private RectTransform rectTrans;

	private Vector2 rectSize;
	private Vector2 rectPos;

	private int currentPos = 400;

	public GameObject textObj;
	public GameObject panel;

	public bool isDragging = false;
	


	// Use this for initialization
	void Start () {
		rectSize = new Vector2 (1278, currentPos);
		//rectPos = new Vector2 (1278, currentPos - 119);
		rectTrans = panel.GetComponent<RectTransform> ();
		rectTrans.sizeDelta = rectSize;
		rectTrans.position = rectPos;


	}
	

	void Update ()
	{

		Debug.Log(isDragging);
	}



	public void OnBeginDrag(PointerEventData data)
	{
		isDragging = true;
	}


	public void OnDrag(PointerEventData data)
	{
		textObj.GetComponent<Text> ().text = data.position.y.ToString ();
		//transform.position = transform.position + new Vector3 (data.delta.x, data.delta.y);

		//rectTrans.position = new Vector2 (1278, data.delta.y + 119);
		rectTrans.position = new Vector2 (1278, data.position.y);

		rectTrans.sizeDelta = new Vector2(1278, 800 - (800 - data.position.y) + 119);
		/*if (!isLocated)
		{
			transform.position = transform.position + new Vector3 (data.delta.x, data.delta.y);
		}
		*/
	}


	public void OnEndDrag(PointerEventData data)
	{
		isDragging = false;
		//_timer.ResetTime ();
	}
	
	
	public bool IsRaycastLocationValid(Vector2 sp, Camera eventCamera)
	{
		return !isDragging;
	}
	


}