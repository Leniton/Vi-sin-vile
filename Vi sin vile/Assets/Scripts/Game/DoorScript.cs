using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{

	[SerializeField]
	bool horizontal;
	[SerializeField]
	Transform saida;
    [Space]
    [SerializeField] GameObject blackScreen;
    TopDownMovement movement;
    Camera cam;
	Vector3 cameraPos;
	Vector3 TP;

    void Awake()
    {
        blackScreen = GameObject.Find("Panel");
    }

	void Start()
	{
		cam = Camera.main;
        blackScreen.SetActive(false);
	}

	void OnTriggerEnter2D(Collider2D col)
	{
        if (col.gameObject.tag == "Player")
        {
            movement = col.GetComponent<TopDownMovement>();
            movement.enabled = false;
            blackScreen.GetComponent<Panel_scr>().door = this;
            blackScreen.SetActive(true);
        }

    }

    public void teleport()
    {
        if (movement.gameObject.tag == "Player")
        {
            if (horizontal)
            {
                cameraPos = new Vector3(saida.position.x - 8 * saida.localScale.x, saida.position.y + 2, cam.transform.position.z);
                TP = new Vector3(saida.position.x - (0.5f * saida.localScale.x), saida.position.y + 0.5f, 0);
            }
            else
            {
                int y;
                if (saida.localScale.y >= -1)
                {
                    y = 1;
                }
                else
                {
                    y = 0;
                }
                cameraPos = new Vector3(saida.position.x - 0.5f, (saida.position.y + 5 * saida.localScale.y) + y, cam.transform.position.z);
                TP = new Vector3(saida.position.x - 0.5f, saida.position.y + 1.5f * saida.localScale.y, 0);
            }
            movement.transform.position = TP;
            cam.transform.position = cameraPos;
        }
    }

    public void canMove()
    {
        movement.enabled = true;
    }

}
