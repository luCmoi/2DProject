using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class SelectLevelButton : MonoBehaviour {
    public int number;
    public float textSize = 0.03f;
    public GameObject button;

    // Use this for initialization
    void Start()
    {
        foreach (Text tmp in button.GetComponentsInChildren<Text>())
        {
            tmp.fontSize = (int)(Screen.width * textSize);
        }
    }

    // Update is called once per frame
    void Update () {
	
	}

    public void OnClick()
    {
        switch (number)
        {
            case 1:
                SceneManager.LoadScene(1);
                break;
            case 2:
                SceneManager.LoadScene(2);
                break;
            case 3:
                break;
        }
    }
}
