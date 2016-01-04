using UnityEngine;
using System.Collections;

public class BonusCollect : MonoBehaviour {
    public int num;
    public bool life = true;

    private GameData data;
    void Start()
    {
        data = GameObject.Find("GameData").GetComponent<GameData>();
        if (data.bonusCollected[data.level][num] == true)
        {
            Destroy(gameObject);
        }
    }
	void Update () {
	
	}

    public void Play()
    {
        if (life)
        {
            SpecialEffectHelper.Instance.LaunchEndBonusEffect(transform.position);
            SoundEffectHelper.Instance.MakeBonusCollect();
            Destroy(gameObject);
            data.levels[data.level][0]++;
            data.bonusCollected[data.level][num] = true;
            GameObject.Find("Scripts").GetComponent<GameUtilities>().ReloadText();
        }
        else
        {
            Destroy(gameObject);
            data.levels[data.level][2]++;
            data.bonusCollected[data.level][num] = true;
            GameObject.Find("Scripts").GetComponent<GameUtilities>().ReloadText();
        }
        }
}
