using UnityEngine;
using System.Collections;

public class EggCreator : MonoBehaviour {
    public GameObject egg;
    public float timeSpawnMin;
    public float timeSpawnMax;
    public bool activated = false;
    public float direction = 1;
    public float zpos = 0;

    private float timeLeft;
    private Vector2 originPosition;

	// Use this for initialization
	void Start () {
        originPosition = transform.position;
        timeLeft = timeSpawnMin + (Random.value*(timeSpawnMax-timeSpawnMin));
        
    }
	
	// Update is called once per frame
	void Update () {
        timeLeft -= Time.deltaTime;
    }

    void FixedUpdate()
    {
        if (timeLeft < 0)
        {
            if (transform.GetComponent<Renderer>().isVisible && !activated)
            {
                activated = true;
            }
            if (activated)
            {
                timeLeft = timeSpawnMin + (Random.value * (timeSpawnMax - timeSpawnMin));
                Spawn();
            }
        }
    }

    void Spawn()
    {
        GameObject entity = Instantiate(egg, transform.position, Quaternion.identity) as GameObject;
        entity.GetComponent<EggsNeutralBehavior>().right = direction;
        entity.transform.Translate(Vector3.forward * zpos);
    }
}
