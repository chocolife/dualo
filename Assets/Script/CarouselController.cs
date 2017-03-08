// Credit to damien_oconnell from http://forum.unity3d.com/threads/39513-Click-drag-camera-movement
// for using the mouse displacement for calculating the amount of camera movement and panning code.

using UnityEngine;
using System.Collections;

public class CarouselController : MonoBehaviour 
{

	public float turnSpeed = 4.0f;		// Speed of camera turning when mouse moves in along an axis
	
	private Vector3 mouseOrigin;	// Position of cursor when mouse dragging starts
	private bool isRotating;	// Is the camera being rotated?

	private float inertia;
	private Vector3 rereasedMouseOrigin;
	private Vector3	holdingMouseOrigin;
	private bool isMouseDown_0;
	private Vector3 pos;
	

	void Start ()
	{
		inertia = 0;
	}


	void Update () 
	{

		// Get the left mouse button
		if(Input.GetMouseButtonDown(0))
		{
			// Get mouse origin
			holdingMouseOrigin = Input.mousePosition;
			isMouseDown_0 = true;
			isRotating = true;
			inertia = 1.5f;
		}


		// Disable movements on button release
		if (!Input.GetMouseButton (0)) 
		{
			isMouseDown_0 = false;
			if (inertia < 0) 
			{
				isRotating = false;
			}
			inertia -= 0.02f;
			rereasedMouseOrigin = holdingMouseOrigin;
		}


		// Rotate camera along X and Y axis
		if (isRotating)
		{
			mouseOrigin = holdingMouseOrigin;
			if (!isMouseDown_0) 
			{
				mouseOrigin = rereasedMouseOrigin;
				 //pos = Camera.main.ScreenToViewportPoint(holdingMouseOrigin - mouseOrigin);
			}
			else
			{
				 pos = Camera.main.ScreenToViewportPoint(Input.mousePosition - mouseOrigin);
			}

			//transform.RotateAround(transform.position, transform.right, +pos.y * turnSpeed * inertia);
			transform.RotateAround(transform.position, Vector3.up, -pos.x * turnSpeed * inertia);

		}
	
	}
}