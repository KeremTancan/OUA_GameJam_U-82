using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour
{
    // Start is called before the first frame update
    public static int scoreValue = 0;
    public Text score;
   
        void Start()
    {
        score = GetComponent<Text>();    
    }

    // Update is called once per frame
    void Update()
    {
        score.text = "Score = " + scoreValue;
    }
}
