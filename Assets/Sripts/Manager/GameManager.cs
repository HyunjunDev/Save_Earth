using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GameManager : MonoSingleton<GameManager>
{
    [SerializeField]
    private User user = null;
    [SerializeField]
    private Transform textPool = null;
    public Transform Pool { get { return textPool; } }
    public User CurrentUser { get { return user; } }
    private string SAVE_PATH = "";
    private readonly string SAVE_FILENAME = "/SaveFile.txt";
    public UIManager uiManager { get; private set; }
    public List<GameObject> contentsPanels;
    public void EarnRocketPerSecond()
    {
        foreach (Rocket rocket in user.rocketList)
        {
            user.star += rocket.ePs * rocket.amount;
        }
        uiManager.UpdateRocketPanel();
    }
    private void Awake()
    {
        SAVE_PATH = Application.dataPath + "/Save";//���ϻ���
        if (!Directory.Exists(SAVE_PATH))//Directory ���� �˻�
        {
            Directory.CreateDirectory(SAVE_PATH);//���� ��� ���丮�� �����.
        }
        print(SAVE_PATH);
        LoadFromJson();
        uiManager = GetComponent<UIManager>();
        InvokeRepeating("SaveToJson", 1f, 60f);
        InvokeRepeating("EarnRocketPerSecond", 0f, 1f);
    }
    private void LoadFromJson()//�����͸� �ε��ϴ� �Լ�
    {
        string json = "";
        if (File.Exists(SAVE_PATH + SAVE_FILENAME))//������ ���� �˻�
        {
            json = File.ReadAllText(SAVE_PATH + SAVE_FILENAME);//json�� ������ ������ ������ �ִ�
            user = JsonUtility.FromJson<User>(json);//json�ȿ� �ִ� ������ ������ �ű��.
        }
        else
        {
            SaveToJson();
            LoadFromJson();
        }
    }
    private void SaveToJson()//���̽��� ������ �����ϴ� �Լ�
    {
        SAVE_PATH = Application.dataPath + "/Save";//��θ� �� ã�� ���� ����Ͽ� ���.
        if (user == null) return;//������ ������ �Լ��� �����Ų��.
        string json = JsonUtility.ToJson(user, true);//json�� ������ ������ ������ �ִ�
        File.WriteAllText(SAVE_PATH + SAVE_FILENAME, json, System.Text.Encoding.UTF8);//���Ͽ��ٰ� json�� ������ ��� �ؽ�Ʈ�� ���´�. ����� ���ڵ� ���
    }
    private void OnApplicationQuit()
    {
        SaveToJson();
    }
}
