using UnityEngine;
using System.Collections;

public class PlayerControler : MonoBehaviour
{
	public float animSpeed = 1.5f;
	public float rotateSpeed = 9.0f;

    private Animator animator;

	void Start()
	{
		animator = GetComponent<Animator> ();
		if(animator.layerCount >=2)
			animator.SetLayerWeight(1, 1);
	}

	void FixedUpdate()
	{
		float v = Input.GetAxis ("Vertical");
		float h = Input.GetAxis ("Horizontal");

		Ray mouseRay = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit look;
		Physics.Raycast (mouseRay, out look);

		if (look.collider.gameObject.tag == "Ground") 
		{
			Vector3 _target = look.point;
			_target.y = transform.position.y;

			transform.LookAt(_target);
		}

		animator.SetFloat ("S_vert", v);
		animator.SetFloat ("S_hori", h);
	}
}