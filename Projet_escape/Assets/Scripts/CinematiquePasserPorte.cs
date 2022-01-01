using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CinematiquePasserPorte : MonoBehaviour
{

    public GameObject player;
    private float offsetx = 10;
    private float offsety = 10;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.name==player.name)
        {
            Debug.Log("entre");
            PlayerPrefs.SetFloat("offsettx", 2.15f);
            PlayerPrefs.SetFloat("offsetty", 0.97f);
            PlayerPrefs.SetFloat("force_cam", 15);
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.name == player.name)
        {
            Debug.Log("sort");
            PlayerPrefs.SetFloat("offsettx", 4.85f);
            PlayerPrefs.SetFloat("offsetty", 3.54f);
            PlayerPrefs.SetFloat("force_cam", 5);
        }
    }
}
