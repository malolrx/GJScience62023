using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MainManager : MonoBehaviour
{
    public enum GamePhase
    {
        ONE,
        TWO,
        THREE
    }

    private GamePhase actualPhase;
    public GamePhase ActualPhase
    {
        get
        {
            return actualPhase;
        }
        set
        {
            actualPhase = value;
            ManagePhase();
        }
    }

    public int ScoreToJauge;
    public LightManager LightManagerInstance;
    public BacteriaManager BacteriaManagerInstance;
    public GameObject FinTuto;
    public TextMeshProUGUI JaugeLabel;

    private int NbrJauge;
    private int NextJaugeStep;

    public bool Tuto;
    public static bool Pause;


    // Start is called before the first frame update
    void Start()
    {
        Pause = true;
        NbrJauge = 0;
        NextJaugeStep = 1;
        ActualPhase = GamePhase.ONE;
    }

    // Update is called once per frame
    void Update()
    {
        CheckProduction();
    }

    private void ManagePhase()
    {
        if (Tuto)
        {
            switch (ActualPhase)
            {
                case GamePhase.ONE:
                    EnableTop(true);
                    EnableBot(false);
                    EnableRight(false);
                    EnableLeft(false);
                    EnableColorSwitch(false);
                    break;

                case GamePhase.TWO:
                    EnableBot(true);
                    EnableColorSwitch(true);
                    LightManagerInstance.SwitchBot.gameObject.SetActive(true);
                    break;
            }
        }
        else
        {
            switch (ActualPhase)
            {
                case GamePhase.ONE:
                    EnableTop(true);
                    EnableBot(false);
                    EnableRight(false);
                    EnableLeft(false);
                    break;

                case GamePhase.TWO:
                    EnableBot(true);

                    break;
                case GamePhase.THREE:
                    EnableRight(true);
                    EnableLeft(true);
                    break;
            }
        }
        
    }

    private void CheckProduction()
    {
        if (Tuto)
        {
            if (BacteriaManagerInstance.bacterias.Count == BacteriaManagerInstance.BacteriaMax && ActualPhase == GamePhase.ONE)
            {
                ActualPhase = GamePhase.TWO;
            }

            if(BacteriaManagerInstance.Production >= ScoreToJauge)
            {
                //fin tuto
                Debug.Log("fin tuto");
                Pause = true;
                FinTuto.SetActive(true);
            }
        }
        else
        {

            if (BacteriaManagerInstance.Production >= ScoreToJauge)
            {
                BacteriaManagerInstance.Production -= ScoreToJauge;
                NbrJauge++;
                
                JaugeLabel.text = NbrJauge.ToString();
            }

            if (NbrJauge == NextJaugeStep)
            {
                if (ActualPhase == GamePhase.ONE)
                {
                    ActualPhase = GamePhase.TWO;
                }
                else if (ActualPhase == GamePhase.TWO)
                {
                    ActualPhase = GamePhase.THREE;
                }
                NextJaugeStep *= 2;
            }


        }
        

    }

    private void EnableTop(bool enable)
    {
        LightManagerInstance.SwitchTop.gameObject.SetActive(enable);
        LightManagerInstance.SelectTop.gameObject.SetActive(enable);
        LightManagerInstance.Top.gameObject.SetActive(enable);
    }

    private void EnableBot(bool enable)
    {
        LightManagerInstance.SwitchBot.gameObject.SetActive(enable);
        LightManagerInstance.SelectBot.gameObject.SetActive(enable);
        LightManagerInstance.Bot.gameObject.SetActive(enable);
    }

    private void EnableRight(bool enable)
    {
        LightManagerInstance.SwitchRight.gameObject.SetActive(enable);
        LightManagerInstance.SelectRight.gameObject.SetActive(enable);
        LightManagerInstance.Right.gameObject.SetActive(enable);
    }

    private void EnableLeft(bool enable)
    {
        LightManagerInstance.SwitchLeft.gameObject.SetActive(enable);
        LightManagerInstance.SelectLeft.gameObject.SetActive(enable);
        LightManagerInstance.Left.gameObject.SetActive(enable);
    }

    private void EnableColorSwitch(bool enable)
    {
        LightManagerInstance.SwitchRed.GetComponent<Button>().interactable = enable;
        LightManagerInstance.SwitchGreen.GetComponent<Button>().interactable = enable;
    }

    public void Tutorial(bool tuto)
    {
        Tuto = tuto;
        Pause = false;
    }
}
