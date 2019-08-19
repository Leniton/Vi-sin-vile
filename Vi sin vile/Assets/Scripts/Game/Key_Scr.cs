using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key_Scr : MonoBehaviour {

	GameObject player;

	int Tipo;

	void Start () {
		Tipo = GetComponent<SpriteRenderer>().sortingOrder;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		int order = col.GetComponentInChildren<Lanterna>().original;
		if (col.tag == "Player" && order >= Tipo)
		{
			col.gameObject.SendMessage("PopUp", gameObject);
			player = col.gameObject;
		}
	}

	void OnTriggerExit2D(Collider2D col)
	{
		int order = col.GetComponentInChildren<Lanterna>().original;
		if (col.tag == "Player" && order >= Tipo)
		{
			col.gameObject.SendMessage("PopDown");
			player = null;
		}
	}

	void Interact()
	{
		player.GetComponent<KeyHolder>().AddKey(GetComponent<SpriteRenderer>().sortingOrder);
		GetComponent<Animator>().SetTrigger("get");
	}

	void Open()
	{
		Destroy(gameObject);
	}
}
