using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameUtilities : MonoBehaviour {
    public static GameUtilities Instance;

    public GameObject textPlace;
    public GameObject portrait;
    public Text textName;
    public Text textShown;
    public bool dontMove;


    void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("Multiple instances of GameUtilities!");
        }
        Instance = this;
        textPlace.SetActive(false);
        dontMove = false;
    }
}
