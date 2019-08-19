using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tranca : MonoBehaviour {

	int tipoTranca;
	bool CanOpen;

	GameObject player;

	void Start () {
		tipoTranca = GetComponent<SpriteRenderer>().sortingOrder;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		//print("trigger enter");
		int order = col.GetComponentInChildren<Lanterna>().original;
		if (col.GetComponent<KeyHolder>() != null &&
		   (order >= tipoTranca || order == tipoTranca - 10 || order >= tipoTranca - 11))
		{
            //print("pode ver");
			if (CheckKeys(col.GetComponent<KeyHolder>().keys))
			{
				print("tem a chave;");
				player = col.gameObject;
				col.gameObject.SendMessage("PopUp", gameObject);
			}
		}
	}

	void OnTriggerExit2D(Collider2D col)
	{
		if (col.tag == "Player" && CanOpen)
		{
			player = null;
			col.gameObject.SendMessage("PopDown");
		}
	}

	bool CheckKeys(List<int> keys)
	{
		if (keys.Count > 0)
		{
			for (int i = 0; i < keys.Count; i++)
			{
				if ((keys[i] <= tipoTranca && tipoTranca - keys[i] < 2) || 
				    (keys[i] <= (tipoTranca - 10) && (tipoTranca - 10) - keys[i] < 2))
				{
					CanOpen = true;
					break;
				}
			}
		}
		return CanOpen;
	}

	void Interact()
	{
		int chave = GetComponent<SpriteRenderer>().sortingOrder;
		if (chave >= 10)
		{
			//print("-10");
			chave -= 10;
		}
		if (chave > 0)
		{
			if (Mathf.FloorToInt(chave / 2) == chave / 2)
			{
				chave -= 1;
			}
		}
		player.GetComponent<KeyHolder>().RemoveKey(chave);
		GetComponent<Animator>().enabled = true;
	}

	void Open()
	{
		gameObject.SetActive(false);
	}
}
