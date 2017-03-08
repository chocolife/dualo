using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class InfoManager : MonoBehaviour
{
    public GameObject menuPanel;
    public GameObject mousePosXInfo;
    public GameObject mousePosYInfo;

    public GameObject menuPosInfo;

    private Text mousePosXText;
    private Text mousePosYText;
    private Text menuPosText;

    private RectTransform menuRect;


	// Use this for initialization
	void Start ()
    {
        mousePosXText = mousePosXInfo.GetComponent<Text>();
        mousePosYText = mousePosYInfo.GetComponent<Text>();
        menuPosText = menuPosInfo.GetComponent<Text>();

        menuRect = menuPanel.GetComponent<RectTransform>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        mousePosXText.text = Input.mousePosition.x.ToString();
        mousePosYText.text = Input.mousePosition.y.ToString();
        menuPosText.text = menuRect.anchoredPosition.y.ToString();

	}
}
