using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;


public class LetterA : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, ICanvasRaycastFilter
{
	
	public Timer _timer;
	public bool isDragging = false;

	public GameObject text_x;
	public GameObject text_y;

	public GameObject sign_a;
	
	public bool isLocated = false;
	
	private RectTransform rectTrans;
	private Animator anim;
	
	private float center_x = 40.0f;
	private float center_y = 0;
	private float margin = 20.0f;
	private Vector3 center_pos;
	private float min_x;
	private float max_y;
	
	void Start ()
	{
		_timer = GameObject.Find("Canvas/CountTimer").GetComponent<Timer>();
		rectTrans = GetComponent<RectTransform> ();
		anim = GetComponent<Animator> ();
		center_pos = new Vector3(center_x, 0);
	}
	
	
	public void OnBeginDrag(PointerEventData data)
	{
		isDragging = true;
	}
	
	
	public void OnDrag(PointerEventData data)
	{
		if (!isLocated)
		{
			transform.position = transform.position + new Vector3 (data.delta.x, data.delta.y);
		}
	}
	
	
	public void OnEndDrag(PointerEventData data)
	{
		isDragging = false;
		_timer.ResetTime ();
	}
	
	
	public bool IsRaycastLocationValid(Vector2 sp, Camera eventCamera)
	{
		return !isDragging;
	}
	
	
	void Update ()
	{	
		if (isDragging)
		{
			text_x.GetComponent<Text> ().text = rectTrans.anchoredPosition.x.ToString ();
			text_y.GetComponent<Text> ().text = rectTrans.anchoredPosition.y.ToString ();
		}
		

		if (!isDragging && !isLocated && IsRange(rectTrans.anchoredPosition.x, center_x - margin, center_x + margin))
		{
			anim.Play ("flash01");
			Debug.Log ("Located!!!");
			isLocated = true;
		} 
		else if (!isDragging && isLocated && !IsRange(rectTrans.anchoredPosition.x, center_x - margin, center_x + margin))
		{
			Debug.Log ("Exited!!!");
			isLocated = false;
		}

		if (isLocated)
		{
			rectTrans.anchoredPosition = center_pos;
			sign_a.GetComponent<CanvasRenderer> ().SetAlpha (1.0f);
		}
			else
		{
			sign_a.GetComponent<CanvasRenderer> ().SetAlpha (0);
		}
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




/*
using UnityEngine;
using System.Collections;

public class LetterA : MonoBehaviour 
{
	public Sprite letter;
	private float z = 10f;
	private float delta_x;
	private float delta_y;
	
	// Use this for initialization
	void Start () 
	{
		//SpriteRenderer renderer = GetComponent<SpriteRenderer>();
		//int test = Random.Range (0, 6);
		//renderer.sprite = letter;
	}


	// Update is called once per frame
	void Update () 
	{
		
	}

	void OnMouseDown ()
	{

		Vector3 vec = Input.mousePosition;
		vec.z = 10f;
		
		float mouse_cam_x = Camera.main.ScreenToWorldPoint(vec).x;
		float mouse_cam_y = Camera.main.ScreenToWorldPoint(vec).y;

		delta_x = this.transform.position.x - mouse_cam_x;
		delta_y = this.transform.position.y - mouse_cam_y;


	}

	void OnMouseDrag ()
	{
		Debug.Log ("X:" + delta_x + "    Y:" + delta_y);
		this.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, z));
		float current_pos_x = this.transform.position.x;
		//this.transform.position.x = current_pos_x + delta_x;
		//this.transform.position.y += delta_y;
	}
}
*/