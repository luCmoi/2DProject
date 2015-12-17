using UnityEngine;
using System.Collections;

public class MovingPlatform : MonoBehaviour {
    public float movingX;
    public float movingY;
    public float delay;
    public float duration;

    private float vitesseX;
    private float vitesseY;
    private Vector3 lastPos;
    private float timeleft;
    private float zpos;


    // Use this for initialization
    void Start() {
        lastPos = transform.position;
        zpos = transform.position.z;
        timeleft = 0;
    }

    // Update is called once per frame
    void Update() {
        if (delay >= 0)
        {
            delay -= Time.deltaTime;
        }
        else
        {
            if (timeleft <= 0)
            {
                timeleft = duration;
                lastPos = transform.position;
                movingX = -movingX;
                movingY = -movingY;
                vitesseX = movingX / duration;
                vitesseY = movingY / duration;
            }
            else
            {
                timeleft -= Time.deltaTime;
            }
        }
    }

    void FixedUpdate()
    {
        if (delay < 0) { 
        {
            transform.position = new Vector3(lastPos.x + (vitesseX * (duration - timeleft)), lastPos.y + (vitesseY * (duration - timeleft)),zpos);
        }
    }
}


    void OnTriggerEnter2D(Collider2D collider)
    {
        EndFlyingPlatform endFlying = collider.gameObject.GetComponent<EndFlyingPlatform>();
        if (endFlying != null)
        {
            Destroy(gameObject);
        }
    }
}
