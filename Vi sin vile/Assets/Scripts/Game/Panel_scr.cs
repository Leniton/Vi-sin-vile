using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Panel_scr : MonoBehaviour {

    public DoorScript door;

    public void OrdemTP()
    {
        door.teleport();
    }

    public void Fim()
    {
        door.canMove();
        gameObject.SetActive(false);
    }
	
}
