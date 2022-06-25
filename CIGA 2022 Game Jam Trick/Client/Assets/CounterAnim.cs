using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class CounterAnim : MonoBehaviour
{
    public Text text;
    private Sequence mScoreSequence;
    
    private int currentDist;

    //[SerializeField]
    //int type;

    private int remDistance { get; set; }
    public int Score;

    // Start is called before the first frame update
    private void OnEnable()
    {
        mScoreSequence = DOTween.Sequence();
        mScoreSequence.SetAutoKill(false);

        Score = Mathf.Clamp(Score, 0, 5000);
        //remDistance = UpdateScore(Score);
        IncreaseKm(0, Score);
    }

    int UpdateScore(int score)
    {
        return remDistance = 5000 - score;
    }

    //int CalculateDist (int dist)
    //{
    //    if (remDistance == 0) {
    //        return currentDist = 5000;
    //    } else
    //    {
    //        return currentDist += Mathf.FloorToInt(2 * Time.deltaTime);
    //    }
    //}

    //int DeathCount(int death)
    //{
    //    return death++;
    //}

    void IncreaseKm (int start, int end)
    {
        mScoreSequence.Append(DOTween.To(delegate (float value)
        {
            int temp = Mathf.FloorToInt(value);
            text.text = temp + "";
        }, start, end, 2f));
    }
}
