using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelOpener : MonoBehaviour
{
    public GameObject panel;
    
    public NefesBar nefesBar;

    public void OpenPanel()
    {
        panel.SetActive(true); 
    }

    public void ClosePanel()
    {
        panel.SetActive(false); 
    }


    public void ScoreIncrease()
    {
        if (ScoreCounter.scoreValue >= 30)
        {
            nefesBar.SetMaxBreath(60);
            nefesBar.SetBreath(60);
            NefesBar.maxBreath = 60;
            NefesBar.currentBreath = 60;
            ScoreCounter.scoreValue = 0;

        }

    }


}

