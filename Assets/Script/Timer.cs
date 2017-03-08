using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Timer : MonoBehaviour 
{
	public float startTime = 10.0f;
	public float count;
	public bool reset = false;

	private Text text;
	
	// Use this for initialization
	void Start () {
		
		text = this.GetComponent<Text>();
		count = startTime;
		
	}
	
	// Update is called once per frame
	void Update () {

		count -= Time.deltaTime;
		if (count <= 0.0f)
		{
			count = 0.0f;
			// 何かの処理
			Application.LoadLevel ("Duaro01");
		}

		text.text = count.ToString ();
	}

	public void ResetTime()
	{
		count = startTime;
	}
}