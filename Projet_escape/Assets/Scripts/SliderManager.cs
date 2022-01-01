using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderManager : MonoBehaviour
{

    [SerializeField] private Text chiffre_volume;
    [SerializeField] private GameObject __slider;
    void Awake()
    {
        __slider.GetComponent<Slider>().value = PlayerPrefs.GetFloat("volume", 0);
    }
    public void Update()
    {
        //chiffre_volume.text=PlayerPrefs.GetFloat("volume", 0).ToString("0.0");
        chiffre_volume.text = __slider.GetComponent<Slider>().value.ToString("0.0");
        AudioListener.volume = __slider.GetComponent<Slider>().value;
        PlayerPrefs.SetFloat("volume", __slider.GetComponent<Slider>().value);
    }
}
