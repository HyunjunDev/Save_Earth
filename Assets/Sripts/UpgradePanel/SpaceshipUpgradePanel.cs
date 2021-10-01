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
    [SerializeField]
    private Image backgroundImage = null;
    private RocketMovement rocketMovement;
    public static int spaceshipUpgradeLevel = 0;
    public static float SpaceshipAutoStar = 0;
    private Rocket rocket = null;
    public GameObject rocketSpaceship;
    public void Start()
    {
        UpdateValues();
        rocketMovement = GameObject.Find("Rocket_Spaceship").GetComponent<RocketMovement>();
        if (spaceshipUpgradeLevel==0)
        {
            rocketSpaceship.SetActive(false);
        }
    }
    private void Update()
    {
        UpdateValues();
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
        if (spaceshipUpgradeLevel >= 50)
        {
            spaceAmountText.text = "MAX";
            purchaseButton.gameObject.SetActive(false);
        }
      
    }
    public void SetValue(Rocket rocketSpaceship)
    {
        this.rocket = rocketSpaceship;
        SpaceshipUpdateUI();
    }
    public void UpdateValues()
    {
        spaceshipPriceText.text = string.Format("{0:N0} STAR", rocket.price);
        if (rocketspaceshipSprite != null)
        {
            rocketSpaceshipImage.sprite = rocketspaceshipSprite[rocket.imageNumber];
        }
        if (!rocket.Locked&&MissileUpgradePanel.missileUpgradeLevel>=25)
        {
            spaceshipNameText.text = rocket.name;
            spaceAmountText.text = string.Format("{0}", rocket.amount);
            rocketSpaceshipImage.color = Color.white;
            purchaseButton.gameObject.SetActive(true);
            purchaseButton.interactable = GameManager.Instance.CurrentUser.star >= rocket.price;
            backgroundImage.color = GameManager.Instance.CurrentUser.star >= rocket.price ? Color.white : Color.gray;
        }
        else
        {
            spaceshipNameText.text = "????";
            spaceAmountText.text = "";
            backgroundImage.color = Color.gray;
            rocketSpaceshipImage.color = Color.black;
            purchaseButton.gameObject.SetActive(false);
        }
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
            case 10:
                if(rocket.imageNumber==0)
                {
                    rocket.imageNumber++;
                    rocketSpaceshipImage.sprite = rocketspaceshipSprite[rocket.imageNumber];
                    rocketMovement.ChangeSpaceshipSprtie();
                }
                break;
            case 20:
                if (rocket.imageNumber == 1)
                {
                    rocket.imageNumber++;
                    rocketSpaceshipImage.sprite = rocketspaceshipSprite[rocket.imageNumber];
                    rocketMovement.ChangeSpaceshipSprtie();
                }
                break;
            case 30:
                if (rocket.imageNumber == 2)
                {
                    rocket.imageNumber++;
                    rocketSpaceshipImage.sprite = rocketspaceshipSprite[rocket.imageNumber];
                    rocketMovement.ChangeSpaceshipSprtie();
                }
                break;
            case 40:
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
        spaceshipPriceText.text = string.Format("{0:N0} STAR", rocket.price);
        spaceAmountText.text = string.Format("{0:N0}", rocket.amount);
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
        rocketInList.price = (long)(rocketInList.price * 1.04f+300);
        rocket.autoStar += 1000;
        rocket.autoStar *= 1.03f;
        SpaceshipUpdateUI();
        UpdateValues();
        GameManager.Instance.uiManager.UpdateRocketPanel();
    }
}
