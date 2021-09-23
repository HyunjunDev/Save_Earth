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
    private int index;

    private void Start()
    {
        image = GetComponent<Image>();
        metorUpgradePanel = GameObject.Find("Metor").GetComponent<MetorUpgradePanel>();
        planetUpgradePanel = GameObject.Find("Earth").GetComponent<PlanetUpgradePanel>();
    }
    public void UpgradeImage()
    {
        switch(MetorUpgradePanel.metorUpgradeLevel)
        {
            case 5:
                if(index==0)
                {
                    image.sprite = sprites[index];
                    index++;
                }    
                break;
        }
        switch(PlanetUpgradePanel.planetUpgradeLevel)
        {
            case 5:
                if (index == 0)
                {
                    image.sprite = sprites[index];
                    index++;
                }
                break;
        }    
            if (sprites.Length == index)
            {
                index = 0;
            }
    }    
}
