using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Pause_UnPause : MonoBehaviour {
    public Button pauseButton;
    public Sprite pauseSprite;
    public Sprite unPauseSprite;

    private bool pause = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnClick()
    {
        if (!pause)
        {
            Time.timeScale = 0;
            pauseButton.image.sprite = pauseSprite;
            pause = true;
        }
        else
        {
            Time.timeScale = 1;
            pauseButton.image.sprite = unPauseSprite;
            pause = false;
        }
    }
}
