using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameUtilities : MonoBehaviour {
    public static GameUtilities Instance;

    public int level;
    public GameObject textPlace;
    public GameObject portrait;
    public Text textName;
    public Text textShown;
    public bool dontMove;
    public float fontNameSize;
    public GameObject menu;
    public float menuFontSize;
    public GameData data;

    void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("Multiple instances of GameUtilities!");
        }
        Instance = this;
        GameObject objectData = GameObject.Find("GameData");
        data = objectData.GetComponent<GameData>();
        data.level = level;
        textPlace.SetActive(false);
        dontMove = false;
        textName.fontSize = (int)(Screen.width * fontNameSize);
        ReloadText();
    }

    public void ReloadText()
    {
        foreach (Text txtTmp in menu.GetComponentsInChildren<Text>())
        {
            txtTmp.fontSize = (int)(Screen.width * menuFontSize);
            if (txtTmp.tag == "bonusLife")
            {
                txtTmp.text = data.levels[0][0] + "/" + data.levels[0][1];
            }
            else if (txtTmp.tag == "page")
            {
                txtTmp.text = data.levels[0][2] + "/" + data.levels[0][3];
            }
        }
    }
}
