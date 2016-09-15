using UnityEngine;
using System.Collections;

public class Enemy_move : MonoBehaviour {

	private Transform player;

	private NavMeshAgent agent;

	// Use this for initialization
	void Start () {

		player = GameObject.Find ("FPSController").transform;

		agent = GetComponent<NavMeshAgent> ();

	}
	
	// Update is called once per frame
	void Update () {
		agent.SetDestination (player.position);
	}
}
