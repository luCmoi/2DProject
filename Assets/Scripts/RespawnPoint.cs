using UnityEngine;
using System.Collections;

public class RespawnPoint : MonoBehaviour {
    public Vector3 newPosition;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Crossed(GameObject hero)
    {
        hero.GetComponent<Respawn>().positionRespawn = newPosition;
    }
}
