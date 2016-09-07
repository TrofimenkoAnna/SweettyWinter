using UnityEngine;
using System.Collections;

public class DestroyObj : MonoBehaviour {

	public float f;
	private Vector3 acceleration = Vector3.zero;
	private Vector3 lastVelocity = Vector3.zero;
	public int colcount = 0;

	//void OnStart()
	//{
	//	enemy = GameObject.Find ("enemy");
	//}

	void OnCollisionEnter(Collision collision)
	{
		//if (collision.gameObject.tag == "enemy") {
			
		//	Destroy (gameObject, 10);
		//}
		if (collision.collider) {
		//	isCollision = true;
			Rigidbody rb = gameObject.GetComponent<Rigidbody> ();
			acceleration = (rb.velocity - lastVelocity) / Time.deltaTime;
			lastVelocity = rb.velocity;
			f = rb.mass * acceleration.magnitude;
			Destroy (gameObject, 10);
		}
	}
}
