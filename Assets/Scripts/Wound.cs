using UnityEngine;
using System.Collections;

public class Wound : MonoBehaviour {
    public GameObject[] wounds;
    private int woundCount = 0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Add()
    {
        wounds[woundCount].SetActive(true);
        woundCount++;

    }

    public void Reset()
    {
        for (int i = 0; i < woundCount; i++)
        {
            wounds[i].SetActive(false);
        }
    }
}
