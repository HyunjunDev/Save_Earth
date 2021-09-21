using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonoSingleton<T> : MonoBehaviour where T : MonoBehaviour//T ���ø�
{
    private static T instance = null; //static=�޸𸮿� ����
    private static bool shuttingDown = false;
    private static object locker = new object();
    public static T Instance
    {
        get
        {
            if (shuttingDown == true)
            {
                Debug.LogWarning("[Singleton] instance " + typeof(T) + "is already destroyed. returning null.");//���װ� ���� �� �޼���
                return null;//���� ��ȯ
            }
            lock (locker)//�ϳ��� ���� ����
            {
                if (instance == null)//�ν��ͽ��� ������
                {
                    instance = FindObjectOfType<T>();//T��ũ��Ʈ ã��
                    if (instance == null)//�ƿ� ������Ʈ�� �������
                    {
                        instance = new GameObject(typeof(T).ToString()).AddComponent<T>();//�ν��ͽ��� T�� �̸��� ���� ������Ʈ�� ����� T�� �� ������Ʈ�� T�� �־��ش�. 
                        DontDestroyOnLoad(Instance);//���� �Ѿ�� �ı����� �ʴ´�.
                    }
                }
                return instance; //�ν��Ͻ� ��ȯ
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

