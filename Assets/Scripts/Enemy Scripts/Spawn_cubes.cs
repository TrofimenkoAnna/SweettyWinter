using UnityEngine;
using System.Collections;

public class Spawn_cubes : MonoBehaviour {

	public GameObject pref;
	private int number;
	// Use this for initialization
	void Start () {
		number = GameObject.Find("Menu").GetComponent<Menu_script>().numberOfEnemies;
		spawn ();
	}

	void Update()
	{
		if (Enemy_health.death_wave == number) {
			number *= 2;
			Enemy_health.death_wave = 0;
			spawn ();
		}
	}

	void spawn()
	{
		for (int i = 1; i <= number;  i++) {
			Vector3 pos = new Vector3 (Random.Range (0f, 150f), 3, Random.Range (0f, 150f));
			Instantiate (pref, pos, Quaternion.identity);
		}
	}
}
