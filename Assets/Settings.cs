using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    [SerializeField] AudioManager audioManager;
    [SerializeField] Toggle muteToggle;
    [SerializeField] Slider bgmSlider;
    [SerializeField] Slider sfxSlider;

    private void Awake()
    {
        Application.targetFrameRate = 25;
    }

    private void Start()
    {
        muteToggle.isOn = audioManager.IsMute;
        bgmSlider.value = audioManager.BgmVolume;
        sfxSlider.value = audioManager.SfxVolume;
    }

    public void FPSChanged(bool value)
    {
        if (value)
        {
            Application.targetFrameRate = -1; // unlock FPS
        }
        else
        {
            Application.targetFrameRate = 25; // limit FPS to 25
        }
    }
}
