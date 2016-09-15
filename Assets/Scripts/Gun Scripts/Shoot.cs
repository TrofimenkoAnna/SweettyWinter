using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour {
	
	public Transform bullet;
	private Transform prefabInstance;
	public Bullet_script bullet_script;

	// Update is called once per frame
	void Update () {
		
		if (Input.GetMouseButtonDown(0))
		{
			fire();	
		}

	}

	void fire()
	{
		float forceSpeed = GameObject.Find ("Menu").GetComponent<Menu_script> ().forceSpeed;

		Vector3 directionRay = transform.TransformDirection(Vector3.forward);
		prefabInstance = (Transform) Instantiate(bullet, GameObject.Find("bullet_point").transform.position, Quaternion.identity);
		Rigidbody rb = prefabInstance.GetComponent<Rigidbody>();
		rb.AddForce(directionRay * forceSpeed);
		bullet_script = prefabInstance.GetComponent<Bullet_script> () as Bullet_script;
	}
}