using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SelectLevelUtilities : MonoBehaviour {
    private GameData data;
    private SelectLevelUtilities Instance;
    public GameObject[] buttons;
    void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("Multiple instances of GameUtilities!");
        }
        Instance = this;
        GameObject objectData = GameObject.Find("GameData");
        data = objectData.GetComponent<GameData>();
        data.level = -1;
        int i = 0;
        foreach (GameObject button in buttons)
        {
            foreach (RectTransform child in button.transform)
            {
                if (child.tag == "bonusLife")
                {
                    child.GetComponent<Text>().text = data.levels[i][0] + "/" + data.levels[i][1];
                }
                else if (child.tag == "page")
                {
                    child.GetComponent<Text>().text = data.levels[i][2] + "/" + data.levels[i][3];
                }
            }
            i++;
        }
    }
        // Use this for initialization
        void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
