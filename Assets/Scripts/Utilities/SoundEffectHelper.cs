using UnityEngine;
using System.Collections;

public class SoundEffectHelper : MonoBehaviour
{
    public static SoundEffectHelper Instance;
    public AudioSource efxSource;
    public AudioClip eggCrack;
    public AudioClip bonusCollect;

    void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("Multiple instances of SoundEffectsHelper!");
        }
        Instance = this;
    }

    public void MakeEggCrackSound()
    {
        MakeSound(eggCrack);
    }

    public void MakeBonusCollect()
    {
        MakeSound(bonusCollect);
    }

    private void MakeSound(AudioClip originalClip)
    {
        efxSource.clip = originalClip;
        efxSource.Play();
        //AudioSource.PlayClipAtPoint(originalClip, transform.position,3f);
    }
}