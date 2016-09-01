﻿using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour {
	
	public Transform m_Prefab;
	public float forceSpeed = 3000;
	private Transform prefabInstance;
	
	// Update is called once per frame
	void Update () {
		
		if (Input.GetMouseButtonDown(0))
		{
			fire();	
		}

	}

	void fire()
	{
		Vector3 directionRay = transform.TransformDirection(Vector3.forward);
		prefabInstance = (Transform) Instantiate(m_Prefab, GameObject.Find("bullet_point").transform.position, Quaternion.identity);
		Rigidbody rb = prefabInstance.GetComponent<Rigidbody>();
		rb.AddForce(directionRay * forceSpeed);
	}
}