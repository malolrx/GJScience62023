using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Dialbox : MonoBehaviour
{
    public TextMeshProUGUI text;

    public string stepOneFirst;
    public string stepOneSecond;
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
                text.text = stepOneThird;
                break;
            case 3:
                MainManager.Pause = false;
                gameObject.SetActive(false);
                break;
            case 4:
                text.text = stepTwoFirst;
                break;
            case 5:
                text.text = stepTwoSecond;
                break;
            case 6:
                MainManager.Pause = false;
                gameObject.SetActive(false);
                break;
            case 7:
                text.text = stepThreeFirst;
                break;
            case 8:
                MainManager.Pause = false;
                gameObject.SetActive(false);
                break;


        }
    }





}
