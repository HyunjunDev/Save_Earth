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
    public Text missileAmountText = null;
    [SerializeField]
    private Sprite[] rocketMissileSprite = null;
    [SerializeField]
    private Button purchaseButton = null;
    private RocketMovement rocketMovement;
    public static int missileUpgradeLevel = 0;
    public static float missileAutoStar = 0;
    private Rocket rocket = null;
    public GameObject rocketMissile;
    public void Start()
    {
        rocketMovement = GameObject.Find("Rocket_Missile").GetComponent<RocketMovement>();
        if (missileUpgradeLevel == 0)
        {
            rocketMissile.SetActive(false);
        }
    }
    private void Update()
    {
        if (rocket.imageNumber == 1)
        {
            rocketMovement.ChangeMissileSprtie();
        }
        else if (rocket.imageNumber == 2)
        {
            rocketMovement.ChangeMissileSprtie();
        }
        else if (rocket.imageNumber == 3)
        {
            rocketMovement.ChangeMissileSprtie();
        }
        else if (rocket.imageNumber == 4)
        {
            rocketMovement.ChangeMissileSprtie();
        }
    }
    public void SetValue(Rocket rocketMissile)
    {
        this.rocket = rocketMissile;
        MissileUpdateUI();
    }
    public void MissileUpdateUI()
    {
        missileUpgradeLevel = rocket.amount;
        if (missileUpgradeLevel == 1)
        {
            rocketMissile.SetActive(true);
        }
        switch (missileUpgradeLevel)
        {
            case 5:
                if(rocket.imageNumber==0)
                {
                    rocket.imageNumber++;
                    rocketMissileImage.sprite = rocketMissileSprite[rocket.imageNumber];
                    rocketMovement.ChangeMissileSprtie();
                }
                break;
            case 21:
                if (rocket.imageNumber == 1)
                {
                    rocket.imageNumber++;
                    rocketMissileImage.sprite = rocketMissileSprite[rocket.imageNumber];
                    rocketMovement.ChangeMissileSprtie();
                }
                break;
            case 41:
                if (rocket.imageNumber == 2)
                {
                    rocket.imageNumber++;
                    rocketMissileImage.sprite = rocketMissileSprite[rocket.imageNumber];
                    rocketMovement.ChangeMissileSprtie();
                }
                break;
            case 61:
                if (rocket.imageNumber == 3)
                {
                    rocket.imageNumber++;
                    rocketMissileImage.sprite = rocketMissileSprite[rocket.imageNumber];
                    rocketMovement.ChangeMissileSprtie();
                }
                break;
        }
        rocketMissileImage.sprite = rocketMissileSprite[rocket.imageNumber];
        missileNameText.text = rocket.name;
        missilePriceText.text = string.Format("{0} STAR", rocket.price);
        missileAmountText.text = string.Format("{0}", rocket.amount);
    }
    public void OnClickPurchase()
    {
        missileAutoStar = rocket.autoStar;
        if (GameManager.Instance.CurrentUser.star < rocket.price)
        {
            return;
        }
        GameManager.Instance.CurrentUser.star -= rocket.price;
        Rocket rocketInList = GameManager.Instance.CurrentUser.rocketMissileList.Find((x) => x.name == rocket.name);
        rocketInList.amount++;
        rocketInList.price = (long)(rocketInList.price * 1.2f);
        rocket.autoStar += 300;
        rocket.autoStar *= 1.3f;
        MissileUpdateUI();
        GameManager.Instance.uiManager.UpdateRocketPanel();
    }
}
