using UnityEngine;
using System.Collections;

public class SpecialEffectHelper : MonoBehaviour {
    public static SpecialEffectHelper Instance;

    public ParticleSystem explodeCloudsEffect;
    public ParticleSystem myTorch;
    public ParticleSystem endBonusEffect;

    void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("Multiple instances of SpecialEffectsHelper!");
        }
        Instance = this;
    }

    public void ExplodeClouds(Vector3 position)
    {
        instantiate(explodeCloudsEffect, position,Vector3.zero, Vector3.zero);
    }

    public void LaunchFlamme(Vector3 position, float angleX, float angleY)
    {
        instantiate(myTorch, position,Vector3.forward*2, Vector3.left * angleX + Vector3.down * angleY);
    }

    public void LaunchEndBonusEffect(Vector3 position)
    {
        instantiate(endBonusEffect, position, Vector3.zero, Vector3.zero);
    }

    private ParticleSystem instantiate(ParticleSystem prefab, Vector3 position,Vector3 translate, Vector3 rotation)
    {
        ParticleSystem newParticleSystem = Instantiate(
          prefab,
          position,
          Quaternion.identity
        ) as ParticleSystem;
        newParticleSystem.transform.Translate(translate);
        newParticleSystem.transform.Rotate(rotation);
        Destroy(
          newParticleSystem.gameObject,
          newParticleSystem.duration + 0.3f
        );

        return newParticleSystem;
    }
}
