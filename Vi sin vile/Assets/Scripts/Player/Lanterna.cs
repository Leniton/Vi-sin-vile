using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lanterna : MonoBehaviour {

	Vector3 MousePos;
	int lado;
	[SerializeField]Transform axis;
	[SerializeField]GameObject sprite;
	public int original;
	public bool habilidade = false;

	[SerializeField]
	int mult;

	void Start () {
		//print(Vector3.Angle(Vector3.right, new Vector3(3,3,0)));
	}

	// Update is called once per frame
	void Update () {
		if (Camera.main.ScreenToWorldPoint(Input.mousePosition).y - axis.position.y >= 0) 
		{
			lado = 1;
		}
		else
		{
			lado = -1;
		}
		if (Input.GetMouseButtonDown(0) && habilidade)
		{
			StartCoroutine("blink");
		}
		MousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		MousePos = new Vector3(MousePos.x - axis.position.x, MousePos.y - axis.position.y, 0);
		transform.eulerAngles = new Vector3(0, 0, Vector3.Angle((Vector3.right), MousePos)*lado);
		if (Mathf.Abs(MousePos.x) > 0){
			sprite.transform.localScale = new Vector3(-(MousePos.x / Mathf.Abs(MousePos.x)), 1, 1);
		}
		//transform.RotateAround(transform.parent.position, Vector3.forward,(Vector3.Angle((Vector3.right), MousePos)*lado-transform.eulerAngles.z));
	}

	IEnumerator blink()
	{
		original = GetComponent<SpriteMask>().backSortingOrder;
		do
		{
			trocaFiltro(20);
			yield return new WaitForSeconds(Time.deltaTime);
			trocaFiltro(original);
			yield return new WaitForSeconds(Time.deltaTime*mult);
			/*GetComponent<SpriteMask>().enabled = false;
			yield return new WaitForSeconds(Time.deltaTime* mult);
			GetComponent<SpriteMask>().enabled = true;*/
		} while (Input.GetMouseButton(0));
		yield return null;
	}

	void trocaFiltro(int v)
	{
		for (int i = 0; i < transform.parent.GetComponentsInChildren<SpriteMask>().Length; i++)
		{
			transform.parent.GetComponentsInChildren<SpriteMask>()[i].backSortingOrder = v;
		}
	}

}
