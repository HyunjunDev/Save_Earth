using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TabButton : MonoBehaviour
{
    Image background;
    public Sprite idlemg;
    public Sprite selectdlmg;
    private void Awake()
    {
        background = GetComponent<Image>();
    }
    public void Selected()
    {
        background.sprite = selectdlmg;
    }
    public void DeSelected()
    {
        background.sprite = idlemg;
    }
}
