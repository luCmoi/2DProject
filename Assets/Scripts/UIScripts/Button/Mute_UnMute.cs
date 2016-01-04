using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Mute_UnMute : MonoBehaviour {
    private bool mute = false;
    public AudioSource music;
    public AudioSource efxSound;
    public Button button;
    public Sprite muteSprite;
    public Sprite unMuteSprite;

	void Start () {
	
	}
	
	void Update () {
	
	}

    public void OnClick()
    {
        if (!mute)
        {
            music.mute = true;
            efxSound.mute = true;
            mute = true;
            button.image.sprite = muteSprite;
        }
        else
        {
            music.mute = false;
            efxSound.mute = false;
            mute = false;
            button.image.sprite = unMuteSprite;
        }
    }
}
