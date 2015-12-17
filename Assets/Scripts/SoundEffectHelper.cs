using UnityEngine;
using System.Collections;

public class SoundEffectHelper : MonoBehaviour
{
    public static SoundEffectHelper Instance;
    public AudioClip eggCrack;

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

    private void MakeSound(AudioClip originalClip)
    {
        AudioSource.PlayClipAtPoint(originalClip, transform.position);
    }
}