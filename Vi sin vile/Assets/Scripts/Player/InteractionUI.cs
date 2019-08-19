using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractionUI : MonoBehaviour {

	[SerializeField]
	Image PressE;

	GameObject Target;

	void Start () {
		//PressE.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.E) && Target != null)
		{
			Target.SendMessage("Interact");
			PopDown();
		}
		else if(PressE.enabled)
		{
			PressE.transform.position = Camera.main.WorldToScreenPoint(transform.position + Vector3.up * 1.5f);
		}
	}

	void PopUp(GameObject target)
	{
		Target = target;
		PressE.enabled = true;
		//print(PressE.enabled);
	}

	void PopDown()
	{
		//print("down");
		PressE.enabled = false;
		Target = null;
	}
}
