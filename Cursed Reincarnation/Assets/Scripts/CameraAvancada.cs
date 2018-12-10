using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAvancada : MonoBehaviour {

	public Vector3 cameraMoveVel = Vector3.zero;
	public GameObject segueOBJ;
	public float limiteAng = 65.0f;
	public float inputSens = 155.0f;
	public float mouseAngX, mouseAngY;
	public float rotX = 0.0f, rotY = 0.0f;
	public Vector3 rot;
	private Quaternion localRot;

	public Transform[] posCam;
	public int id;
	public Camera cam;

	// Use this for initialization
	void Start () {
		Init ();
		transform.position = posCam [id].position;
	}
	
	// Update is called once per frame
	void Update () {
		Atualizacao ();
	}

	void AjustarCamera(){
		if (Input.GetButtonDown ("AjustarCamera") && id < 2) {
			id++;
		} else if (Input.GetButtonDown ("AjustarCamera") && id > 1) {
			id = 0;
		}
		cam.transform.position = Vector3.SmoothDamp (cam.transform.position, posCam [id].position, ref cameraMoveVel, 0.1f);
	}

	void Init() {
		rot = transform.localRotation.eulerAngles;
		rotX = rot.x;
		rotY = rot.y;

	}

	void Atualizacao(){
		mouseAngX = Input.GetAxis ("CamRot");
		mouseAngY = Input.GetAxis ("CamRot2");

		rotX += mouseAngY * inputSens * Time.deltaTime; 
		rotY += mouseAngX * inputSens * Time.deltaTime;

		rotX = Mathf.Clamp (rotX, -limiteAng, limiteAng);
		localRot = Quaternion.Euler (rotX, rotY, 0);
		transform.rotation = localRot;
	}

	void LateUpdate(){
		transform.position = Vector3.SmoothDamp (transform.position, segueOBJ.transform.position, ref cameraMoveVel, 0.1f);
		AjustarCamera ();
	}

}
