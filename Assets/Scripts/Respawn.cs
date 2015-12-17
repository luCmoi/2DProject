using UnityEngine;
using System.Collections;

public class Respawn : MonoBehaviour {
    public Vector3 positionRespawn;
    public GameObject hero;
    public GameObject cameraPrincipal;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Die()
    {
        transform.position = positionRespawn;
        cameraPrincipal.GetComponent<CameraAttitude>().MoveTo(positionRespawn);
        hero.GetComponent<Health>().restoreHpMax();
    }
}
