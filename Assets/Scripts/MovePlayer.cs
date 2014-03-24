using UnityEngine;
using System.Collections;

public class MovePlayer : MonoBehaviour 
{
	public float speedWalk;
	public float runMultiplier;

	void FixedUpdate() 
	{
		float h = Input.GetAxis ("Horizontal");
		float v = Input.GetAxis ("Vertical");

		rigidbody.velocity = new Vector3 
		(
			h * speedWalk * Time.deltaTime,
			0.0f,
			v * speedWalk * Time.deltaTime
		);
	}
}
