using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class panneau : MonoBehaviour
{
    [SerializeField] private GameObject control_text;
    [SerializeField] private GameObject sound_text;
    [SerializeField] private GameObject credit_text;
    [SerializeField] private GameObject slider_sound;
    private script1 _script1;
    // Start is called before the first frame update
    void Start()
    {
        control_text.SetActive(false);
        sound_text.SetActive(false);
        credit_text.SetActive(false);
        _script1 = GetComponent<script1>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_script1.paneau_num == 0)
        {
            slider_sound.SetActive(false);
        }
        if (_script1.paneau_num == 1)
        {
            control_text.SetActive(true);
            sound_text.SetActive(false);
            credit_text.SetActive(false);
            slider_sound.SetActive(false);
        }
        if (_script1.paneau_num == 2)
        {
            control_text.SetActive(false);
            sound_text.SetActive(true);
            credit_text.SetActive(false);
            slider_sound.SetActive(true);
        }
        if (_script1.paneau_num == 3)
        {
            control_text.SetActive(false);
            sound_text.SetActive(false);
            credit_text.SetActive(true);
            slider_sound.SetActive(false);
        }
    }
}
