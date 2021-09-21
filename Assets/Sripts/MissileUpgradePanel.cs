using UnityEngine;
using UnityEngine.UI;

public class MissileUpgradePanel : MonoBehaviour
{
    [SerializeField]
    public Image rocketMissileImage = null;
    [SerializeField]
    public Text missileNameText = null;
    [SerializeField]
    public Text missilePriceText = null;
    [SerializeField]
    public Text MissileAmountText = null;
    [SerializeField]
    private Sprite[] rocketMissileSprite = null;
    [SerializeField]
    private Button purchaseButton = null;
    private RocketMovement rocketMovement;
    public static int missileUpgradeLevel = 0;
    private Rocket rocket = null;

    public void Start()
    {
        rocketMovement = GameObject.Find("Rocket_Missile").GetComponent<RocketMovement>();
    }
    public void SetValue(Rocket rocketMissile)
    {
        this.rocket = rocketMissile;
        MissileUpdateUI();
    }
    public void MissileUpdateUI()
    {
        switch (missileUpgradeLevel)
        {
            case 5:
                rocketMissileImage.sprite = rocketMissileSprite[rocket.imageNumber++];
                rocketMovement.ChangeMissileSprtie();
                break;
        }
        rocketMissileImage.sprite = rocketMissileSprite[rocket.imageNumber];
        missileNameText.text = rocket.name;
        missilePriceText.text = string.Format("{0} STAR", rocket.price);
        MissileAmountText.text = string.Format("{0}", rocket.amount);
    }
    public void OnClickPurchase()
    {
        if (GameManager.Instance.CurrentUser.star < rocket.price)
        {
            return;
        }
        GameManager.Instance.CurrentUser.star -= rocket.price;
        Rocket rocketInList = GameManager.Instance.CurrentUser.rocketMissileList.Find((x) => x.name == rocket.name);
        missileUpgradeLevel++;
        rocketInList.amount++;
        rocketInList.price = (long)(rocketInList.price * 1.25f);
        UIManager.touchStar += 2;
        MissileUpdateUI();
        GameManager.Instance.uiManager.UpdateRocketPanel();
    }
}
