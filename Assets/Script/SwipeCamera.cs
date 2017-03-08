using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;


public class SwipeCamera : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, ICanvasRaycastFilter
{

	private GameObject maskObj;
	private RectTransform rectTrans;

	private Vector2 rectSize;
	private Vector2 rectPos;

	private float xPos;

	private int currentPos = 400;

	public GameObject textObj;
	//public GameObject panel;

	public Camera blurCam;

	public bool isDragging = false;
	


	// Use this for initialization
	void Start () {
		blurCam.rect = new Rect(0, 0, 0.25F, 1.0f);
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
		Vector2 ViewportPosition = blurCam.WorldToViewportPoint(data.position);
		xPos = ViewportPosition.x;

		if (IsRange(xPos, -1.0f, 2.0f))
		{
			//blurCam.rect = new Rect(0, 0, xPos, 1.0f);
		}

		textObj.GetComponent<Text>().text = xPos.ToString();
		//transform.position = transform.position + new Vector3 (ata.delta.x, data.delta.y);

		//rectTrans.position = new Vector2 (1278, data.delta.y + 119);
		//rectTrans.position = new Vector2 (1278, data.position.y);

		//rectTrans.sizeDelta = new Vector2(1278, 800 - (800 - data.position.y) + 119);
		/*if (!isLocated)
		{
			transform.position = transform.position + new Vector3 (data.delta.x, data.delta.y);
		}
		*/
	}


	public void OnEndDrag(PointerEventData data)
	{
		isDragging = false;
	}
	
	
	public bool IsRaycastLocationValid(Vector2 sp, Camera eventCamera)
	{
		return !isDragging;
	}
	

	public static bool IsRange(float a, float from, float to)
	{
		if (from < to) {
			return (from <= a && a <= to);
		} else {
			return (from >= a && a >= to);
		}
	}


}