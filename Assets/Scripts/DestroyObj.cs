using UnityEngine;
using System.Collections;

public class DestroyObj : MonoBehaviour {

	public static float f;
	
	void OnCollisionEnter(Collision collision)
	{
		if (collision.collider) {
			Destroy (gameObject, 10);
		}
	}
}
