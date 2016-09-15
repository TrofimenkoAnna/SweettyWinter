using UnityEngine;
using System.Collections;

public class Enemy_health : MonoBehaviour {
	
	public float currentHealth;
	public static int death = 0;
	public static int death_wave = 0;

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

	void OnDestroy()
	{
		death_wave++;
		death++;
		Debug.Log ("death " + death);
	}

	void OnCollisionEnter(Collision collision)
	{
		float damage_gun = GameObject.Find ("Menu").GetComponent<Menu_script> ().damage_gun;
		Bullet_script bullet_script = GameObject.Find ("Gun").GetComponent<Shoot> ().bullet_script;
		if ((collision.gameObject.tag == "bullet") && (bullet_script.flag <= 2)) {
			Debug.Log (bullet_script.flag);
				currentHealth -= damage_gun;
			}
	}
}
