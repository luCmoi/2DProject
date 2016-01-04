using UnityEngine;
using System.Collections;

public class PopPlatformStartEnd : MonoBehaviour {
    public bool start;
    public PlatformSpawner[] spawner;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Play()
    {
        foreach (PlatformSpawner spawn in spawner)
        {
            if (start)
            {
                spawn.activated = true;
            }
            else
            {
                spawn.activated = false;
            }
        }
    }
}
