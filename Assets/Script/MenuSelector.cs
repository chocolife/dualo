using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class MenuSelector : MonoBehaviour
{

	public Sprite selectedImg;
	public Sprite normalImg;
	public GameObject parentObj;
	public bool isDefault;
	private RectTransform Rect;
	private CanvasRenderer sr;
	private Image img;
	private bool selected;
	private List<GameObject> buttons;

	public GameObject menuOverlay;
	private FunctionManager funcMgr;

	// Use this for initialization

	void Start ()
	{
		buttons = new List<GameObject> ();
		selected = false;
		img = GetComponent<Image>();
		Rect = this.GetComponent<RectTransform>();
		sr = this.GetComponent<CanvasRenderer>();

		funcMgr = menuOverlay.GetComponent<FunctionManager>();

		foreach (Transform child in parentObj.transform)
		{
			if (child.tag == "Menu Button" && child.name != this.name)
			{
				buttons.Add (child.gameObject);
			}
		}

		if (isDefault)
		{
			selected = true;
			img.sprite = selectedImg;
		}
	}


	public void onClick() 
	{
		if (selected) 
		{
			//deselectButton();
			//selected = false;
		} 
		else
		{
			img.sprite = selectedImg;
			selected = true;

			foreach (GameObject btn in buttons)
			{
				btn.SendMessage("deselectButton");
			}

		}

		switchFunction();
	}


	// Update is called once per frame
	void Update ()
	{

	}

	public void deselectButton()
	{
		img.sprite = normalImg;
		selected = false;
	}


	public void switchFunction()
	{
		funcMgr.ChangeFunction(this.name);
	}
	

}
