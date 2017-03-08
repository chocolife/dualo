using UnityEngine;
using System.Collections;
using System;

public class PanelManager : MonoBehaviour
{

	public GameObject carousel;
	public bool isDebug;

	private Transform carouselTrans;
	private Transform myTrans;
	private float delta_x;
	private float delta_z;
	private float max_delta_z;
	private float start_delta_z;

	private float myAngle;

	private Vector2 carouselPos;
	private Vector2 myPos;
	private float relativeAngle; // Relative angle from carousel
	private float distance;

	private int adjustSeed;



	void Start ()
	{
		carouselTrans = carousel.GetComponent<Transform> ();
		myTrans = GetComponent<Transform> ();
		max_delta_z = 156;
		start_delta_z = max_delta_z - 45;
	}


	// Update is called once per frame
	void Update ()
	{	
		relativeAngle = GetAim (carouselPos, myPos);


		delta_x = myTrans.position.x - carouselTrans.position.x;
		delta_z = myTrans.position.z - carouselTrans.position.z;
		//print ("x: " + delta_x + "   y: " + delta_z + "  angle: " + myAngle);

		carouselPos = new Vector2 (carouselTrans.position.x, carouselTrans.position.z);
		myPos = new Vector2 (myTrans.position.x, myTrans.position.z);

		distance = Vector2.Distance (carouselPos, myPos);

		myAngle = Math.Abs (relativeAngle);


		if (relativeAngle < -45 && relativeAngle >= -90)
		{
			myAngle = 90 - -relativeAngle;
		}
		else if (relativeAngle < -90 && relativeAngle > -135)
		{
			myAngle = 90 - -relativeAngle;
		}
		else if (delta_x < 0)
		{
			myAngle = Math.Abs(relativeAngle) + 180;
		}
	

		myTrans.eulerAngles = new Vector3(0, myAngle, 0);



		// Adjust SiblingIndex
		adjustSeed = 0;

		if (delta_x < 0)
		{
			adjustSeed = -1;
		}

		if (relativeAngle < -60 && relativeAngle > -120) 
		{
			transform.SetSiblingIndex (8 + adjustSeed);
		} 
		else if ((relativeAngle < -30 && relativeAngle > -60) || (relativeAngle < -120 && relativeAngle > -150))
		{
			transform.SetSiblingIndex (6 + adjustSeed);	
		}
		else if ((relativeAngle > -30 && relativeAngle < 0) || (relativeAngle < -150 && relativeAngle > -180))
		{
			transform.SetSiblingIndex (4 + adjustSeed);	
		} 
		else if (relativeAngle >= 0 && relativeAngle <= 180) 
		{
			transform.SetSiblingIndex (2 + adjustSeed);
		}


		/*
		if (Math.Abs (delta_x) < 90) 
		{
			if (delta_x > 0)
			{
				trans.eulerAngles = new Vector3(0, 45 - (45 - delta_x), 0);
			}
			else
			{
				trans.eulerAngles = new Vector3(0, 135 + (45 + delta_x) + 180, 0);
			}
		}*/

		/*
		if (delta_z < -start_delta_z) 
		{
			if (delta_x > 0)
			{
				myTrans.eulerAngles = new Vector3(0, 45 - (Math.Abs (delta_z) - start_delta_z), 0);
			}
			else
			{
				myTrans.eulerAngles = new Vector3(0, 135 + (Math.Abs (delta_z) - start_delta_z + 180), 0);
			}
		}
		*/
		if (isDebug) {
			print ("Relative Angle :   " + relativeAngle);
			print ("My Angle :   " + myAngle);
			print ("Distance :   " + distance);
			print ("Delta_Z :   " + delta_z);
			print ("Delta_Z_Angle :   " + distance * Math.Cos(relativeAngle + 90));
		}

	}


	// Get angle from p2 to p1
	// @param p1 My posision
	// @param p2 Target position
	// @return Angle of between 2 points(Degree)
	public float GetAim(Vector2 p1, Vector2 p2) {
		float dx = p2.x - p1.x;
		float dy = p2.y - p1.y;
		float rad = Mathf.Atan2(dy, dx);
		return rad * Mathf.Rad2Deg;
	}




	void OnTriggerEnter2D(Collider2D col)
	{
		print ("Collision!!!");


	}
}