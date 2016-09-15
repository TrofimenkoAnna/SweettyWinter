using UnityEngine;
using System.Collections;

public class Enemy_health : MonoBehaviour {
	
	public float currentHealth;

	void OnStart()
	{
		currentHealth = GameObject.Find ("Menu").GetComponent<Menu_script> ().maxHealth_enemy;
	}

	// Update is called once per frame
	void Update () {
		// Death
		if (currentHealth <= 0) {
			currentHealth = 0;
			Renderer rend = gameObject.GetComponent<Renderer> ();
			rend.material.color = Color.red;
			Destroy (gameObject, 3);

		}
	}

	void OnCollisionEnter(Collision collision)
	{
		float damage_gun = GameObject.Find ("Menu").GetComponent<Menu_script> ().damage_gun;

		if ((collision.gameObject.tag == "bullet")) {
			Debug.Log ("Hit");
			currentHealth -= damage_gun;
		}
	}
}
