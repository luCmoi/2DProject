using UnityEngine;
using System.Collections;

public class PlatformSpawner : MonoBehaviour {
    public float xMin;
    public float xMax;
    public GameObject platform;
    public float timeSpawnMin;
    public float timeSpawnMax;
    public float directionX;
    public float directionY;
    public float vitesseMin;
    public float vitesseMax;
    public float ypos;
    public float zpos;

    private float timeLeft;
    public bool activated = false;
    // Use this for initialization
    void Start()
    {
        timeLeft = timeSpawnMin + (Random.value * (timeSpawnMax - timeSpawnMin));

    }

    // Update is called once per frame
    void Update()
    {
        timeLeft -= Time.deltaTime;
    }

    void FixedUpdate()
    {
        if (timeLeft < 0)
        {
            if (activated)
            {
                timeLeft = timeSpawnMin + (Random.value * (timeSpawnMax - timeSpawnMin));
                Spawn();
            }
        }
    }

    void Spawn()
    {
        GameObject entity = Instantiate(platform, new Vector3(xMin + (Random.value * (xMax - xMin)),ypos,zpos), Quaternion.identity) as GameObject;
        entity.GetComponent<MovingPlatform>().movingX = directionX;
        entity.GetComponent<MovingPlatform>().movingY = directionY;
        entity.GetComponent<MovingPlatform>().duration = vitesseMin + (Random.value * (vitesseMax - vitesseMin));
        entity.GetComponent<MovingPlatform>().delay = 0;
        entity.transform.Translate(Vector3.forward * zpos);
    }
}
