using UnityEngine;
using System.Collections;

[RequireComponent(typeof (CharacterController))]
public class Health : MonoBehaviour {

	public float maxHealth = 100;
	public float currentHealth = 100;
	public float damage = 40;

	public float speed = 16.0F;
	public float gravity = 20.0F;
	private Vector3 moveDirection = Vector3.zero;
	private CharacterController m_CharacterController; 
	private GameObject hero;

	// Use this for initialization
	void Start () {
		hero = GameObject.Find ("FPSController");
	}
	
	// Update is called once per frame
	void Update () {
		CharacterController controller = GetComponent<CharacterController>();
		if (controller.isGrounded) {
			moveDirection = hero.transform.position;
			moveDirection *= -1;
			//moveDirection = transform.TransformDirection(moveDirection);
			//moveDirection *= speed;
			//moveDirection = Vector3.ClampMagnitude(moveDirection, speed);
			moveDirection.y = 2;
		}

		moveDirection.y -= gravity * Time.deltaTime;
		controller.Move(moveDirection * Time.deltaTime);

		if (currentHealth >= 200)
			currentHealth = maxHealth;

		if (currentHealth <= 0) {
			currentHealth = 0;
			Renderer rend = gameObject.GetComponent<Renderer> ();
			rend.material.color = Color.red;
			Destroy (gameObject, 3);
		}
	}

	void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.tag == "bullet")
		{
			currentHealth -= damage;
		}
	}
}
