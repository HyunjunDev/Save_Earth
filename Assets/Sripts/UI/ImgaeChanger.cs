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
    private MoonUpgradePanel moonUpgradePanel;
    public int eIndex;
    public int mIndex;
    public int moonIndex;
    private void Start()
    {
        image = GetComponent<Image>();
        metorUpgradePanel = GameObject.Find("Metor").GetComponent<MetorUpgradePanel>();
        planetUpgradePanel = GameObject.Find("Earth").GetComponent<PlanetUpgradePanel>();
        moonUpgradePanel = GameObject.Find("Moon").GetComponent<MoonUpgradePanel>();

    }
    public void EarthImage()
    {
        if (PlanetUpgradePanel.planetUpgradeLevel>=5&& PlanetUpgradePanel.planetUpgradeLevel <= 20)
        {
            eIndex = 1;
            image.sprite = sprites[eIndex];
        }
        else if (PlanetUpgradePanel.planetUpgradeLevel >= 21 && PlanetUpgradePanel.planetUpgradeLevel <= 40)
        {
            eIndex = 2;
            image.sprite = sprites[eIndex];
        }
        else if (PlanetUpgradePanel.planetUpgradeLevel >= 41 && PlanetUpgradePanel.planetUpgradeLevel <= 60)
        {
            eIndex = 3;
            image.sprite = sprites[eIndex];
        }
        else if (PlanetUpgradePanel.planetUpgradeLevel >= 61)
        {
            eIndex = 4;
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
    public void MetorImage()
    {
        if (MetorUpgradePanel.metorUpgradeLevel >= 5 && MetorUpgradePanel.metorUpgradeLevel <= 20)
        {
            mIndex = 1;
            image.sprite = sprites[mIndex];
        }
        else if (MetorUpgradePanel.metorUpgradeLevel >= 21 && MetorUpgradePanel.metorUpgradeLevel <= 40)
        {
            mIndex = 2;
            image.sprite = sprites[mIndex];
        }
        else if (MetorUpgradePanel.metorUpgradeLevel >= 41 && MetorUpgradePanel.metorUpgradeLevel <= 60)
        {
            mIndex = 3;
            image.sprite = sprites[mIndex];
        }
        else if (MetorUpgradePanel.metorUpgradeLevel >= 61)
        {
            mIndex = 4;
            image.sprite = sprites[mIndex];
        }
    }
    public void MetorUpgradeImage()
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
    public void MoonImage()
    {
        if (MoonUpgradePanel.moonUpgradeLevel >= 5 && MoonUpgradePanel.moonUpgradeLevel <= 20)
        {
            moonIndex = 1;
            image.sprite = sprites[moonIndex];
        }
        else if (MoonUpgradePanel.moonUpgradeLevel >= 21 && MoonUpgradePanel.moonUpgradeLevel <= 40)
        {
            moonIndex = 2;
            image.sprite = sprites[moonIndex];
        }
        else if (MoonUpgradePanel.moonUpgradeLevel >= 41 && MoonUpgradePanel.moonUpgradeLevel <= 60)
        {
            moonIndex = 3;
            image.sprite = sprites[moonIndex];
        }
        else if (MoonUpgradePanel.moonUpgradeLevel >= 61)
        {
            moonIndex = 4;
            image.sprite = sprites[moonIndex];
        }
    }
    public void MoonUpgradeImage()
    {
        switch (MoonUpgradePanel.moonUpgradeLevel)
        {
            case 5:
                if (moonIndex == 0)
                {
                    image.sprite = sprites[moonIndex];
                    moonIndex++;
                }
                break;
            case 21:
                if (moonIndex == 1)
                {
                    image.sprite = sprites[moonIndex];
                    moonIndex++;
                }
                break;
            case 41:
                if (moonIndex == 2)
                {
                    image.sprite = sprites[moonIndex];
                    moonIndex++;
                }
                break;
            case 61:
                if (moonIndex == 3)
                {
                    image.sprite = sprites[moonIndex];
                    moonIndex++;
                }
                break;
        }
        if (sprites.Length == moonIndex)
        {
            moonIndex = 0;
        }
    }
}
