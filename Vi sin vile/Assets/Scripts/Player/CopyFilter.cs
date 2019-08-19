using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopyFilter : MonoBehaviour {

	[SerializeField]SpriteMask lanterna,visao;
	public bool dev;

	void Start () {
		visao = GetComponent<SpriteMask>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Space) && dev)
		{
			AtualizarFiltro();
		}
	}

	public void AtualizarFiltro()
	{
		visao.backSortingOrder+=2;
		lanterna.backSortingOrder = visao.backSortingOrder;
		lanterna.gameObject.GetComponent<Lanterna>().original = visao.backSortingOrder;
	}


}
