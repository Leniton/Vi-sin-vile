using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu_Buttons : MonoBehaviour {

    [SerializeField] Animator A;
    int toLoad;

	public void MudarCena()
    {
        SceneManager.LoadScene(toLoad);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void fade(int sc)
    {
        A.SetTrigger("Fade");
        toLoad = sc;
    }
    
}
