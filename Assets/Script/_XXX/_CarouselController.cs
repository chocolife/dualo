using UnityEngine;
using System.Collections;

public class _CarouselController : MonoBehaviour {

	private Transform CarouselTransform;
	private Quaternion rot;
	private float angle;

	// Use this for initialization
	void Start () {

		angle = 0;
		CarouselTransform = GetComponent<Transform>();
		rot = this.GetComponent<Transform>().rotation;
	}
	
	// Update is called once per frame
	void Update () {

		//CarouselTransform.Rotate(new Vector3(0, 1, 0), 0.2f);
		//CarouselTransform.RotateAround(new Vector3(0, 1, 0), angle);

		CarouselTransform.eulerAngles = new Vector3(0, angle, 0);
		angle += 0.1f;
		//print (angle);
		if (angle > 45.0f)
		{
			angle = 0;
			print ("Clear!!!");
		}
	}
}
