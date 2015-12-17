using UnityEngine;
using System.Collections;

public class Flammer : MonoBehaviour {
    public float timerStop = 2;
    public bool dangerous = false;
    public float duration = 1;
    public int damage = 1;
    public float angleX = 0;
    public float angleY = 90;
    public float delay = 0;

    private float timeLeft;
    private float timeEffectLeft;
    // Use this for initialization
    void Start () {
        timeLeft = Time.deltaTime + timerStop + delay;
	}

    void FixedUpdate()
    {
        if (timeLeft < 0 && !dangerous)
        {
            dangerous = true;
            SpecialEffectHelper.Instance.LaunchFlamme(transform.position, angleX,angleY);
            timeEffectLeft = duration;
        }else if (timeEffectLeft < 0 && dangerous)
        {
            dangerous = false;
            timeLeft = timerStop;
        }
    }

    // Update is called once per frame
    void Update () {
	   if (timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
        }
        else if(timeEffectLeft > 0){
            timeEffectLeft -= Time.deltaTime;
        }
	}
}
