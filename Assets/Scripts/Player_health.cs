using UnityEngine;
using System.Collections;

public class Player_health : MonoBehaviour {

	public float maxHealth = 100;
	public float currentHealth = 100;
	private float damage;

	private GameObject enemy;
	private NavMeshAgent agent;

	public Texture2D healthTexture;
	Rect position;

	// Use this for initialization
	void Start () {
		
		position = new Rect(10, 10, healthTexture.width, healthTexture.height);
		damage = Enemy_move.m_damage_cube;
		print (damage);

		enemy = GameObject.Find("enemy");
		//agent = enemy.GetComponent<NavMeshAgent> ();
		//if (agent.remainingDistance < agent.stoppingDistance) {
			//currentHealth -= damage;
		//}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnGUI()
	{
		GUI.DrawTexture(position, healthTexture);
	}
}
