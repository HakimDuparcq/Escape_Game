using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoteToggle : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.gameObject.SetActive(false);
    }


    public void Clicked()
    {
        transform.gameObject.SetActive(!transform.gameObject.activeSelf);
    }
    // Update is called once per frame
    void Update()
    {

    }
}
