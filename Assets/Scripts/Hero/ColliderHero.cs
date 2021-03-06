﻿using UnityEngine;
using System.Collections;

public class ColliderHero : MonoBehaviour {
    private Transform parent;
    public float exitTime = 0.5f;
    public float inExit = -1;
	// Use this for initialization
	void Start () {
        parent = transform.parent;
	}
	
	// Update is called once per frame
	void Update () {
	    if (inExit != -1)
        {
            inExit -= Time.deltaTime;
        }
	}

    void FixedUpdate()
    {
        if (inExit != -1 && inExit <= 0)
        {
            transform.parent = parent;
            inExit = -1;
        }
    }

    void OnTriggerEnter2D(Collider2D collider) { 
        EndSpawner endSpawn = collider.gameObject.GetComponent<EndSpawner>();
        if (endSpawn != null)
        {
            endSpawn.EndSpawnerActivate();
        }
        RespawnPoint respawnPoint = collider.gameObject.GetComponent<RespawnPoint>();
        if (respawnPoint != null)
        {
            respawnPoint.Crossed(gameObject);
        }
        TextAppearence textAppearance = collider.gameObject.GetComponent<TextAppearence>();
        if (textAppearance != null)
        {
            textAppearance.Play();
        }
        BonusCollect bonusCollect = collider.gameObject.GetComponent<BonusCollect>();
        if (bonusCollect != null)
        {
            bonusCollect.Play();
            transform.GetComponent<Health>().BonusCollect();
        }
        PopPlatformStartEnd popPlatform = collider.gameObject.GetComponent<PopPlatformStartEnd>();
        if (popPlatform != null)
        {
            popPlatform.Play();
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "MovingGround")
        {
            if (inExit > -1)
            {
                inExit = -1;
            }
            if (collision.transform.parent != null)
            {
                if (collision.transform.parent.parent != null)
                {
                    transform.parent = collision.transform.parent.parent;
                }
                else
                {
                    transform.parent = collision.transform.parent;
                }
            }
            else
            {
                transform.parent = collision.transform;
            }
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform.tag == "MovingGround")
        {
            if (inExit == -1)
            {
                inExit = exitTime;
            }
        }
    }
}
