using UnityEngine;
using System.Collections;

public class PlayerControler : MonoBehaviour
{
	public float animSpeed = 1.5f;
	public float rotateSpeed = 9.0f;
	public double dir;

    private Animator animator;

	void Start()
	{
		animator = GetComponent<Animator> ();
		if(animator.layerCount >=2)
			animator.SetLayerWeight (1, 1);
	}

	void FixedUpdate()
	{
		//float v = Input.GetAxis ("Vertical");       //Vertical movement
		//float h = Input.GetAxis ("Horizontal");     //Horizontal movement
        float ts = Input.GetAxis ("Sprint");        //Is player sprining
		float rhp = Input.GetAxisRaw ("RHandPow");  //Power attack with right hand


        //bool s;
        //if (ts > 0) s = true;
        //else s = false;

		bool rHandPow;
		if (rhp == 1) rHandPow = true;
		else rHandPow = false;

		dir = Direction();
        Rotate();

		//animator.SetFloat ("S_vert", v);
		//animator.SetFloat ("S_hori", h);
        animator.SetFloat ("Sprint", ts);
		animator.SetBool ("LowAtk", rHandPow);
	}

    void Rotate()
    {
        Plane playerPlane = new Plane(Vector3.up, transform.position);
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        float hit = 0.0f;

        if(playerPlane.Raycast(ray, out hit))
        {
            Vector3 target = ray.GetPoint(hit);
            Quaternion targetRotation = Quaternion.LookRotation(target - transform.position);

            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotateSpeed * Time.deltaTime);
        }

    }

	double Direction(){
		double vert = 0, hori = 0;
		if(Input.GetAxis("Vertical") > 0.1) vert = 0;
		else if(Input.GetAxis("Vertical") < -0.1) vert = 180;
		else if(Input.GetAxis("Vertical") == 0) vert = 0;
		if(Input.GetAxis("Horizontal") > 0.1) hori = 90;
		else if(Input.GetAxis("Horizontal") < -0.1) hori = -90;
		else if(Input.GetAxis("Horizontal") == 0) hori = 0;
		double rawDir = 0;
		if((Input.GetAxis("Vertical") !=0)&&(Input.GetAxis("Horizontal") > 0)){
			rawDir = (vert+hori)/2;
		}
		if((Input.GetAxis("Vertical") !=0)&&(Input.GetAxis("Horizontal") < 0)){
			rawDir = (vert-hori)/-2;
		}
		if((Input.GetAxis("Vertical") ==0)&&(Input.GetAxis("Horizontal") != 0)){
			rawDir = hori;
		}
		if((Input.GetAxis("Vertical") !=0)&&(Input.GetAxis("Horizontal") == 0)){
			rawDir = vert;
		}
		if((Input.GetAxis("Vertical") ==0)&&(Input.GetAxis("Horizontal") == 0)){
			rawDir = 9001;
		}
		if(rawDir > 180) rawDir = rawDir - 360;
		return rawDir;
	}
}