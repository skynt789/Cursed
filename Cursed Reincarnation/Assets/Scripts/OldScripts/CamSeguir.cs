using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamSeguir : MonoBehaviour {

	public Transform cabeca;
	public Transform[] pos;
	public int id;
	public Vector3 vel = Vector3.zero;
	private RaycastHit hit;
	private float rotVel, rotacao;
	public Transform player;

	// Use this for initialization
	void Start () {

		rotVel = 75;
		id = 0;
	}

	void Update(){
		
		AjustarCamera ();
		RotacaoCam ();


		/*
		if(Mathf.Abs(Controle.moveY)==0{
			RotacaoCam(cabeca);
		}
			
		else{
			RotacaoCam(player);
		}
		*/

	}
	// Update is called once per frame
	void LateUpdate () {
		
		transform.LookAt (cabeca);
		if (!Physics.Linecast (cabeca.position,pos[id].position)){	
			transform.position = Vector3.SmoothDamp(transform.position,pos[id].position, ref vel, 0.4f);
			Debug.DrawLine(cabeca.position,pos[id].position);

		}else if(Physics.Linecast(cabeca.position, pos[id].position, out hit)){
			transform.position = Vector3.SmoothDamp(transform.position,hit.point, ref vel, 0.4f); 
		}

	}


	void AjustarCamera(){
		if (Input.GetButtonDown ("AjustarCamera") && id < 2) {
			id++;
		} else if (Input.GetButtonDown ("AjustarCamera") && id > 1) {
			id = 0;
		}
	}
				
	void RotacaoCam()
	{
		rotacao = Input.GetAxis ("RotacaoCamera") * rotVel;
		rotacao *= Time.deltaTime;
		cabeca.Rotate(0, rotacao, 0);

	}


	/*
	void RotacaoCam(Transform obj)
	{
		rotacao = Input.GetAxis ("RotacaoCamera") * rotVel;
		rotacao *= Time.deltaTime;
		obj.Rotate(0, rotacao, 0);

	}
	*/
}