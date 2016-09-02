using UnityEngine;
using System.Collections;

public class Player_health : MonoBehaviour {

	public float maxHealth = 1000;
	public static float currentHealth = 1000;
	private float damage;

	private GameObject enemy;
	private NavMeshAgent agent;

	public Texture2D healthTexture;
	Rect position;

	[SerializeField] private MouseLook m_MouseLook;

	// Use this for initialization
	void Start () {
		position = new Rect(10, 10, 200, healthTexture.height);
		damage = Enemy_move.m_damage_cube;
		print (damage);

		enemy = GameObject.Find("enemy");

	}
	
	// Update is called once per frame
	void Update () {
		position = new Rect(10, 10, currentHealth / 5f, healthTexture.height);
		if (currentHealth <= 0) {
			currentHealth = 0;
			position = new Rect(10, 10, 0, healthTexture.height);
			m_MouseLook.SetCursorLock (false);
			FPS fps = gameObject.GetComponent<FPS> ();
			fps.enabled = false;
			GameObject.Find ("Gun").GetComponent<Shoot> ().enabled = false;
		}
	}

	void OnGUI()
	{
		GUI.DrawTexture(position, healthTexture);
	}
}
