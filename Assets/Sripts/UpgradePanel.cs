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
    private Rocket rocket = null;
    public void Start()
    {
        rocketMovement = GameObject.Find("Rocket_Normal").GetComponent<RocketMovement>();
    }
    public void SetValue(Rocket rocket)
    {
        this.rocket = rocket;
        RocketUpdateUI();
    }

    public void RocketUpdateUI()
    {
        switch (upgradeLevel)
        {
            case 5:
                rocketImage.sprite = rocketSprite[rocket.imageNumber++];
                rocketMovement.ChangeRocketSprite();
                break;
        }
        rocketImage.sprite = rocketSprite[rocket.imageNumber];
        rocketNameText.text = rocket.name;
        priceText.text = string.Format("{0} STAR", rocket.price);
        amountText.text = string.Format("{0}", rocket.amount);
    }
    public void OnClickPurchase()
    {
        if (GameManager.Instance.CurrentUser.star < rocket.price)
        {
            return;
        }
        GameManager.Instance.CurrentUser.star -= rocket.price;
        Rocket rocketInList = GameManager.Instance.CurrentUser.rocketList.Find((x) => x.name == rocket.name);
        upgradeLevel++;
        rocketInList.amount++;
        rocketInList.price = (long)(rocketInList.price * 1.25f);
        UIManager.touchStar += 2;
        RocketUpdateUI();
        GameManager.Instance.uiManager.UpdateRocketPanel();
    }
}
