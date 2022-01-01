using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    [SerializeField] private float speed = 3f; //vitesse de course
    public float rotationRate = 360; // Faire un tour complet

    // Noms des inputs (project settings) � lire pour le d�placement 
    private string moveInputAxis = "Vertical";
    private string turnInputAxis = "Horizontal";

    //Hauteur de saut
    public float heightJump;


    // Seuil de l'input pour d�terminer s'il se d�place 
    public float minToMove = 0.1f;

    public GameObject cam;

    // R�f�rence pour l'animation 
    Animator anim;


    // Start is called before the first frame update
    void Start()
    {
        // Assigner l'animator pour acc�der � la variable isMoving 
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // Lire la valeur des inputs (entre -1 et 1) 
        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");

        //transform.rotation = Quaternion.Euler(0, cam.transform.rotation.y, 0);
        // Debug.Log(cam.transform.rotation.y);


        if (vertical != 0)
        {
            transform.eulerAngles = new Vector3(0, cam.transform.eulerAngles.y, 0);
            transform.Translate(Vector3.forward * vertical * speed * Time.deltaTime);
        }

        if (horizontal != 0)
        {
            transform.Translate(Vector3.right * horizontal * speed * Time.deltaTime);
        }


        if (vertical!=0 || horizontal!=0)
        {
            anim.SetBool("isMoving", true);
        }
        else
        {
            anim.SetBool("isMoving", false);
        }

       

        // Si on appuie sur espace
        if (Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetBool("isJumping", true);

        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            anim.SetBool("isJumping", false);

        }
    }

    public IEnumerator WaitForSeconde()
    {
        yield return new WaitForSeconds(0);
        anim.SetBool("isTaking", false);
    }



    public void On_clik_button_taking()
    {
        anim.SetBool("isTaking", true);
        StartCoroutine(WaitForSeconde());
    }


    // D�place et tourne le personnage 
    private void ApplyInput(float moveInput, float turnInput)
    {
        Move(moveInput);
        Turn(turnInput);
    }

    // D�place le personnage 
    private void Move(float input)
    {
        Debug.Log("ok");
        // Effectue une translation selon un vecteur3 :  
        //      .forward : vers l'avant du mod�le 
        //      input : entre -1 et 1 
        //      speed : facteur donn� en param�tre modifiable dans l'�diteur 
        //      deltaTime : pour un mouvement par seconde plut�t que par frame  
        transform.Translate(Vector3.forward * input * speed * Time.deltaTime);
        //transform.Translate(new Vector3(cam.transform.rotation.y, 0,0) * input * speed * Time.deltaTime);
    }



    // Tourne le personnage 
    private void Turn(float input)
    {
        // Effectue une rotation en angle Euler sur X, Y, Z, en Y dans ce cas (gauche-droite) 
        //      input : entre -1 et 1 
        //      rotationRate : nb degr�s par seconde 
        //      deltaTime : pour un mouvement par seconde plut�t que par frame 
        transform.Rotate(0, input * rotationRate * Time.deltaTime, 0);
    }
}
