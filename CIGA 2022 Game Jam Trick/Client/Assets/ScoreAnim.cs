using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class ScoreAnim : MonoBehaviour
{
    public Text text;
    private Sequence mScoreSequence;

    private int currentDist;


    private int remDistance { get; set; }
    public int Score;

    // Start is called before the first frame update
    private void OnEnable()
    {
        mScoreSequence = DOTween.Sequence();
        mScoreSequence.SetAutoKill(false);

        //Score = Mathf.Clamp(Score, 0, 5000);
        IncreaseKm(0, Score);
    }

    int UpdateScore(int score)
    {
        return remDistance = 5000 - score;
    }


    void IncreaseKm(int start, int end)
    {
        mScoreSequence.Append(DOTween.To(delegate (float value)
        {
            int temp = Mathf.FloorToInt(value);
            text.text = temp + "";
        }, start, end, 2f));
    }
}
