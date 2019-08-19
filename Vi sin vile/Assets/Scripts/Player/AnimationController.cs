using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour {

	[SerializeField]
	Animator anim;

	void Start()
	{
		
	}

	void Update () {
		if (GetComponent<TopDownMovement>().isMoving())
		{
			anim.SetFloat("Speed", 1);
		}
		else
		{
			anim.SetFloat("Speed", 0);
		}
	}
}
