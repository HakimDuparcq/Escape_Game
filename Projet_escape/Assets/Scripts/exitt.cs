using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class exitt : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void On_click_go_to_start()
    {
        //PlayerPrefs.SetFloat("volume", );
        SceneManager.LoadScene("Start");

    }

}
