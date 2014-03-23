using UnityEngine;
using System.Collections;

public class MovePlayer : MonoBehaviour {

	public float velocity;

	void FixedUpdate() {
		float h = Input.GetAxis ("Horizontal");
		float v = Input.GetAxis ("Vertical");
		Vector3 move = new Vector3 (h, 0.0f, v);

		Vector3 tr = move * velocity * Time.deltaTime;
		this.transform.Translate (tr);

	}
}
