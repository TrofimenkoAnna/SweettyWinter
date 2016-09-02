using UnityEngine;
using System.Collections;

public class CloningFence : MonoBehaviour {

	private Vector3 posFence;
	private Quaternion fence_rot;

	// Use this for initialization
	void Start () {
		GameObject fence = GameObject.Find("fence_double");

		posFence.x = 18;
		while (posFence.x <= 200)
		{
			posFence.x += 18;
			Instantiate(fence, posFence, Quaternion.identity);
		}

		posFence.x = 0;
		fence_rot = Quaternion.Euler(0, 90, 0);
		posFence.z = -18;

		while (posFence.z <= 182)
		{
			posFence.z += 18;
			Instantiate(fence, posFence, fence_rot);
		}

		fence_rot = Quaternion.Euler(0, 180, 0);
		posFence.x = -18;
		posFence.z += 18;

		while (posFence.x <= 182)
		{
			posFence.x += 18;
			Instantiate(fence, posFence, fence_rot);
		}

		posFence.z += 18;
		posFence.x += 18;
		fence_rot = Quaternion.Euler(0, 270, 0);

		while (posFence.z >= 36)
		{
			posFence.z -=18;
			Instantiate(fence, posFence, fence_rot);
		}

	}
}
