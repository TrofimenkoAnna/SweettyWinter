using UnityEngine;
using System.Collections;

public class Enemy_move : MonoBehaviour {

	private Transform hero;

	private NavMeshAgent agent;

	public float maxHealth = 100;
	public float currentHealth = 100;

	private float damage;

	public float damage_cube = 10;
	public static float m_damage_cube = 10;

	// Use this for initialization
	void Start () {
		hero = GameObject.Find ("FPSController").transform;

		agent = GetComponent<NavMeshAgent> ();

		damage = Shoot.damage;
		m_damage_cube = damage_cube;
	}
	
	// Update is called once per frame
	void Update () {
		
		//if (currentHealth > 0) {
			agent.SetDestination (hero.position);
		if (agent.remainingDistance <= agent.stoppingDistance + 0.1f) {
			Player_health.currentHealth -= m_damage_cube; 
		}
		//}

		if (currentHealth <= 0) {
			Renderer rend = gameObject.GetComponent<Renderer> ();
			rend.material.color = Color.red;
			Destroy (gameObject, 3);
		}
			
	}

	void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.tag == "bullet")
		{
			currentHealth -= damage;
		}
	}
}
