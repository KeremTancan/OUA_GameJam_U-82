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
       
        
        switch(ScoreCounter.scoreValue)
        {
            case >= 200:
                Debug.Log("nefes 120");
                nefesBar.SetMaxBreath(120);
                nefesBar.SetBreath(120);
                NefesBar.maxBreath = 120;
                NefesBar.currentBreath = 120;
                ScoreCounter.scoreValue -= 200;
                
                break;

            case >=90:
                Debug.Log("nefes 60");
                nefesBar.SetMaxBreath(60);
                nefesBar.SetBreath(60);
                NefesBar.maxBreath = 60;
                NefesBar.currentBreath = 60;
                ScoreCounter.scoreValue -= 90;
                break;
            case >=30:
                Debug.Log("nefes 45");
                nefesBar.SetMaxBreath(45);
                nefesBar.SetBreath(45);
                NefesBar.maxBreath = 45;
                NefesBar.currentBreath = 45;
                ScoreCounter.scoreValue -= 30;
                break;
        }
        
        

        
    }


}

