using UnityEngine;
using System.Collections;

public class CameraAttitude : MonoBehaviour {
    public float interpVelocity;
    public float minDistance;
    public float followDistance;
    public Transform target;
    public Vector3 offset;
    public Transform background;
    public float backgroundDelay;


    private Vector3 targetPos;
    // Use this for initialization
    void Start()
    {
        targetPos = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (target)
        {
            Vector3 posNoZ = transform.position;
            posNoZ.z = target.transform.position.z;
            Vector3 targetDirection = (target.transform.position - posNoZ);
            interpVelocity = targetDirection.magnitude * 50f;
            targetPos = transform.position + (targetDirection.normalized * interpVelocity * Time.deltaTime);
            transform.position = Vector3.Lerp(transform.position, targetPos + offset, 0.25f);
            background.position = Vector3.Lerp(background.position * backgroundDelay, targetPos + offset, 0.25f);
            background.Translate(Vector3.forward * 10);
        }
    }

    public void MoveTo(Vector3 target)
    {
        Vector3 posNoZ = transform.position;
        posNoZ.z = target.z;
        Vector3 targetDirection = (target - posNoZ);
        interpVelocity = targetDirection.magnitude * 50f;
        targetPos = transform.position + (targetDirection.normalized * interpVelocity * Time.deltaTime);
        transform.position = Vector3.Lerp(transform.position, targetPos + offset, 0.25f);
        background.position = Vector3.Lerp(background.position * backgroundDelay, targetPos + offset, 0.25f);
        background.Translate(Vector3.forward * 10);
    }

    void Update()
    {

    }

}
