using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxFiltro : MonoBehaviour
{

	GameObject player;

	// Use this for initialization
	void Awake()
	{
		GetComponent<Animator>().enabled = false;
	}

	// Update is called once per frame
	void Update()
	{

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
		player.GetComponentInChildren<CopyFilter>().AtualizarFiltro();
		GetComponent<Animator>().enabled = true;
	}

	void Open()
	{
		Destroy(gameObject);
	}
}
