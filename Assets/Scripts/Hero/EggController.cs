using UnityEngine;
using System.Collections;

public class EggController : MonoBehaviour
{
    [HideInInspector]
    public bool jump = false;

    public float moveForce = 15f;
    public float maxSpeed = 4f;
    public float roll = -1f;
    public float jumpforce = 10f;
    public Transform groundCheck;


    public bool grounded = false;

    private Animator animator;
    private Rigidbody2D rgbd2d;
    private float distToGround;

    // Use this for initialization
    void Start()
    {
        animator = GetComponent<Animator>();
        rgbd2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));
        /*if (Input.GetButtonDown("Jump") && grounded)
        {
            jump = true;
        }*/
    }


    void FixedUpdate()
    {
        if (!GameUtilities.Instance.dontMove) { 
            if (rgbd2d.IsSleeping())
            {
                rgbd2d.WakeUp();
            }
            float h = Input.GetAxis("Horizontal");
            animator.SetFloat("Speed", h);
            transform.Rotate(0f, 0f, roll * rgbd2d.velocity.x);
            if (h != 0)
            {
                animator.SetFloat("Orientation", rgbd2d.rotation);
            }
            if (h * rgbd2d.velocity.x < maxSpeed)
            {
                rgbd2d.AddForce(Vector2.right * h * moveForce);
            }
            if (Mathf.Abs(rgbd2d.velocity.x) > maxSpeed)
            {
                rgbd2d.velocity = new Vector2(Mathf.Sign(rgbd2d.velocity.x) * maxSpeed, rgbd2d.velocity.y);
            }
            /*if (jump)
            {
                rgbd2d.AddForce(new Vector2(0f, jumpforce));
                jump = false;
            }*/
        }
        else if (!rgbd2d.IsSleeping())
        {
            rgbd2d.Sleep();
        }
    }
}