using UnityEngine;
using System.Collections;

public class DestroyObj : MonoBehaviour {

	public static float f;
	private Vector3 acceleration = Vector3.zero;
	private Vector3 lastVelocity = Vector3.zero;
	
	void OnCollisionEnter(Collision collision)
	{
		
		if (collision.collider) {
			Rigidbody rb = gameObject.GetComponent<Rigidbody> ();
			acceleration = (rb.velocity - lastVelocity) / Time.deltaTime;
			lastVelocity = rb.velocity;
			f = rb.mass * acceleration.magnitude;
			print(f+"___"+acceleration);
			Destroy (gameObject, 10);
		}
	}
}
