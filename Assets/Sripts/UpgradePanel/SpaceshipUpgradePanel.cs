using UnityEngine;
using UnityEngine.UI;

public class SpaceshipUpgradePanel : MonoBehaviour
{
    [SerializeField]
    public Image rocketSpaceshipImage = null;
    [SerializeField]
    public Text spaceshipNameText = null;
    [SerializeField]
    public Text spaceshipPriceText = null;
    [SerializeField]
    public Text spaceAmountText = null;
    [SerializeField]
    private Sprite[] rocketspaceshipSprite = null;
    [SerializeField]
    private Button purchaseButton = null;
    private RocketMovement rocketMovement;
    public static int spaceshipUpgradeLevel = 0;
    public static float SpaceshipAutoStar = 0;
    private Rocket rocket = null;
    public GameObject rocketSpaceship;
    public void Start()
    {
        rocketMovement = GameObject.Find("Rocket_Spaceship").GetComponent<RocketMovement>();
        if (spaceshipUpgradeLevel==0)
        {
            rocketSpaceship.SetActive(false);
        }
    }
    private void Update()
    {
        if (rocket.imageNumber==1)
        {
            rocketMovement.ChangeSpaceshipSprtie();
        }
        else if (rocket.imageNumber == 2)
        {
            rocketMovement.ChangeSpaceshipSprtie();
        }
        else if (rocket.imageNumber == 3)
        {
            rocketMovement.ChangeSpaceshipSprtie();
        }
        else if (rocket.imageNumber == 4)
        {
            rocketMovement.ChangeSpaceshipSprtie();
        }
    }
    public void SetValue(Rocket rocketSpaceship)
    {
        this.rocket = rocketSpaceship;
        SpaceshipUpdateUI();
    }
    public void SpaceshipUpdateUI()
    {
        spaceshipUpgradeLevel = rocket.amount;
        if (spaceshipUpgradeLevel == 1)
        {
            rocketSpaceship.SetActive(true);
        }
        switch (spaceshipUpgradeLevel)
        {
            case 5:
                if(rocket.imageNumber==0)
                {
                    rocket.imageNumber++;
                    rocketSpaceshipImage.sprite = rocketspaceshipSprite[rocket.imageNumber];
                    rocketMovement.ChangeSpaceshipSprtie();
                }
                break;
            case 21:
                if (rocket.imageNumber == 1)
                {
                    rocket.imageNumber++;
                    rocketSpaceshipImage.sprite = rocketspaceshipSprite[rocket.imageNumber];
                    rocketMovement.ChangeSpaceshipSprtie();
                }
                break;
            case 41:
                if (rocket.imageNumber == 2)
                {
                    rocket.imageNumber++;
                    rocketSpaceshipImage.sprite = rocketspaceshipSprite[rocket.imageNumber];
                    rocketMovement.ChangeSpaceshipSprtie();
                }
                break;
            case 61:
                if (rocket.imageNumber == 3)
                {
                    rocket.imageNumber++;
                    rocketSpaceshipImage.sprite = rocketspaceshipSprite[rocket.imageNumber];
                    rocketMovement.ChangeSpaceshipSprtie();
                }
                break;
        }
        rocketSpaceshipImage.sprite = rocketspaceshipSprite[rocket.imageNumber];
        spaceshipNameText.text = rocket.name;
        spaceshipPriceText.text = string.Format("{0} STAR", rocket.price);
        spaceAmountText.text = string.Format("{0}", rocket.amount);
    }
    public void OnClickPurchase()
    {
        SpaceshipAutoStar = rocket.autoStar;
        if (GameManager.Instance.CurrentUser.star < rocket.price)
        {
            return;
        }
        GameManager.Instance.CurrentUser.star -= rocket.price;
        Rocket rocketInList = GameManager.Instance.CurrentUser.rocketSpaceshipList.Find((x) => x.name == rocket.name);
        rocketInList.amount++;
        rocketInList.price = (long)(rocketInList.price * 1.2f);
        rocket.autoStar += 1000;
        rocket.autoStar *= 1.4f;
        SpaceshipUpdateUI();
        GameManager.Instance.uiManager.UpdateRocketPanel();
    }
}
