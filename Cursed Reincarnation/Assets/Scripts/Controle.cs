using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controle : MonoBehaviour {

	[SerializeField]
	private Animator heroiAnim;
	private Transform alvo;

	public KeyCode attack;
	public KeyCode roll;
	public KeyCode run;

	void Start(){
	}
		
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown (attack)) {

			heroiAnim.SetBool ("Punch", true);

		} else {
			heroiAnim.SetBool ("Punch", false);
		}

		if (Input.GetKeyDown (roll)) {

			heroiAnim.SetTrigger ("Roll");

		}

		if (Input.GetKey (run)) {

			heroiAnim.SetBool ("Running", true);

		} else {
			heroiAnim.SetBool ("Running", false);
		}
			
	}

	/* morte ao tocar algo
	void OnTriggerEnter(collider col){
		
	}*/
}

