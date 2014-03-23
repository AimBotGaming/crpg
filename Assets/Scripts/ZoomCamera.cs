using UnityEngine;
using System.Collections;

public class ZoomCamera : MonoBehaviour {
	
	public Transform player;

	public float min = 3;
	public float max = 7;

	public float speed;

	void Update () {
		float y = Camera.main.orthographicSize;
		float axe = Input.GetAxis ("Mouse ScrollWheel");
		float newY = y + 5f * axe;
		if (newY >= min && newY <= max ) {
			Camera.main.orthographicSize += 5f * Input.GetAxis("Mouse ScrollWheel");
		}
	}
}
