using UnityEngine;
using UnityEngine.UI;

public class FaceUpgradePanel : MonoBehaviour
{
    [SerializeField]
    public Image rocketImage = null;
    [SerializeField]
    public Text nameText = null;
    [SerializeField]
    public Text priceText = null;
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
        rocketMovement = GameObject.Find("Rocket_Face").GetComponent<RocketMovement>();
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
            rocketMovement.ChangeFaceSprtie();
        }
        else if (rocket.imageNumber == 2)
        {
            rocketMovement.ChangeFaceSprtie();
        }
        else if (rocket.imageNumber == 3)
        {
            rocketMovement.ChangeFaceSprtie();
        }
        else if (rocket.imageNumber == 4)
        {
            rocketMovement.ChangeFaceSprtie();
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
        if (!rocket.Locked&&PencilUpgradePanel.upgradeLevel>=30)
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
            case 10:
                if (rocket.imageNumber == 0)
                {
                    rocket.imageNumber++;
                    rocketImage.sprite = rocketSprite[rocket.imageNumber];
                    rocketMovement.ChangeFaceSprtie();
                }
                break;
            case 20:
                if (rocket.imageNumber == 1)
                {
                    rocket.imageNumber++;
                    rocketImage.sprite = rocketSprite[rocket.imageNumber];
                    rocketMovement.ChangeFaceSprtie();
                }
                break;
            case 30:
                if (rocket.imageNumber == 2)
                {
                    rocket.imageNumber++;
                    rocketImage.sprite = rocketSprite[rocket.imageNumber];
                    rocketMovement.ChangeFaceSprtie();
                }
                break;
            case 40:
                if (rocket.imageNumber == 3)
                {
                    rocket.imageNumber++;
                    rocketImage.sprite = rocketSprite[rocket.imageNumber];
                    rocketMovement.ChangeFaceSprtie();
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
        Rocket rocketInList = GameManager.Instance.CurrentUser.rocketFaceList.Find((x) => x.name == rocket.name);
        rocketInList.amount++;
        rocketInList.price = (long)(rocketInList.price * 1.08f + 3200);
        rocket.autoStar += 1300;
        rocket.autoStar *= 1.07f;
        UpdateUI();
        UpdateValues();
        GameManager.Instance.uiManager.UpdateRocketPanel();
    }
}
