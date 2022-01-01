using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Torchcontrol : MonoBehaviour
{
    bool toggled = false;
    //[SerializeField] public GameObject Lamp;
    // Start is called before the first frame update
    void Start()
    {
        transform.gameObject.SetActive(toggled);

        //this.GetComponent<Button>().onClick.AddListener(ToggleLamp);
    }

    
    public void ToggleLamp()
    {
        print("click");
        toggled = !toggled;
        transform.gameObject.SetActive(toggled);
    }

  

    // Update is called once per frame
    void Update()
    {
        
    }
}
