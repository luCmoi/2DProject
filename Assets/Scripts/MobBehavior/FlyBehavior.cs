using UnityEngine;
using System.Collections;

public class FlyBehavior : MonoBehaviour {
    public bool moveX;
    public float distance;
    public float oscillation;
    public float speed;

    public Vector2 positionBase;
    public bool firstDirection;
    public bool firstOscillation;
    public Rigidbody2D rgbd2d;
    void Start () {
        firstDirection = true;
        firstOscillation = true;
        positionBase = transform.position;
        rgbd2d = GetComponent<Rigidbody2D>();
        rgbd2d.AddForce(new Vector2(speed, speed));
	}
	
	void Update () {
    }

    void FixedUpdate()
    {
        if (moveX)
        {
            if (firstDirection)
            {
                if (transform.position.x >= distance + positionBase.x)
                {
                    transform.Rotate(0f, 180, 0f);
                    firstDirection = false;
                    rgbd2d.AddForce(new Vector2(-2*speed, 0f));
                }
            }
            else
            {
                if (transform.position.x <= positionBase.x)
                {
                    transform.Rotate(0f, 180, 0f);
                    firstDirection = true;
                    rgbd2d.AddForce(new Vector2(2 * speed, 0f));
                }
            }
            if (firstOscillation)
            {
                if (transform.position.y >= oscillation + positionBase.y)
                {
                    firstOscillation = false;
                    rgbd2d.AddForce(new Vector2(0f, -2 * speed));
                }
            }
            else
            {
                if (transform.position.y <= positionBase.y)
                {
                    firstOscillation = true;
                    rgbd2d.AddForce(new Vector2(0f,2 * speed));
                }
            }
        }
        else
        {
            if (firstDirection)
            {
                if (transform.position.y >= distance + positionBase.y)
                {
                    transform.Rotate(0f, 180, 0f);
                    firstDirection = false;
                    rgbd2d.AddForce(new Vector2(0f, -2 * speed));
                }
            }
            else
            {
                if (transform.position.y <= positionBase.y)
                {
                    transform.Rotate(0f, 180, 0f);
                    firstDirection = true;
                    rgbd2d.AddForce(new Vector2(0f,2 * speed));
                }
            }
            if (firstOscillation)
            {
                if (transform.position.x >= oscillation + positionBase.x)
                {
                    firstOscillation = false;
                    rgbd2d.AddForce(new Vector2(-2 * speed, 0f));
                }
            }
            else
            {
                if (transform.position.x <= positionBase.x)
                {
                    firstOscillation = true;
                    rgbd2d.AddForce(new Vector2(2 * speed, 0f));
                }
            }
        }
    }
}
