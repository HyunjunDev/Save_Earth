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
    private Rocket rocket = null;
    public void Start()
    {
        rocketMovement = GameObject.Find("Rocket_Spaceship").GetComponent<RocketMovement>();
    }
    private void Update()
    {
        if(rocket.imageNumber==1)
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
        }
        rocketSpaceshipImage.sprite = rocketspaceshipSprite[rocket.imageNumber];
        spaceshipNameText.text = rocket.name;
        spaceshipPriceText.text = string.Format("{0} STAR", rocket.price);
        spaceAmountText.text = string.Format("{0}", rocket.amount);
    }
    public void OnClickPurchase()
    {
        if (GameManager.Instance.CurrentUser.star < rocket.price)
        {
            return;
        }
        GameManager.Instance.CurrentUser.star -= rocket.price;
        Rocket rocketInList = GameManager.Instance.CurrentUser.rocketSpaceshipList.Find((x) => x.name == rocket.name);
        rocketInList.amount++;
        rocketInList.price = (long)(rocketInList.price * 1.25f);
        rocket.autoStar += 1000;
        SpaceshipUpdateUI();
        GameManager.Instance.uiManager.UpdateRocketPanel();
    }
}
