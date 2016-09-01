using UnityEngine;
using System.Collections;

public class DestroyObj : MonoBehaviour {
	
	void OnCollisionEnter(Collision collision)
	{
		if (collision.collider)
				Destroy (gameObject, 10);
	}
}
