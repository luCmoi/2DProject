using UnityEngine;
using System.Collections;

public class Wound : MonoBehaviour {
    public GameObject[] wounds;
    public GameObject[] UIlive;
    public GameObject[] UIliveLost;

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
        UIlive[woundCount].SetActive(false);
        UIliveLost[woundCount].SetActive(true);
        woundCount++;

    }

    public void Activate(int number)
    {
        for (int i =0;i< number; i++)
        {

            UIlive[i].SetActive(true);
            wounds[i].SetActive(false);
            UIliveLost[i].SetActive(false);
        }
    }

    public void Reset()
    {
        for (int i = 0; i < woundCount; i++)
        {
            wounds[i].SetActive(false);
            UIliveLost[i].SetActive(false);
            UIlive[i].SetActive(true);
        }
        woundCount = 0;
    }
}
