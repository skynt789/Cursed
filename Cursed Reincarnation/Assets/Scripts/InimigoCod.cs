using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class InimigoCod : MonoBehaviour {

	public float patrulhaTempo = 12;
	private WaitForSeconds tempo;
	public Transform[] waypoints;
	private int index;
	private Animator anim;
	private NavMeshAgent agent;

	//seguir pers
	[SerializeField]
	private GameObject player;
	private bool pegaEle = false;

	[SerializeField]
	private float dist = 5;

	[SerializeField]
	private float distAtaque;

	public bool ataca = false;

	// Use this for initialization
	void Start () {
		tempo = new WaitForSeconds (patrulhaTempo);
		agent = GetComponent<NavMeshAgent>();
		index = Random.Range (0, waypoints.Length);
		anim = GetComponent<Animator>();
		StartCoroutine (ChamaPatrulha());

		distAtaque = agent.stoppingDistance;
	}

	private void Update(){
		anim.SetFloat("mover",agent.velocity.sqrMagnitude,0.05f,Time.deltaTime);

		PegaHeroi();

		InimigoAtaque ();
	}

	IEnumerator ChamaPatrulha(){
		while (true) {
			yield return tempo;
			Patrol ();
		}
	}

	void Patrol(){
		index = index == waypoints.Length - 1 ? 0 : index + 1;
		agent.destination = waypoints[index].position;

	}
	//seguir pers
	void PegaHeroi(){
		if (player != null && Vector3.Distance (transform.position, player.transform.position) < dist && !pegaEle) {
			pegaEle = true;
		} else if (Vector3.Distance (transform.position, player.transform.position) > dist) {
			pegaEle = false;
		}

		if (pegaEle) {
			agent.destination = player.transform.position;
		}

	}

	void InimigoAtaque(){
		if (player != null & Vector3.Distance (transform.position, player.transform.position) <= distAtaque && pegaEle) {
			anim.SetBool ("atacar", true);
			ataca = true;
		} else if (player != null && Vector3.Distance (transform.position, player.transform.position) > distAtaque && pegaEle) {
			anim.SetBool ("atacar", false);
			ataca = false;
		}

		if (ataca) {
			agent.speed = 0;
			agent.isStopped = true;
		} else {
			agent.speed = 2;
			agent.isStopped = false;
		}
	}

	void AnulaAtaque(){
	
		ataca = false;
	
	}

/*	private void OnDrawGizmos(){
		Gizmos.color = Color.green;
		Gizmos.DrawWireSphere (transform.position, dist);
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere (transform.position, distAtaque);
	}
*/
}
