using UnityEngine;
using System.Collections;

public class EggsNeutralBehavior : MonoBehaviour
{

    public float moveForce = 15f;
    public float maxSpeed = 4f;
    public float roll = -1f;
    public float right = 1;
    private Rigidbody2D rgbd2d;
    private float lifeMax = 15f;
    private Transform parent;

        // Use this for initialization
        void Start()
    {
        rgbd2d = GetComponent<Rigidbody2D>();
        parent = transform.parent;
    }

    // Update is called once per frame
    void Update()
    {
        lifeMax -= Time.deltaTime;
    }

    void FixedUpdate()
    {
        float h = 1;
        transform.Rotate(0f, 0f, roll * rgbd2d.velocity.x);
        if (h * rgbd2d.velocity.x < maxSpeed)
        {
            rgbd2d.AddForce(Vector2.right * h * moveForce * right);
        }
        if (Mathf.Abs(rgbd2d.velocity.x) > maxSpeed)
        {
            rgbd2d.velocity = new Vector2(Mathf.Sign(rgbd2d.velocity.x) * maxSpeed, rgbd2d.velocity.y);
        }
        if (lifeMax <= 0)
        {
            SpecialEffectHelper.Instance.ExplodeClouds(transform.position);
            SoundEffectHelper.Instance.MakeEggCrackSound();
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "MovingGround")
        {
            transform.parent = collision.transform;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform.tag == "MovingGround")
        {
            transform.parent = parent;
        }
    }
}