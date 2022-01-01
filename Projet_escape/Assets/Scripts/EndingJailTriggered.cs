using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingJailTriggered : MonoBehaviour
{
    [SerializeField] GameObject Grille;
    [SerializeField] GameObject TextAngry;
    [SerializeField] GameObject TextThanks;
    [Space]
    [SerializeField] Transform Camera;
    private GameObject Player;

    bool hasBeenTriggered = false;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        Grille.SetActive(false);
        TextAngry.SetActive(false);
        TextThanks.SetActive(false);
    }


    void OnTriggerEnter(Collider other)
    {
        //print("playerTrigger");

        if ((other.gameObject == Player))
        {

            if ((!hasBeenTriggered))
            {
                hasBeenTriggered = true;
                Grille.SetActive(true);
                TextAngry.SetActive(true);
                TextThanks.SetActive(true);
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (hasBeenTriggered)
        {

            TextAngry.transform.LookAt(Camera);
            TextThanks.transform.LookAt(Camera);
            Vector3 RotAngry = TextAngry.transform.rotation.eulerAngles;
            Vector3 RotThanks = TextThanks.transform.rotation.eulerAngles;
            RotAngry.x = 0;
            RotAngry.y += 180;
            RotAngry.z = 0;
            TextAngry.transform.rotation = Quaternion.Euler(RotAngry);
            RotThanks.x = 0;
            RotThanks.y += 180;
            RotThanks.z = 0;
            TextThanks.transform.rotation = Quaternion.Euler(RotThanks);
        }
    }
}
