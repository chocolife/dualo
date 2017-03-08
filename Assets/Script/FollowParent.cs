using UnityEngine;
using System.Collections;

public class FollowParent : MonoBehaviour {

	public GameObject parentObj;
	public GameObject childObj;
	private RectTransform childRect;
	private RectTransform parentRect;
	// Use this for initialization
	void Start () {
		childRect = childObj.GetComponent<RectTransform>();
		parentRect = parentObj.GetComponent<RectTransform>();
	}
	
	// Update is called once per frame
	void Update () {

		childRect.transform.position = parentRect.transform.position;
	}
}
