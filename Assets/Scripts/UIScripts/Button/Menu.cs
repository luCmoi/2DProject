using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {
    public GameObject menu;
    private bool open = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnClick()
    {
        if (!open)
        {
            Time.timeScale = 0;
            menu.SetActive(true);
            open = true;
        }
        else
        {
            Time.timeScale = 1;
            menu.SetActive(false);
            open = false;
        }
    }
}
