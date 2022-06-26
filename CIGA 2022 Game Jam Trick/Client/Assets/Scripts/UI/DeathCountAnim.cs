using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class DeathCountAnim : MonoBehaviour
{
    public Text text;
    private Sequence deathSequence;

    public int deaths { get; set; }

    // Start is called before the first frame update
    void OnEnable()
    {
        deaths = GameManager.GetInstance().DeathCount;
        deathSequence = DOTween.Sequence();
        deathSequence.SetAutoKill(false);


        IncreaseDeath(0, deaths);
    }

     void IncreaseDeath(int start, int end)
    {
        deathSequence.Append(DOTween.To(delegate (float value)
        {
            int temp = Mathf.FloorToInt(value);
            text.text = temp + "";
        }, start, end, 2f));
    }
}
