using UnityEngine;
using UnityEngine.UI;
public class MetorUpgradePanel : MonoBehaviour
{
    [SerializeField]
    public Image planetImage = null;
    [SerializeField]
    public Text planetNameText = null;
    [SerializeField]
    public Text priceText = null;
    [SerializeField]
    public Text amountText = null;
    [SerializeField]
    public Sprite[] planetSprite = null;
    [SerializeField]
    private Button purchaseButton = null;
    [SerializeField]
    private Image backgroundImage = null;
    public static int metorUpgradeLevel = 0;
    public static float metorTouchStar = 0;
    private ImgaeChanger imgaeChanger;
    private Planet planet = null;
    private User user;
    private void Start()
    {
        UpdateValues();
        imgaeChanger = GameObject.Find("Metor").GetComponent<ImgaeChanger>();
    }
    private void Update()
    {
        UpdateValues();
        metorTouchStar = planet.touchStar;
        if (planet.imageNumber == 1)
        {
            imgaeChanger.MoonImage();
        }
        else if (planet.imageNumber == 2)
        {
            imgaeChanger.MoonImage();
        }
        else if (planet.imageNumber == 3)
        {
            imgaeChanger.MoonImage();
        }
        else if (planet.imageNumber == 4)
        {
            imgaeChanger.MoonImage();
        }
        if (metorUpgradeLevel >= 70)
        {
            amountText.text = "MAX";
            purchaseButton.gameObject.SetActive(false);
        }
    }
    public void SetValue(Planet planet)
    {
        this.planet = planet;
        PlanetUpdateUI();
    }
    public void PlanetUpdateUI()
    {
        metorUpgradeLevel = planet.amount;
        switch (metorUpgradeLevel)
        {
            case 5:
                metorUpgradeLevel = planet.amount;
                if(planet.imageNumber==0)
                {
                    planet.imageNumber++;
                    planetImage.sprite = planetSprite[planet.imageNumber];
                    imgaeChanger.MoonUpgradeImage();
                }
                break;
            case 21:
                metorUpgradeLevel = planet.amount;
                if (planet.imageNumber == 1)
                {
                    planet.imageNumber++;
                    planetImage.sprite = planetSprite[planet.imageNumber];
                    imgaeChanger.MoonUpgradeImage();
                }
                break;
            case 41:
                metorUpgradeLevel = planet.amount;
                if (planet.imageNumber == 2)
                {
                    planet.imageNumber++;
                    planetImage.sprite = planetSprite[planet.imageNumber];
                    imgaeChanger.MoonUpgradeImage();
                }
                break;
            case 61:
                metorUpgradeLevel = planet.amount;
                if (planet.imageNumber == 3)
                {
                    planet.imageNumber++;
                    planetImage.sprite = planetSprite[planet.imageNumber];
                    imgaeChanger.MoonUpgradeImage();
                }
                break;
        }
        planetImage.sprite = planetSprite[planet.imageNumber];
        planetNameText.text = planet.name;
        priceText.text = string.Format("{0:N0} STAR", planet.price);
        amountText.text = string.Format("{0:N0}", planet.amount);
    }
    public void UpdateValues()
    {
        priceText.text = string.Format("{0:N0} STAR", planet.price);
        if (planetSprite != null)
        {
            planetImage.sprite = planetSprite[planet.imageNumber];
        }
        if (!planet.Locked && PlanetUpgradePanel.planetUpgradeLevel >= 55)
        {
            planetNameText.text = planet.name;
            amountText.text = string.Format("{0}", planet.amount);
            planetImage.color = Color.white;
            purchaseButton.gameObject.SetActive(true);
            purchaseButton.interactable = GameManager.Instance.CurrentUser.star >= planet.price;
            backgroundImage.color = GameManager.Instance.CurrentUser.star >= planet.price ? Color.white : Color.gray;
        }
        else
        {
            planetNameText.text = "????";
            amountText.text = "";
            backgroundImage.color = Color.gray;
            planetImage.color = Color.black;
            purchaseButton.gameObject.SetActive(false);
        }
    }
    public void OnClickPurchase()
    {
        metorTouchStar = planet.touchStar;
        if (GameManager.Instance.CurrentUser.star < planet.price)
        {
            return;
        }
        GameManager.Instance.CurrentUser.star -= planet.price;
        Planet planetInList = GameManager.Instance.CurrentUser.metorList.Find((x) => x.name == planet.name);
        planetInList.amount++;
        planetInList.price = (long)(planetInList.price * 1.1f+5000);
        planet.touchStar += 300;
        planet.touchStar *= 1.075f;
        UpdateValues();
        PlanetUpdateUI();
        GameManager.Instance.uiManager.UpdateRocketPanel();
    }
}
