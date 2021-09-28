using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleAnim : MonoBehaviour
{
    float time = 0;
    public float size = 5;
    public float upSizeTime = 0.2f;

    private void Update()
    {
        if(time <=upSizeTime)
        {
            transform.localPosition = Vector3.one * (1 + size * time);
        }
        else if(time<=upSizeTime*2)
        {
            transform.localPosition = Vector3.one * (2 * size * upSizeTime + 1 - time * size);
        }
        else
        {
            transform.localPosition = Vector3.zero;
        }
        time += Time.deltaTime;
    }
    public void resetAnim()
    {
        time = 0;
    }
}
