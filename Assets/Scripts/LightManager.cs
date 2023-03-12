using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LightManager : MonoBehaviour
{
    public ExposureLight Top;
    public ExposureLight Bot;
    public ExposureLight Right;
    public ExposureLight Left;

    public ExposureLight Selected;

    public Switch SwitchTop;
    public Switch SwitchBot;
    public Switch SwitchRight;
    public Switch SwitchLeft;

    public Switch SwitchRed;
    public Switch SwitchGreen;

    public Button SelectTop;
    public Button SelectBot;
    public Button SelectRight;
    public Button SelectLeft;

    public Sprite HilightRed;
    public Sprite HilightGreen;
    public Sprite DarkRed;
    public Sprite DarkGreen;

    private void Start()
    {
        SelectTop.onClick.AddListener(OnSelectTop);
        SelectBot.onClick.AddListener(OnSelectBot);
        SelectRight.onClick.AddListener(OnSelectRight);
        SelectLeft.onClick.AddListener(OnSelectLeft);
    }

    // Update is called once per frame
    void Update()
    {
        if (!MainManager.Pause)
        {
            ManageSwitch();
            ManageSelectionButton();
            ManageColorSwitch();
        }
    }

    private void ManageSwitch()
    {
        Top.ON = SwitchTop.ON;
        Bot.ON = SwitchBot.ON;
        Right.ON = SwitchRight.ON;
        Left.ON = SwitchLeft.ON;
    }

    private void ManageColorSwitch()
    {
        if (Selected)
        {
            var red = Selected.Type == ExposureLight.ExposureLightType.RED;
            SwitchRed.ON = red;
            SwitchGreen.ON = !red;
        }
    }

    private void ManageSelectionButton()
    {
        if(Selected == Top)
        {
            var topColor = Top.Type == ExposureLight.ExposureLightType.RED;
            var botColor = Bot.Type == ExposureLight.ExposureLightType.RED;
            var rightColor = Right.Type == ExposureLight.ExposureLightType.RED;
            var leftColor = Left.Type == ExposureLight.ExposureLightType.RED;
            SelectTop.GetComponent<Image>().sprite = topColor ? HilightRed : HilightGreen;
            SelectBot.GetComponent<Image>().sprite = botColor ? DarkRed : DarkGreen;
            SelectRight.GetComponent<Image>().sprite = rightColor ? DarkRed : DarkGreen;
            SelectLeft.GetComponent<Image>().sprite = leftColor ? DarkRed : DarkGreen;

        }
        else if(Selected == Bot)
        {
            var topColor = Top.Type == ExposureLight.ExposureLightType.RED;
            var botColor = Bot.Type == ExposureLight.ExposureLightType.RED;
            var rightColor = Right.Type == ExposureLight.ExposureLightType.RED;
            var leftColor = Left.Type == ExposureLight.ExposureLightType.RED;
            SelectTop.GetComponent<Image>().sprite = topColor ? DarkRed : DarkGreen;
            SelectBot.GetComponent<Image>().sprite = botColor ? HilightRed : HilightGreen;
            SelectRight.GetComponent<Image>().sprite = rightColor ? DarkRed : DarkGreen;
            SelectLeft.GetComponent<Image>().sprite = leftColor ? DarkRed : DarkGreen;
        }
        else if (Selected == Right)
        {
            var topColor = Top.Type == ExposureLight.ExposureLightType.RED;
            var botColor = Bot.Type == ExposureLight.ExposureLightType.RED;
            var rightColor = Right.Type == ExposureLight.ExposureLightType.RED;
            var leftColor = Left.Type == ExposureLight.ExposureLightType.RED;
            SelectTop.GetComponent<Image>().sprite = topColor ? DarkRed : DarkGreen;
            SelectBot.GetComponent<Image>().sprite = botColor ? DarkRed : DarkGreen;
            SelectRight.GetComponent<Image>().sprite = rightColor ? HilightRed : HilightGreen;
            SelectLeft.GetComponent<Image>().sprite = leftColor ? DarkRed : DarkGreen;
        }
        else
        {
            var topColor = Top.Type == ExposureLight.ExposureLightType.RED;
            var botColor = Bot.Type == ExposureLight.ExposureLightType.RED;
            var rightColor = Right.Type == ExposureLight.ExposureLightType.RED;
            var leftColor = Left.Type == ExposureLight.ExposureLightType.RED;
            SelectTop.GetComponent<Image>().sprite = topColor ? DarkRed : DarkGreen;
            SelectBot.GetComponent<Image>().sprite = botColor ? DarkRed : DarkGreen;
            SelectRight.GetComponent<Image>().sprite = rightColor ? DarkRed : DarkGreen;
            SelectLeft.GetComponent<Image>().sprite = leftColor ? HilightRed : HilightGreen;
        }
    }

    public void OnSelectTop()
    {
        Selected = Top;
    }

    public void OnSelectBot()
    {
        Selected = Bot;
    }

    public void OnSelectRight()
    {
        Selected = Right;
    }

    public void OnSelectLeft()
    {
        Selected = Left;
    }

    public void OnSwitchColor(bool red)
    {
        if (red)
        {
            Selected.Type = ExposureLight.ExposureLightType.RED;
        }
        else
        {
            Selected.Type = ExposureLight.ExposureLightType.GREEN;
        }
        
    }
}
