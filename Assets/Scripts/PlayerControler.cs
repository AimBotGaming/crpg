﻿using UnityEngine;
using System.Collections;

public class PlayerControler : MonoBehaviour
{
	public float animSpeed = 1.5f;

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

		animator.SetFloat ("S_vert", v);
		animator.SetFloat ("S_hori", h);
	}
}