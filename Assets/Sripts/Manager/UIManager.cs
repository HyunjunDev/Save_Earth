using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Text rocketText = null;
    [SerializeField]
    private UpgradePanel upgradePanel = null;
    [SerializeField]
    private MissileUpgradePanel missileUpgradePanel = null;
    [SerializeField]
    private SpaceshipUpgradePanel spaceshipUpgradePanel = null;
    [SerializeField]
    private PlanetUpgradePanel planetUpgradePanel = null;
    [SerializeField]
    private BananaUpgradePanel bananaUpgradePanel = null;
    [SerializeField]
    private PencilUpgradePanel pencilUpgradePanel = null;
    [SerializeField]
    private SpeedUpgradePanel speedUpgradePanel = null;
    [SerializeField]
    private FaceUpgradePanel faceUpgradePanel = null;
    [SerializeField]
    private TrainUpgradePanel trainUpgradePanel = null;
    [SerializeField]
    private ShuttleUpgradePanel shuttleUpgradePanel = null;
    [SerializeField]
    private MetorUpgradePanel metorUpgradePanel = null;
    [SerializeField]
    private MoonUpgradePanel moonUpgradePanel = null;
    [SerializeField]
    private EffectText StarTextTemplate = null;
    [SerializeField]
    private GameObject star = null;
    private Vector2 mousePos;
    private User user;
    private Planet planet;

    private List<UpgradePanel> upgradePanelsList = new List<UpgradePanel>();
    private List<MissileUpgradePanel> missileUpgradePanels = new List<MissileUpgradePanel>();
    private List<SpaceshipUpgradePanel> spaceshipUpgradePanels = new List<SpaceshipUpgradePanel>();
    private List<PlanetUpgradePanel> planetUpgradePanels = new List<PlanetUpgradePanel>();
    private List<MetorUpgradePanel> metorUpgradePanels = new List<MetorUpgradePanel>();
    private List<MoonUpgradePanel> moonUpgradePanels = new List<MoonUpgradePanel>();
    private List<BananaUpgradePanel> bananaUpgradePanels = new List<BananaUpgradePanel>();
    private List<SpeedUpgradePanel> speedUpgradePanels = new List<SpeedUpgradePanel>();
    private List<PencilUpgradePanel> pencilUpgradePanels = new List<PencilUpgradePanel>();
    private List<FaceUpgradePanel> faceUpgradePanels = new List<FaceUpgradePanel>();
    private List<ShuttleUpgradePanel> shuttleUpgradePanels = new List<ShuttleUpgradePanel>();
    private List<TrainUpgradePanel> trainUpgradePanels = new List<TrainUpgradePanel>();
    void Start()
    {
        star.SetActive(false);
        UpdateRocketPanel();
        CreatePanels();
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            star.SetActive(true);
            star.transform.position = new Vector3(mousePos.x, mousePos.y, 0f);
        }
    }
    public void CreatePanels()
    {
        GameObject panel = null;
        UpgradePanel panelComponent = null;
        MissileUpgradePanel panelMComponent = null;
        SpaceshipUpgradePanel panelSComponent = null;
        PlanetUpgradePanel panelPComponent = null;
        MetorUpgradePanel panelMetorComponent = null;
        BananaUpgradePanel panelBComponent = null;
        SpeedUpgradePanel panelSpeedComponent = null;
        PencilUpgradePanel panelPencilComponent = null;
        FaceUpgradePanel panelFComponent = null;
        ShuttleUpgradePanel panelShuttleComponent = null;
        TrainUpgradePanel panelTComponent = null;
        MoonUpgradePanel panelMoonComponent = null;
        foreach (Rocket rocket in GameManager.Instance.CurrentUser.rocketList)
        {
            panel = Instantiate(upgradePanel.gameObject, upgradePanel.transform.parent);
            panelComponent = panel.GetComponent<UpgradePanel>();
            panelComponent.SetValue(rocket);
            panel.SetActive(true);
            upgradePanelsList.Add(panelComponent);
        }
        foreach (Rocket rocket in GameManager.Instance.CurrentUser.rocketMissileList)
        {
            panel = Instantiate(missileUpgradePanel.gameObject, missileUpgradePanel.transform.parent);
            panelMComponent = panel.GetComponent<MissileUpgradePanel>();
            panelMComponent.SetValue(rocket);
            panel.SetActive(true);
            missileUpgradePanels.Add(panelMComponent);
        }
        foreach (Rocket rocket in GameManager.Instance.CurrentUser.rocketSpaceshipList)
        {
            panel = Instantiate(spaceshipUpgradePanel.gameObject, spaceshipUpgradePanel.transform.parent);
            panelSComponent = panel.GetComponent<SpaceshipUpgradePanel>();
            panelSComponent.SetValue(rocket);
            panel.SetActive(true);
            spaceshipUpgradePanels.Add(panelSComponent);
        }
        foreach (Rocket rocket in GameManager.Instance.CurrentUser.rocketBananaList)
        {
            panel = Instantiate(bananaUpgradePanel.gameObject, bananaUpgradePanel.transform.parent);
            panelBComponent = panel.GetComponent<BananaUpgradePanel>();
            panelBComponent.SetValue(rocket);
            panel.SetActive(true);
            bananaUpgradePanels.Add(panelBComponent);
        }
        foreach (Rocket rocket in GameManager.Instance.CurrentUser.rocketSpeedList)
        {
            panel = Instantiate(speedUpgradePanel.gameObject, speedUpgradePanel.transform.parent);
            panelSpeedComponent = panel.GetComponent<SpeedUpgradePanel>();
            panelSpeedComponent.SetValue(rocket);
            panel.SetActive(true);
            speedUpgradePanels.Add(panelSpeedComponent);
        }
        foreach (Rocket rocket in GameManager.Instance.CurrentUser.rocketPencilList)
        {
            panel = Instantiate(pencilUpgradePanel.gameObject, pencilUpgradePanel.transform.parent);
            panelPencilComponent = panel.GetComponent<PencilUpgradePanel>();
            panelPencilComponent.SetValue(rocket);
            panel.SetActive(true);
            pencilUpgradePanels.Add(panelPencilComponent);
        }
        foreach (Rocket rocket in GameManager.Instance.CurrentUser.rocketFaceList)
        {
            panel = Instantiate(faceUpgradePanel.gameObject, faceUpgradePanel.transform.parent);
            panelFComponent = panel.GetComponent<FaceUpgradePanel>();
            panelFComponent.SetValue(rocket);
            panel.SetActive(true);
            faceUpgradePanels.Add(panelFComponent);
        }
        foreach (Rocket rocket in GameManager.Instance.CurrentUser.rocketShuttleList)
        {
            panel = Instantiate(shuttleUpgradePanel.gameObject, shuttleUpgradePanel.transform.parent);
            panelShuttleComponent = panel.GetComponent<ShuttleUpgradePanel>();
            panelShuttleComponent.SetValue(rocket);
            panel.SetActive(true);
            shuttleUpgradePanels.Add(panelShuttleComponent);
        }
        foreach (Rocket rocket in GameManager.Instance.CurrentUser.rocketTrainList)
        {
            panel = Instantiate(trainUpgradePanel.gameObject, trainUpgradePanel.transform.parent);
            panelTComponent = panel.GetComponent<TrainUpgradePanel>();
            panelTComponent.SetValue(rocket);
            panel.SetActive(true);
            trainUpgradePanels.Add(panelTComponent);
        }
        foreach (Planet planet in GameManager.Instance.CurrentUser.planetList)
        {
            panel = Instantiate(planetUpgradePanel.gameObject, planetUpgradePanel.transform.parent);
            panelPComponent = panel.GetComponent<PlanetUpgradePanel>();
            panelPComponent.SetValue(planet);
            panel.SetActive(true);
            planetUpgradePanels.Add(panelPComponent);
        }
        foreach (Planet planet in GameManager.Instance.CurrentUser.metorList)
        {
            panel = Instantiate(metorUpgradePanel.gameObject, metorUpgradePanel.transform.parent);
            panelMetorComponent = panel.GetComponent<MetorUpgradePanel>();
            panelMetorComponent.SetValue(planet);
            panel.SetActive(true);
            metorUpgradePanels.Add(panelMetorComponent);
        }
        foreach (Planet planet in GameManager.Instance.CurrentUser.moonList)
        {
            panel = Instantiate(moonUpgradePanel.gameObject, moonUpgradePanel.transform.parent);
            panelMoonComponent = panel.GetComponent<MoonUpgradePanel>();
            panelMoonComponent.SetValue(planet);
            panel.SetActive(true);
            moonUpgradePanels.Add(panelMoonComponent);
        }
    }

    public void OnClickRocket()
    {

        GameManager.Instance.CurrentUser.star += PlanetUpgradePanel.planetTouchStar + MetorUpgradePanel.metorTouchStar+MoonUpgradePanel.moonTouchStar;
        EffectText newText = null;
        if (GameManager.Instance.Pool.childCount > 0)
        {
            newText = GameManager.Instance.Pool.GetChild(0).GetComponent<EffectText>();
            newText.transform.SetParent(GameManager.Instance.Pool.parent);
        }
        else
        {
            newText = Instantiate(StarTextTemplate, GameManager.Instance.Pool.parent).GetComponent<EffectText>();
        }
        newText.gameObject.SetActive(true);
        newText.Show((int)PlanetUpgradePanel.planetTouchStar + (int)MetorUpgradePanel.metorTouchStar + (int)MoonUpgradePanel.moonTouchStar);
        UpdateRocketPanel();
    }

    public void UpdateRocketPanel()
    {
        rocketText.text = string.Format("{0:N0} STAR", (int)GameManager.Instance.CurrentUser.star);
    }
}
