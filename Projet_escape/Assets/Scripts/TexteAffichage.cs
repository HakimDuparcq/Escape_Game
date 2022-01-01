using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TexteAffichage : MonoBehaviour
{

    //[SerializeField] private GameObject text;
    [SerializeField] private GameObject sphere;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject canvas;
    public Button button;

    private int dedans;
    // Start is called before the first frame update
    void Start()
    {
        //text.SetActive(false);
        canvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        ActionQuandDedans();
    }

    private void OnTriggerEnter(Collider col)
    {
        
        if (col.name == player.name)
        {
            dedans = 1;
            button.gameObject.SetActive(true);
            //text.SetActive(true);
        }
    }
    

    public void ActionQuandDedans()
    {
        if (dedans==1)
        {
            if (Input.GetKeyDown("space"))
            {
                
                interact_coffre_fort();
            }
        }
    }



    private void OnTriggerExit(Collider col)
    {
        
        if (col.name == player.name)
        {
            dedans = 0;
            button.gameObject.SetActive(false);
            //print("no");
            //text.SetActive(false);
            canvas.SetActive(false);
        }
    }

    public void interact_coffre_fort()
    {
        canvas.SetActive(true);
    }

}
