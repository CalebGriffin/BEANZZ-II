using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonUIManager : MonoBehaviour
{
    public enum DiamondButtonMap
    {
        West = 0,
        South,
        North,
        East,
        NumOfButtons
    }

    [SerializeField] private float unselectedAlpha = 0.43f;
    [SerializeField] private float waitingAlpha = 1.0f;
    [SerializeField] private float selectedAlpha = 1.0f;
    [SerializeField] private Vector3 selectedScale = new Vector3(1.3f, 1.3f, 1.0f);
    [SerializeField] private Vector3 unselectedScale = new Vector3(1.0f, 1.0f, 1.0f);
    [SerializeField] private Image[] diamond = new Image[(int)DiamondButtonMap.NumOfButtons];

    private static ButtonUIManager instance = null;

    public static ButtonUIManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = GameObject.FindObjectOfType<ButtonUIManager>();
            }
            return instance;
        }
    }

    public void ResetAllButtons()
    {
        for (int i = 0; i < (int)DiamondButtonMap.NumOfButtons; i++)
        {
            SetButtonAlphaAndScale((DiamondButtonMap)i, waitingAlpha, unselectedScale);
        }
    }

    public void SelectButton(DiamondButtonMap buttonLocation)
    {
        if (buttonLocation < DiamondButtonMap.NumOfButtons)
        {
            ResetAllButtons();
            for (int i = 0; i < (int)DiamondButtonMap.NumOfButtons; i++)
            {
                if (i == (int)buttonLocation)
                {
                    SetButtonAlphaAndScale((DiamondButtonMap)i, selectedAlpha, selectedScale);
                }
                else
                {
                    SetButtonAlphaAndScale((DiamondButtonMap)i, unselectedAlpha, unselectedScale);
                }
            }
        }


    }

    private void SetButtonAlphaAndScale(DiamondButtonMap buttonLocation, float alpha, Vector3 scale)
    {
        if (buttonLocation < DiamondButtonMap.NumOfButtons)
        {
            //Color tmpColor = diamond[(int)buttonLocation].GetComponent<Renderer>().material.color;
            Color tmpColor = diamond[(int)buttonLocation].color;
            tmpColor.a = alpha;
            //diamond[(int)buttonLocation].GetComponent<Renderer>().material.color = tmpColor;
            diamond[(int)buttonLocation].color = tmpColor;
            diamond[(int)buttonLocation].transform.localScale = scale;
        }

    }
}

