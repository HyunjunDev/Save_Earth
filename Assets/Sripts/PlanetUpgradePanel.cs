using UnityEngine;
using UnityEngine.UI;

public class PlanetUpgradePanel : MonoBehaviour
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
    private RocketMovement planetMovement;
    public static int upgradeLevel = 0;
    private Planet planet = null;
    public void SetValue(Planet planet)
    {
        PlanetUpdateUI();
    }
    public void PlanetUpdateUI()
    {
        switch (upgradeLevel)
        {
            case 5:
                planetImage.sprite = planetSprite[planet.imageNumber++];
                planetMovement.ChangeRocketSprite();
                break;
        }
        planetImage.sprite = planetSprite[planet.imageNumber];
        planetNameText.text = planet.name;
        priceText.text = string.Format("{0} STAR", planet.price);
        amountText.text = string.Format("{0}", planet.amount);
    }
    public void OnClickPurchase()
    {
        if (GameManager.Instance.CurrentUser.star < planet.price)
        {
            return;
        }
        GameManager.Instance.CurrentUser.star -= planet.price;
        Rocket rocketInList = GameManager.Instance.CurrentUser.rocketList.Find((x) => x.name == planet.name);
        upgradeLevel++;
        rocketInList.amount++;
        rocketInList.price = (long)(rocketInList.price * 1.25f);
        UIManager.touchStar += 2;
        PlanetUpdateUI();
        GameManager.Instance.uiManager.UpdateRocketPanel();
    }
}
