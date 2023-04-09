using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour
{
    // Start is called before the first frame update
    public static int scoreValue;
    public static TextMeshProUGUI score;

    

    void Start()
    {
        
        score = GetComponent<TextMeshProUGUI>();    
    }

    // Update is called once per frame
    void Update()
    {
        score.text = "Score : " + scoreValue + "/1000";
        if(scoreValue >= 1000)
        {
            SceneManager.LoadScene("TheENDscene");
        }
        
    }

    
}
