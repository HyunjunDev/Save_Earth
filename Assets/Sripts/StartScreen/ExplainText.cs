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
            flashingText.text = "-안내-\n게임 시작 후\n꼭 PLANET 버튼을\n한 번 눌러주셔야\n기존 PLANET 데이터를\n불어올 수 있습니다";
            yield return new WaitForSeconds(5f);
            flashingText.text = "";
            yield return new WaitForSeconds(0.5f);
        }
    }
}
