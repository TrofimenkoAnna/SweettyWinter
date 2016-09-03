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

	private Rect position_label;
	private GUIStyle guiStyle = new GUIStyle();
	private float death = 0;

	// Use this for initialization
	void Start () {
		damage = Enemy_move.m_damage_cube;

		enemy = GameObject.Find("enemy");

		position_label = new Rect (Screen.width - 50, 10, 20, 10);

	}
	
	// Update is called once per frame
	void Update () {
		
		healthLineSize();

		if (currentHealth <= 0) {
			currentHealth = 0;
			position = new Rect(10, 10, 0, healthTexture.height);
			m_MouseLook.SetCursorLock (false);
			FPS fps = gameObject.GetComponent<FPS> ();
			fps.enabled = false;
			GameObject.Find ("Gun").GetComponent<Shoot> ().enabled = false;

			death = Enemy_move.death;
		}
	}

	void OnGUI()
	{
		GUI.DrawTexture(position, healthTexture);
		guiStyle.fontSize = 20; 
		GUI.Label (position_label, death + "/" + Spawn_cubes.m_numberOfEnemies, guiStyle);
	}

	void healthLineSize()
	{
		float line = Screen.width / 4;
		float curX = (100 * currentHealth) / 1000;
		print (curX);
		line = (line * curX) / 100;
		position = new Rect (10, 10, line, healthTexture.height);
	}
}
