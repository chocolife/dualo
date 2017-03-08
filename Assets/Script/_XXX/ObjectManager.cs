using UnityEngine;
using System.Collections;

public class ObjectManager : MonoBehaviour
{

	public GameObject letter_d;
	public GameObject letter_u;
	public GameObject letter_a;
	public GameObject letter_r;
	public GameObject letter_o;

	public GameObject logo_fill;

	public GameObject timer_counter;

	public GameObject sign_d;
	public GameObject sign_u;
	public GameObject sign_a;
	public GameObject sign_r;
	public GameObject sign_o;

	//private LetterA scpt_a;
	private LetterD scpt_d;
	private LetterU scpt_u;
	private LetterA scpt_a;
	private LetterR scpt_r;
	private LetterO scpt_o;

	public GameObject letters;

	public GameObject currentObj;



	IEnumerator LateStart(float time) {
		yield return new WaitForSeconds (time);
		Application.LoadLevel ("Duaro02");
	}


	// Use this for initialization
	void Start ()
	{
		//letters = transform.FindChild(“Letters”).gameObject;

		currentObj = letter_a;

		scpt_d = letter_d.GetComponent<LetterD>();
		scpt_u = letter_u.GetComponent<LetterU>();
		scpt_a = letter_a.GetComponent<LetterA>();
		scpt_r = letter_r.GetComponent<LetterR>();
		scpt_o = letter_o.GetComponent<LetterO>();


		sign_d.GetComponent<CanvasRenderer> ().SetAlpha(0);
		sign_u.GetComponent<CanvasRenderer> ().SetAlpha(0);
		sign_a.GetComponent<CanvasRenderer> ().SetAlpha(0);
		sign_r.GetComponent<CanvasRenderer> ().SetAlpha(0);
		sign_o.GetComponent<CanvasRenderer> ().SetAlpha(0);
	}


	// Update is called once per frame
	void Update () 
	{
		if (scpt_d.isLocated && scpt_u.isLocated && scpt_a.isLocated && scpt_r.isLocated && scpt_o.isLocated)
		{
			letters.SetActive(false);
			logo_fill.GetComponent<Animator>().Play("flash01");
			SwitchToLocated();
		}

		/*
		if (scpt_a.isLocated)
		{
			sign_a.GetComponent<CanvasRenderer> ().SetAlpha (1.0f);
		}
		else
		{
			sign_a.GetComponent<CanvasRenderer> ().SetAlpha(0);
		}
		*/
	}

	void SwitchToLocated()
	{
		StartCoroutine(LateStart(0.3f));

	}


}
