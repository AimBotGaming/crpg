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
			animator.SetLayerWeight (1, 1);
	}

	void FixedUpdate()
	{
		float v = Input.GetAxis ("Vertical");
		float h = Input.GetAxis ("Horizontal");
        float ts = Input.GetAxis ("Sprint");
		float rhp = Input.GetAxisRaw ("RHandPow");


        bool s;
        if (ts > 0) s = true;
        else s = false;

		bool rHandPow;
		if (rhp == 1) rHandPow = true;
		else rHandPow = false;


        Rotate();

		animator.SetFloat ("S_vert", v);
		animator.SetFloat ("S_hori", h);
        animator.SetBool ("Sprint", s);
		animator.SetBool ("LowAtk", rHandPow);
	}

    void Rotate()
    {
		Vector3 MouseWorldPosition = Camera.main.ScreenToWorldPoint
		(new Vector3(
			Input.mousePosition.x,
			Input.mousePosition.y,
			(transform.position - Camera.main.transform.position).magnitude
		));
		transform.LookAt (MouseWorldPosition);
		transform.rotation = Quaternion.Euler (new Vector3 (0, transform.rotation.eulerAngles.y, 0));
    }
}