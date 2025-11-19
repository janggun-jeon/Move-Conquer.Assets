using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Turn : MonoBehaviour
{
    Text turn;

    void Start()
    {
        turn = gameObject.GetComponent<Text>();
    }

    void Update()
    {
        turn.text = GameManager.turn.ToString() + "ео";
    }
}
