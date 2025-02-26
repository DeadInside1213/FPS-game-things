using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Save : MonoBehaviour
{
    [SerializeField] private Slider Slider;

    public void Saving()
    { 
        float updatenum = Slider.value;
        PlayerPrefs.SetFloat("volume", updatenum);
        PlayerPrefs.Save();
            Loading();
    }

    private void Loading()
    {
        float volume = PlayerPrefs.GetFloat("volume", 100);
        Slider.value = volume;
    }

    private void Start()
    {
        Loading();
    }
}
