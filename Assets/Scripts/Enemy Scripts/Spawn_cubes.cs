using UnityEngine;
using System.Collections;

public class Spawn_cubes : MonoBehaviour {

	public GameObject pref;
	// Use this for initialization
	void Start () {
		
		int number = GameObject.Find("Menu").GetComponent<Menu_script>().numberOfEnemies;
		for (int i = 1; i <= number;  i++) {
			Vector3 pos = new Vector3 (Random.Range (0f, 150f), 3, Random.Range (0f, 150f));
			Instantiate (pref, pos, Quaternion.identity);
		}
	}
}
