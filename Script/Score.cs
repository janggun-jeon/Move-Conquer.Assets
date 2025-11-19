using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    Text score;

    void Start()
    {
        score = gameObject.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
        score.text = "<Score>\nRed : Blue\n" + GameManager.redScore.ToString() + " : " + GameManager.blueScore.ToString();

    }
}
