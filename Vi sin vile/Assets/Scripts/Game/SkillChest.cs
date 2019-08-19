using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillChest : MonoBehaviour
{
	[SerializeField]
	GameObject mouseUI;
	GameObject player;

	// Use this for initialization
	void Awake()
	{
		GetComponent<Animator>().enabled = false;
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.tag == "Player")
		{
			col.gameObject.SendMessage("PopUp", gameObject);
			player = col.gameObject;
		}
	}

	void OnTriggerExit2D(Collider2D col)
	{
		if (col.tag == "Player")
		{
			col.gameObject.SendMessage("PopDown");
			player = null;
		}
	}

	void Interact()
	{
		player.GetComponentInChildren<Lanterna>().habilidade = true;
		GetComponent<Animator>().enabled = true;
	}

	void Open()
	{
		mouseUI.SetActive(true);
		Destroy(gameObject);	}
}
