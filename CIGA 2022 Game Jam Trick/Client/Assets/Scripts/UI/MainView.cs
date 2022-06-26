using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainView : MonoBehaviour
{
    public Text DistanceText;
    public Transform TutorialTran;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void ReverseSpace()
    {
        if (TutorialTran != null)
        {
            TutorialTran.localScale = new Vector3(TutorialTran.localScale.x, -TutorialTran.localScale.y, TutorialTran.localScale.z);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (DistanceText)
        {
            float distance = GameManager.GetInstance().GetCurrentDistance();
            DistanceText.text = ((int)(distance * 100)).ToString();
        }
    }
}
