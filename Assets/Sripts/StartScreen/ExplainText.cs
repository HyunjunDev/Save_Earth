using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ExplainText : MonoBehaviour
{
    Text flashingText;
    void Start()
    {
        flashingText = GetComponent<Text>();
        StartCoroutine(ExplainTex());
    }
    public IEnumerator ExplainTex()
    {
        while (true)
        {
            flashingText.text = "-�ȳ�-\n���� ���� ��\n�� PLANET ��ư��\n�� �� �����ּž�\n���� PLANET �����͸�\n�Ҿ�� �� �ֽ��ϴ�";
            yield return new WaitForSeconds(5f);
            flashingText.text = "";
            yield return new WaitForSeconds(0.5f);
        }
    }
}
