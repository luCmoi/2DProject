using UnityEngine;
using System.Collections;

public class EndSpawner : MonoBehaviour {
    public GameObject[] spawners;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	}

    public void EndSpawnerActivate()
    {
        foreach (GameObject spawn in spawners)
        {
            spawn.GetComponent<EggCreator>().activated = false;
        }
    }
}
