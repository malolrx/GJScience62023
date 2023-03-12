using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Dialbox : MonoBehaviour
{
    public TextMeshProUGUI text;

    public string stepOneFirst;
    public string stepOneSecond;
    public string stepOneSecondBis;
    public string stepOneThird;

    public string stepTwoFirst;
    public string stepTwoSecond;

    public string stepThreeFirst;

    private int cmpt;

    private void Start()
    {
        cmpt = 0;
    }

    private void Update()
    {
        Check();
    }


    public void ShowNextText()
    {
        cmpt++;
    }

    private void OnEnable()
    {
        cmpt++;
    }

    public void Check()
    {
        switch (cmpt)
        {
            case 0:
                text.text = stepOneFirst;
                break;
            case 1:
                text.text = stepOneSecond;
                break;
            case 2:
                text.text = stepOneSecondBis;
                break;
            case 3:
                text.text = stepOneThird;
                break;
            case 4:
                MainManager.Pause = false;
                gameObject.SetActive(false);
                break;
            case 5:
                text.text = stepTwoFirst;
                break;
            case 6:
                text.text = stepTwoSecond;
                break;
            case 7:
                MainManager.Pause = false;
                gameObject.SetActive(false);
                break;
            case 8:
                text.text = stepThreeFirst;
                break;
            case 9:
                MainManager.Pause = false;
                gameObject.SetActive(false);
                break;


        }
    }





}
