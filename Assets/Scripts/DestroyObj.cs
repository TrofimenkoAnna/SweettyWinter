using UnityEngine;
using System.Collections;

public class DestroyObj : MonoBehaviour {

	public float f;
	
	void OnCollisionEnter(Collision collision)
	{
		if (collision.collider)
				Destroy (gameObject, 10);
	}
}
