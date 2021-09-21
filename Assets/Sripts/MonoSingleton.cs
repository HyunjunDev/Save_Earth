using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonoSingleton<T> : MonoBehaviour where T : MonoBehaviour//T 템플릿
{
    private static T instance = null; //static=메모리에 고정
    private static bool shuttingDown = false;
    private static object locker = new object();
    public static T Instance
    {
        get
        {
            if (shuttingDown == true)
            {
                Debug.LogWarning("[Singleton] instance " + typeof(T) + "is already destroyed. returning null.");//버그가 떴을 때 메세지
                return null;//녈을 반환
            }
            lock (locker)//하나만 접근 가능
            {
                if (instance == null)//인스터스가 없으면
                {
                    instance = FindObjectOfType<T>();//T스크립트 찾기
                    if (instance == null)//아예 오브젝트가 없을경우
                    {
                        instance = new GameObject(typeof(T).ToString()).AddComponent<T>();//인스터스를 T의 이름을 가진 오브젝트로 만들고 T가 그 오브젝트에 T를 넣어준다. 
                        DontDestroyOnLoad(Instance);//씬이 넘어가도 파괴하지 않는다.
                    }
                }
                return instance; //인스턴스 반환
            }
        }
    }
    private void OnDestroy()
    {
        shuttingDown = true;
    }
    private void OnApplicationQuit()
    {
        shuttingDown = true;
    }
}

