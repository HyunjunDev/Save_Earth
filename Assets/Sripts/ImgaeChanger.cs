using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImgaeChanger : MonoBehaviour
{
    private Image image;

    [SerializeField]
    private Sprite[] sprites;
    private MetorUpgradePanel metorUpgradePanel;
    private PlanetUpgradePanel planetUpgradePanel;
    private int eIndex;
    private int mIndex;

    private void Start()
    {
        image = GetComponent<Image>();
        metorUpgradePanel = GameObject.Find("Metor").GetComponent<MetorUpgradePanel>();
        planetUpgradePanel = GameObject.Find("Earth").GetComponent<PlanetUpgradePanel>();
    }
    public void EarthImage()
    {
        if (eIndex == 1)
        {
            image.sprite = sprites[eIndex];
        }
        else if (eIndex == 2)
        {
            image.sprite = sprites[eIndex];
        }
        else if (eIndex == 3)
        {
            image.sprite = sprites[eIndex];
        }
        else if (eIndex == 4)
        {
            image.sprite = sprites[eIndex];
        }
        else if (eIndex == 5)
        {
            image.sprite = sprites[eIndex];
        }
    }
    public void EarthUpgradeImage()
    {
        switch (PlanetUpgradePanel.planetUpgradeLevel)
        {
            case 5:
                if (eIndex == 0)
                {
                    image.sprite = sprites[eIndex];
                    eIndex++;
                }
                break;
            case 21:
                if (eIndex == 1)
                {
                    image.sprite = sprites[eIndex];
                    eIndex++;
                }
                break;
            case 41:
                if (eIndex == 2)
                {
                    image.sprite = sprites[eIndex];
                    eIndex++;
                }
                break;
            case 61:
                if (eIndex == 3)
                {
                    image.sprite = sprites[eIndex];
                    eIndex++;
                }
                break;
        }
        if (sprites.Length == eIndex)
        {
            eIndex = 0;
        }
    }
    public void UpgradeImage()
    {
        switch(MetorUpgradePanel.metorUpgradeLevel)
        {
            case 5:
                if (mIndex == 0)
                {
                    image.sprite = sprites[mIndex];
                    mIndex++;
                }
                break;
            case 21:
                if (mIndex == 1)
                {
                    image.sprite = sprites[mIndex];
                    mIndex++;
                }
                break;
            case 41:
                if (mIndex == 2)
                {
                    image.sprite = sprites[mIndex];
                    mIndex++;
                }
                break;
            case 61:
                if (mIndex == 3)
                {
                    image.sprite = sprites[mIndex];
                    mIndex++;
                }
                break;
        }    
            if (sprites.Length == mIndex)
            {
                mIndex = 0;
            }
    }    
}
