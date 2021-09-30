using UnityEngine;
using UnityEngine.UI;

public class UpgradePanel : MonoBehaviour
{
    [SerializeField]
    public Image rocketImage = null;
    [SerializeField]
    public Text nameText = null;
    [SerializeField]
    public Text   priceText = null;
    [SerializeField]
    public Text amountText = null;
    [SerializeField]
    private Sprite[] rocketSprite = null;
    [SerializeField]
    private Button purchaseButton = null;
    [SerializeField]
    private Image backgroundImage = null;
    private RocketMovement rocketMovement;
    public static int upgradeLevel = 0;
    public static float autoStar = 0;
    private Rocket rocket = null;
    public GameObject rocket_Normal;
    public void Start()
    {
        UpdateValues();
        rocketMovement = GameObject.Find("Rocket_Normal").GetComponent<RocketMovement>();
        if (upgradeLevel == 0)
        {
            rocket_Normal.SetActive(false);
        }
    }
    private void Update()
    {
        UpdateValues();
        if (rocket.imageNumber == 1)
        {
            rocketMovement.ChangeRocketSprite();
        }
        else if (rocket.imageNumber == 2)
        {
            rocketMovement.ChangeRocketSprite();
        }
        else if (rocket.imageNumber == 3)
        {
            rocketMovement.ChangeRocketSprite();
        }
        else if (rocket.imageNumber == 4)
        {
            rocketMovement.ChangeRocketSprite();
        }
        if (upgradeLevel >= 50)
        {
            amountText.text = "MAX";
            purchaseButton.gameObject.SetActive(false);
        }
    }
    public void SetValue(Rocket rocket)
    {
        this.rocket = rocket;
        UpdateUI();
    }
    public void UpdateValues()
    {
        priceText.text = string.Format("{0:N0} STAR", rocket.price);
        if (rocketSprite != null)
        {
            rocketImage.sprite = rocketSprite[rocket.imageNumber];
        }
        if (!rocket.Locked)
        {
            nameText.text = rocket.name;
            amountText.text = string.Format("{0}", rocket.amount);
            rocketImage.color = Color.white;
            purchaseButton.gameObject.SetActive(true);
            purchaseButton.interactable = GameManager.Instance.CurrentUser.star >= rocket.price;
            backgroundImage.color = GameManager.Instance.CurrentUser.star >= rocket.price ? Color.white : Color.gray;
        }
        else
        {
            nameText.text = "????";
            amountText.text = "";
            backgroundImage.color = Color.gray;
            rocketImage.color = Color.black;
            purchaseButton.gameObject.SetActive(false);
        }
    }
    public void UpdateUI()
    {
        upgradeLevel = rocket.amount;  
        {
            rocket_Normal.SetActive(true);
        }
        switch (upgradeLevel)
        {
            case 5:
                if (rocket.imageNumber == 0)
                {
                    rocket.imageNumber++;
                    rocketImage.sprite = rocketSprite[rocket.imageNumber];
                    rocketMovement.ChangeRocketSprite();
                }
                break;
            case 21:
                if (rocket.imageNumber == 1)
                {
                    rocket.imageNumber++;
                    rocketImage.sprite = rocketSprite[rocket.imageNumber];
                    rocketMovement.ChangeRocketSprite();
                }
                break;
            case 41:
                if (rocket.imageNumber == 2)
                {
                    rocket.imageNumber++;
                    rocketImage.sprite = rocketSprite[rocket.imageNumber];
                    rocketMovement.ChangeRocketSprite();
                }
                break;
            case 61:
                if (rocket.imageNumber == 3)
                {
                    rocket.imageNumber++;
                    rocketImage.sprite = rocketSprite[rocket.imageNumber];
                    rocketMovement.ChangeRocketSprite();
                }
                break;
        }
        rocketImage.sprite = rocketSprite[rocket.imageNumber];
        nameText.text = rocket.name;
        priceText.text = string.Format("{0:N0} STAR", rocket.price);
        amountText.text = string.Format("{0:N0}", rocket.amount);
    }
    public void OnClickPurchase()
    {
        autoStar = rocket.autoStar;
        if (GameManager.Instance.CurrentUser.star < rocket.price)
        {
            return;
        }
        GameManager.Instance.CurrentUser.star -= rocket.price;
        Rocket rocketInList = GameManager.Instance.CurrentUser.rocketList.Find((x) => x.name == rocket.name);
        rocketInList.amount++;
        rocketInList.price = (long)(rocketInList.price * 1.1f+30);
        rocket.autoStar += 100;
        rocket.autoStar *= 1.03f;
        UpdateUI();
        UpdateValues();
        GameManager.Instance.uiManager.UpdateRocketPanel();
    }
}
