using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test_volume : MonoBehaviour
{
    [SerializeField] private int vol = 0;
    AudioSource audioo;
    //private Slider _slider;

    // Start is called before the first frame update
    void Start()
    {
        audioo = gameObject.GetComponent<AudioSource>();
        //_slider = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(_slider.);
    }
}