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

    private int remDistance { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        mScoreSequence = DOTween.Sequence();
        mScoreSequence.SetAutoKill(false);
        remDistance = UpdateScore(2534);
        IncreaseAnimation(0, remDistance);
    }

    // Update is called once per frame
    void Update()
    {
        
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

    void IncreaseAnimation (int start, int end)
    {
        mScoreSequence.Append(DOTween.To(delegate (float value)
        {
            int temp = Mathf.FloorToInt(value);
            text.text = temp + "";
        }, start, end, 2f));
    }
}
