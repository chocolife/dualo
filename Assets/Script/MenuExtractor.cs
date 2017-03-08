using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;


public class MenuExtractor : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, ICanvasRaycastFilter
{
	
	private Vector3 mousePos;
	private Vector3 panelOrigin;
	private int extracctPoint = 100;
    private int topPos = 380;

    public GameObject menuOverlay;
	public GameObject menuBase;
    public GameObject tonedownPanel;

	private RectTransform panelRect;

    private GraphicRaycaster gr; // GraphicRaycaster of "menuOverlay"
    private MenuStatus ms;
	
	public bool isDragging = false;
	public bool isExtracted;
	
	//private RectTransform canvasRect;
    private Vector3 currentMousePos;
	
	
	// Use this for initialization
	void Start () {
		//canvasRect = this.GetComponent<RectTransform>();
		panelRect = menuBase.GetComponent<RectTransform>();
		panelOrigin = panelRect.anchoredPosition;

        gr = menuOverlay.GetComponent<GraphicRaycaster>();
        ms = menuOverlay.GetComponent<MenuStatus>();

        isExtracted = false;
        gr.enabled = false;
	}
	

	void Update ()
	{

        currentMousePos = Input.mousePosition;

	}
	
	
	
	public void OnBeginDrag(PointerEventData data)
	{
        if (currentMousePos.y < topPos)
        {
            if (currentMousePos.y < extracctPoint && !ms.menuStatusExtracted)
            {
                isDragging = true;

                iTween.MoveTo(menuBase, iTween.Hash(
                    "position", new Vector3(0, currentMousePos.y, -5),
                    "easeType", iTween.EaseType.easeInOutSine,
                    "time", 0.1f,
                    "islocal", true
                    ));
            } 
            else if (currentMousePos.y > 280 && ms.menuStatusExtracted)
            {
                isDragging = true;
            }
        }
	}
	
	
	public void OnDrag(PointerEventData data)
	{
        if (isDragging && ms.menuStatusExtracted)
		{
            panelRect.anchoredPosition = new Vector3 (0, (topPos - (topPos - currentMousePos.y) / 5), -1);
		}
        else if (isDragging && !ms.menuStatusExtracted)
        {
            panelRect.anchoredPosition = new Vector3 (0, currentMousePos.y - (topPos - currentMousePos.y) / 5, -1);
        }
	}
	
	
	
	public void OnEndDrag(PointerEventData data)
	{
        if (!ms.menuStatusExtracted && isDragging)
		{
            ExtractMenuPanel();
			isDragging = false;
			isExtracted = true;
            ms.menuStatusExtracted = true;
            gr.enabled = true;
		}
        else if (ms.menuStatusExtracted && currentMousePos.y <= 250)
        {
            StoreMenuPanel();
            isDragging = false;
            isExtracted = false;
            ms.menuStatusExtracted = false;
            gr.enabled = false;
        }
        else if (ms.menuStatusExtracted && currentMousePos.y > 250)
        {
            ExtractMenuPanel();
            isDragging = false;
            ms.menuStatusExtracted = true;
            gr.enabled = true;
        }
    }
	
	
    void ExtractMenuPanel()
    {
        iTween.MoveTo(menuBase, iTween.Hash(
            "position", new Vector3(0, topPos, -5),
            "easeType", iTween.EaseType.easeInOutSine,
            "time", 0.3f,
            "islocal", true
            ));

        if (!ms.menuStatusExtracted)
        {
            iTween.ValueTo(gameObject, iTween.Hash(
            "from", 0,
            "to", 0.6f,
            "time", 0.3f,
            "onupdate", "SetValue"
            ));
        }
    }


    void StoreMenuPanel()
    {
        iTween.MoveTo(menuBase, iTween.Hash(
            "position", new Vector3(0, 0, -5),
            "easeType", iTween.EaseType.easeInOutSine,
            "time", 0.3f,
            "islocal", true
            ));

        iTween.ValueTo(gameObject, iTween.Hash(
            "from", 0.6f,
            "to", 0,
            "time", 0.3f,
            "onupdate", "SetValue"
            ));
    }



    void SetValue(float alpha)
    {
        tonedownPanel.GetComponent<Image>().color = new Color(0.15f, 0.15f, 0.15f, alpha);
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