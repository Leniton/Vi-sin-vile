using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class End_script : MonoBehaviour {

    [SerializeField] Menu_Buttons end;
    [SerializeField] Image fade;
    [SerializeField] Text Tfade;
    [SerializeField] float fadeSpeed;

    Color Icor;
    Color Tcor;

	void OnTriggerEnter2D (Collider2D c) {
        if(c.tag == "Player")
        {
            if(c.GetComponentInChildren<Lanterna>().original >= 8)
            {

                StartCoroutine("Obrigado");
            }
        }
        print("Fim");
	}

    void Start()
    {
        Icor = fade.color;
        Tcor = Tfade.color;

        Icor.a = 0;
        Tcor.a = 0;
    }

    IEnumerator Obrigado()
    {
        do{
            Icor.a = Icor.a + fadeSpeed;
            Tcor.a = Tcor.a + fadeSpeed;

            fade.color = Icor;
            Tfade.color = Tcor;

            yield return new WaitForSeconds(Time.deltaTime);
        } while (fade.color.a < 1);
        yield return new WaitForSeconds(1.0f);
        end.fade(0);

    }

}
