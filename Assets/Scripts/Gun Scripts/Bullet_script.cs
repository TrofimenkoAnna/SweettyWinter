using UnityEngine;
using System.Collections;

public class Bullet_script : MonoBehaviour {

	//private Vector3 acceleration = Vector3.zero;
	//private Vector3 lastVelocity = Vector3.zero;

	void OnCollisionEnter(Collision collision)
	{
		if (collision.collider) {
			Debug.Log ("collision");

			/*Rigidbody rb = gameObject.GetComponent<Rigidbody> ();
			acceleration = (rb.velocity - lastVelocity) / Time.deltaTime;
			lastVelocity = rb.velocity;
			f = rb.mass * acceleration.magnitude;*/

			Destroy (gameObject, 1);
		}
	}
}
