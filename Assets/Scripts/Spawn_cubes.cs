using UnityEngine;
using System.Collections;

public class Spawn_cubes : MonoBehaviour {

	public int numberOfEnemies = 1;
	public GameObject pref;

	// Use this for initialization
	void Start () {
		for (int i = 1; i <= numberOfEnemies; i++) {
			Vector3 pos = new Vector3 (Random.Range (0f, 150f), 3, Random.Range (0f, 150f));
			Instantiate (pref, pos, Quaternion.identity);
		}
	}
}
