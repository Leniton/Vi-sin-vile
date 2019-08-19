using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyHolder : MonoBehaviour {

	public List<int> keys;

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void AddKey(int key)
	{
		keys.Add(key);
	}

	public void RemoveKey(int key)
	{
		//print("chave: "+key);
        //print("index: "+keys.IndexOf(key));
		if (keys.Remove(key))
		{
			print("removeu");
		}

	}
}
