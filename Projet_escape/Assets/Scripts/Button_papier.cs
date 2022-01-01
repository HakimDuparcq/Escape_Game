using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Button_papier : MonoBehaviour
{
    [SerializeField] GameObject canvas;
    public TextMeshProUGUI Code;

    
    void Start()
    {
        canvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClikButtonClose()
    {
        canvas.SetActive(false);
    }

}
