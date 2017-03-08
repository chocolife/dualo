using UnityEngine;
using System.Collections;

public class Initializer : MonoBehaviour
{

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetMouseButton (0)) {
			Debug.Log ("Clicked!!!");
			Application.LoadLevel ("Duaro01");


		}

	}
}
