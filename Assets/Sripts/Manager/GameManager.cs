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
        SAVE_PATH = Application.dataPath + "/Save";//파일생성
        if (!Directory.Exists(SAVE_PATH))//Directory 유뮤 검사
        {
            Directory.CreateDirectory(SAVE_PATH);//없을 경우 디렉토리를 만든다.
        }
        print(SAVE_PATH);
        LoadFromJson();
        uiManager = GetComponent<UIManager>();
        InvokeRepeating("SaveToJson", 1f, 60f);
        InvokeRepeating("EarnRocketPerSecond", 0f, 1f);
    }
    private void LoadFromJson()//데이터를 로드하는 함수
    {
        string json = "";
        if (File.Exists(SAVE_PATH + SAVE_FILENAME))//파일의 유무 검사
        {
            json = File.ReadAllText(SAVE_PATH + SAVE_FILENAME);//json이 파일의 내용을 가지고 있다
            user = JsonUtility.FromJson<User>(json);//json안에 있는 내용을 유저로 옮긴다.
        }
        else
        {
            SaveToJson();
            LoadFromJson();
        }
    }
    private void SaveToJson()//제이슨의 정보를 저장하는 함수
    {
        SAVE_PATH = Application.dataPath + "/Save";//경로를 못 찾을 것을 대비하여 썼다.
        if (user == null) return;//유저가 없으면 함수를 좋료시킨다.
        string json = JsonUtility.ToJson(user, true);//json이 유저의 정보를 가지고 있다
        File.WriteAllText(SAVE_PATH + SAVE_FILENAME, json, System.Text.Encoding.UTF8);//파일에다가 json의 내용을 모든 텍스트를 적는다. 방식은 인코딩 방식
    }
    private void OnApplicationQuit()
    {
        SaveToJson();
    }
}
