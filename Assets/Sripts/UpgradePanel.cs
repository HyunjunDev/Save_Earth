using UnityEngine;
using UnityEngine.UI;
public class UpgradePanel : MonoBehaviour
{
    [SerializeField]
    public Image rocketImage = null;
    [SerializeField]
    public Text rocketNameText = null;
    [SerializeField]
    public Text priceText = null;
    [SerializeField]
    public Text amountText = null;
    [SerializeField]
    public Sprite[] rocketSprite = null;
    [SerializeField]
    private Button purchaseButton = null;
    private RocketMovement rocketMovement;
    public static int upgradeLevel = 0;
    public static int normalAutoStar = 30;
    private Rocket rocket = null;
    public void Start()
    {
        rocketMovement = GameObject.Find("Rocket_Normal").GetComponent<RocketMovement>();
    }
    private void Update()
    {
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
    }
    public void SetValue(Rocket rocket)
    {
        this.rocket = rocket;
        RocketUpdateUI();
    }

    public void RocketUpdateUI()
    {
        upgradeLevel = rocket.amount;
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
        rocketNameText.text = rocket.name;
        priceText.text = string.Format("{0} STAR", rocket.price);
        amountText.text = string.Format("{0}", rocket.amount);
    }
    public void OnClickPurchase()
    {
        normalAutoStar = rocket.autoStar;
        if (GameManager.Instance.CurrentUser.star < rocket.price)
        {
            return;
        }
        GameManager.Instance.CurrentUser.star -= rocket.price;
        Rocket rocketInList = GameManager.Instance.CurrentUser.rocketList.Find((x) => x.name == rocket.name);
        rocketInList.amount++;
        rocketInList.price = (long)(rocketInList.price * 1.25f);
        rocket.autoStar += 10;
        RocketUpdateUI();
        GameManager.Instance.uiManager.UpdateRocketPanel();
    }
}
