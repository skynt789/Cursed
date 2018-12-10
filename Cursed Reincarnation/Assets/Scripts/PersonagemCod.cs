using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonagemCod : MonoBehaviour {


	public float InputX, InputZ;
	public Vector3 dirMoveDesejada;
	public float velRotDesejada = 0.1f;
	public Animator anim;
	public float Speed;
	public float permiteRotPlayer = 0.3f;
	public Camera cam;
	public float verticalVel;
	public Vector3 moveVector;


	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		cam = Camera.main;
	}
	
	// Update is called once per frame
	void Update () {
		InputMagnitude ();	
	}

	void PlayerMoveRot(){
		Quaternion rot = new Quaternion (0, 0, 0, 0);

		InputX = Input.GetAxis ("HorizontalMove");
		InputZ = Input.GetAxis ("VerticalMove");

		Vector3 frente = cam.transform.forward;
		Vector3 direita = cam.transform.right;

		frente.Normalize ();
		direita.Normalize ();

		dirMoveDesejada = frente * InputZ + direita * InputX;
		rot = Quaternion.Lerp (transform.rotation,Quaternion.LookRotation(dirMoveDesejada),velRotDesejada);
		transform.rotation = new Quaternion (0, rot.y, 0, rot.w);
	}

	void InputMagnitude(){
		InputX = Input.GetAxis ("HorizontalMove");
		InputZ = Input.GetAxis ("VerticalMove");

		anim.SetFloat ("Z", InputZ, 0.0f, Time.deltaTime * 2);
		anim.SetFloat ("X", InputZ, 0.0f, Time.deltaTime * 2);

		Speed = new Vector2 (InputX, InputZ).sqrMagnitude;

		if(Speed > permiteRotPlayer){
			anim.SetFloat ("InputMagnitude", Speed, 0.1f, Time.deltaTime);
			PlayerMoveRot ();
		}
		else if(Speed < permiteRotPlayer){
			anim.SetFloat ("InputMagnitude", Speed, 0.1f, Time.deltaTime);			
		}
	}
}
