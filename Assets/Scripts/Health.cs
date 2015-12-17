﻿using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {
	/// Points de vies
	public int hpMax = 1;
	/// Ennemi ou joueur ?
	public bool isEnemy = true;
    public bool isHero = false;
    public float invulnerabilityTime = 0f;

    private int hp;
    private float invulnerability;

    void Start()
    {
        invulnerability = 0f;
        hp = hpMax;
    }

    public void restoreHpMax()
    {
        hp = hpMax;
    }

    void Update()
    {
        if (invulnerability > 0)
        {
            invulnerability -= Time.deltaTime;
        }
    }

    void FixedUpdate()
    {
        if (isHero)
        {
            if (invulnerability > 0)
            {
                if (transform.GetComponent<SpriteRenderer>().color == Color.white)
                {
                    transform.GetComponent<SpriteRenderer>().color = Color.red;
                }
            }
            else
            {
                if (transform.GetComponent<SpriteRenderer>().color == Color.red)
                {
                    transform.GetComponent<SpriteRenderer>().color = Color.white;
                }
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (invulnerability <= 0)
        {

            Shot_Script shot = collider.gameObject.GetComponent<Shot_Script>();
            if (shot != null)
            {
                if (shot.isEnemyShot != isEnemy)
                {
                    hp -= shot.damage;
                    invulnerability = invulnerabilityTime;
                }
            }
            TouchingHurts trap = collider.gameObject.GetComponent<TouchingHurts>();
            if (trap != null)
            {
                hp -= trap.damage;
                invulnerability = invulnerabilityTime;
            }
            Flammer flamme = collider.gameObject.GetComponent<Flammer>();
            if (flamme != null)
            {
                if (flamme.dangerous)
                {
                    hp -= flamme.damage;
                    invulnerability = invulnerabilityTime;
                }
            }
        }
        if (hp <= 0)
        {
            if (isHero)
            {
                invulnerability = 0;
                SpecialEffectHelper.Instance.ExplodeClouds(transform.position);
                SoundEffectHelper.Instance.MakeEggCrackSound();
                transform.GetComponent<Respawn>().Die();
            }
            else
            {
                SpecialEffectHelper.Instance.ExplodeClouds(transform.position);
                SoundEffectHelper.Instance.MakeEggCrackSound();
                Destroy(gameObject);
            }
        }
    }


}