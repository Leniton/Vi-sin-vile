using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class VFiltroDoor : MonoBehaviour
{

	[SerializeField]
	GameObject Player;
	bool trig;



	void Update()
	{
		if (!trig)
		{
			if (GetComponent<SpriteRenderer>() != null)
			{
				if (Player.GetComponentInChildren<Lanterna>().original >= GetComponent<SpriteRenderer>().sortingOrder - 10)
				{
					GetComponent<SpriteRenderer>().maskInteraction = SpriteMaskInteraction.None;
					trig = true;
				}
			}
			else if (GetComponent<TilemapRenderer>() != null)
			{
				if (Player.GetComponentInChildren<Lanterna>().original >= GetComponent<TilemapRenderer>().sortingOrder - 10)
				{
					GetComponent<TilemapRenderer>().maskInteraction = SpriteMaskInteraction.None;
					trig = true;
				}
			}
		}
	}
}
