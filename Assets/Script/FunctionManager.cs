using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FunctionManager : MonoBehaviour
{

	public GameObject mapButton;
	public GameObject audioButton;
	public GameObject radioButton;
	public GameObject videoButton;

	public Canvas audioCanvas;
	public Canvas albums;
	public Canvas mapCanvas;
	public Canvas radioCanvas;
	public Canvas videoCanvas;

	private bool mapSelected;
	private bool audioSelected;
	private bool radioSelected;
	private bool videoSelected;

	public string selectedFuncName;


	// Use this for initialization
	void Start ()
	{
		mapSelected = false;
		audioSelected = false;
		radioSelected = false;
		videoSelected = false;

		selectedFuncName = "none";

        ActivateMap();
	}

	
	// Update is called once per frame
	void Update ()
	{

	}


	public void ChangeFunction(string buttonName)
	{
		if (buttonName == "Button Audio")
		{
            ActivateAudio();
		}
		else if (buttonName == "Button Map")
		{
            ActivateMap();
		}
        else if (buttonName == "Button Radio")
        {
            ActivateRadio();
        }

	}


    public void ActivateMap()
    {
        mapCanvas.enabled = true;
        audioCanvas.enabled = false;
        albums.enabled  = false;
        radioCanvas.enabled = false;
    }


    public void ActivateAudio()
    {
        audioCanvas.enabled = true;
        albums.enabled  = true;
        mapCanvas.enabled = false;
        radioCanvas.enabled = false;
    }


    public void ActivateRadio()
    {
        radioCanvas.enabled = true;
        audioCanvas.enabled = false;
        albums.enabled  = false;
        mapCanvas.enabled = false;
    }
}
