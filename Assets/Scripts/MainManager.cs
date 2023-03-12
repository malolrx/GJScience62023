using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
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
    public GameObject Dialogue;
    public GameObject Recolte;
    public GameObject VictoryDial;
    public GameObject DefaiteDial;
    public TextMeshProUGUI JaugeLabel;

    private int NbrJauge;
    private int NextJaugeStep;

    public bool Tuto;
    public static bool Pause;

    private int dialStep;
    bool step1;
    bool step2;
    bool step3;
    

    // Start is called before the first frame update
    void Start()
    {
        dialStep = 0;
        step1 = false;
        step2 = false;
        step3 = false;
        Pause = true;
        NbrJauge = 0;
        NextJaugeStep = 1;
        ActualPhase = GamePhase.ONE;
        
    }

    // Update is called once per frame
    void Update()
    {
        Check();
    }

    private void ManagePhase()
    {
        switch (ActualPhase)
        {
            case GamePhase.ONE:
                EnableTop(true);
                EnableBot(false);
                EnableRight(false);
                EnableLeft(false);
                Debug.Log("test"+Tuto+step1);
                if (Tuto && step1==false)
                {
                    
                    Pause = true;
                    Dialogue.SetActive(true);
                    step1 = true;
                }
                break;
            case GamePhase.TWO:
                EnableBot(true);
                if (Tuto && step2==false)
                {
                    Pause = true;
                    Dialogue.SetActive(true);
                    step2 = true;
                }
                break;
            case GamePhase.THREE:
                EnableRight(true);
                EnableLeft(true);
                Recolte.SetActive(true);
                if (Tuto && step3 == false)
                {
                    Pause = true;
                    Dialogue.SetActive(true);
                    step3 = true;
                }
                break;
        }
        
    }

    private void Check()
    {
        if(BacteriaManagerInstance.Production >= ScoreToJauge)
        {
            BacteriaManagerInstance.Production -= ScoreToJauge;
            NbrJauge++;
            JaugeLabel.text = NbrJauge.ToString();
        }

        if(BacteriaManagerInstance.bacterias.Count == BacteriaManagerInstance.BacteriaMax && !step2)
        {
            ActualPhase = GamePhase.TWO;
            step2 = true;
            
        }

        if(NbrJauge == NextJaugeStep && !step3)
        {
            ActualPhase = GamePhase.THREE;
            NextJaugeStep *= 2;
        }

        if(NbrJauge == NextJaugeStep && step3)
        {
            NextJaugeStep *= 2;
        }

        if(BacteriaManagerInstance.bacterias.Count == 0 && BacteriaManagerInstance.Production > 0)
        {
            Pause = true;
            DefaiteDial.SetActive(true);
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
        ManagePhase();
    }

    public void Return()
    {
        Pause = false;
    }

    public void RecolteGly()
    {
        Pause = true;
        VictoryDial.SetActive(true);
    }

    public void ReturnMenu()
    {
        SceneManager.LoadScene(0);
    }

    
}
