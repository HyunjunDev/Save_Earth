using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField]
    private AudioSource BGM;
    [SerializeField]
    private AudioSource btnSound;
    [SerializeField]
    private AudioSource btnSound1;

    public void SetBGMVolume(float volume)
    {
        BGM.volume = volume;
    }
    public void SetBtnVolume(float volume)
    {
        btnSound1.volume = volume;
        btnSound.volume = volume;
    }

    public void OnSfx()
    {
        btnSound1.Play();
    }
}
