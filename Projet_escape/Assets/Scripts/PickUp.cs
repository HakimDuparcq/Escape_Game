using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUp : MonoBehaviour
{
    private GameObject player;
    private Inventory inventory;
    public GameObject itemButton;
    public GameObject canvas;
    public Button buttonTake;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        inventory = player.GetComponent<Inventory>();
        
        

    }
    void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject==player)
        {
            buttonTake.gameObject.SetActive(true);
            buttonTake.onClick.RemoveListener(Take);
            buttonTake.onClick.AddListener(Take);
            
        }
    }

    void OnTriggerExit(Collider other)
    {

        if (other.gameObject == player)
        {
            buttonTake.gameObject.SetActive(false);

        }
    }

    void Take()
    {
        
        for (int i = 0; i < inventory.slots.Length; i++)
        {
            if (inventory.isFull[i] == false) // si la case est vide on l'ajoute à l'inventaire
            {
                
                inventory.isFull[i] = true;
                GameObject create = Instantiate(itemButton, inventory.slots[i].transform.position, Quaternion.identity);
                create.transform.SetParent(canvas.transform, true);
                Destroy(gameObject);
                buttonTake.gameObject.SetActive(false);
                break;
            }
            
        }
    }
}
