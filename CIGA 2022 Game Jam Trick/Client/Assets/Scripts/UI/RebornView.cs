using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class RebornView : MonoBehaviour
{
    public Text DeathText;
    public Text DistanceText;
    public CounterAnim CountAnim;
    public DeathCountAnim DeathAnim;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void RefreshText()
    {
        float distance = GameManager.GetInstance().GetDistance();
        CountAnim.Score = (int)(distance * 100);

        DeathAnim.deaths = GameManager.GetInstance().DeathCount;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
