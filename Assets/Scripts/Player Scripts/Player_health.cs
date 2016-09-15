using UnityEngine;
using System.Collections;

public class Player_health : MonoBehaviour {

	public static float currentHealth;

	public Texture2D healthTexture;
	Rect position; // Health line position 

	private MouseLook m_MouseLook = new MouseLook();

	private Rect position_label; // enemies counter position
	private GUIStyle guiStyle = new GUIStyle();

	// Use this for initialization
	void Start () {
		position_label = new Rect (Screen.width - 50, 10, 20, 10);
		currentHealth = GameObject.Find ("Menu").GetComponent<Menu_script> ().maxHealth_player;
	}
	
	// Update is called once per frame
	void Update () {

		damage ();
		healthLineSize();

		// Death of player in another function
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
		guiStyle.fontSize = 20; 
		//GUI.Label (position_label, death + "/" + Spawn_cubes.m_numberOfEnemies, guiStyle);
	}

	void healthLineSize()
	{
		float line = Screen.width / 4;
		float curX = (100 * currentHealth) / 1000;
		//Debug.Log ("Health " + curX + "%" );
		line = (line * curX) / 100;
		position = new Rect (10, 10, line, healthTexture.height);
	}

	void damage()
	{
		if (GameObject.Find("enemy_cube") != null) {
		NavMeshAgent agent = GameObject.Find("enemy_cube").GetComponent<NavMeshAgent>();

		bool isImmortality = GameObject.Find ("Menu").GetComponent<Menu_script> ().immortality;
		float damage_cube = GameObject.Find ("Menu").GetComponent<Menu_script> ().damage_cube;

			if ((agent.remainingDistance <= agent.stoppingDistance + 1f) && (isImmortality == false)) {
				currentHealth -= damage_cube;
			}
		}
	}
}
