using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseClick_UI : MonoBehaviour {

	int count;

	void Update () {
		if (Input.GetMouseButtonUp(0) && gameObject.activeSelf)
		{
			count++;
			if (count >= 2)
			{
				Destroy(gameObject);
			}
		}
	}
}
