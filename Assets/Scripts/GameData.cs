using UnityEngine;
using System.Collections;

public class GameData : MonoBehaviour {
    public static GameData Instance;
    public int level;
    public int[][] levels = new int[3][];
    public bool[][] bonusCollected = new bool[3][];

    void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("Multiple instances of SpecialEffectsHelper!");
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(this);
            for (int i = 0; i< levels.Length; i++)
            {
                levels[i] = new int[4];
            }
            bonusCollected[0] = new bool[4];
            initPartie(levels);
        }
    }

    void initPartie(int[][] levels)
    {
        levels[0][1] = 2;
        levels[0][3] = 2;
        for(int i = 0; i < bonusCollected.Length; i++)
        {
            bonusCollected[0][i] = false;
        }
    }

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
