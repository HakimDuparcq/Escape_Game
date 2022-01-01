using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraOrbitSimple : MonoBehaviour { 

    // Cube central (C-C) , placé en enfant du joueur à sa position, invisible si possible
    [SerializeField] Transform InnerCube;
    


    // Distance entre la caméra et le point de focus
    public float CameraDist;

    // Vecteurs utilisés pour contenir des variables temporairement
    Vector3 Rotation;
    Vector3 Position;

    // Sensitivité de la caméra aux mouvements de la souris
    [Range(1, 10)] public int sensitivity = 2;


    void Start()
    {

        // On place la caméra derrière le C-C (selon son orientation)
        //note : l'orientation du C-C au début du programme est identique à celle du joueur
        transform.position = InnerCube.position - InnerCube.right * CameraDist;

        // On initialise les vecteurs avec les valeurs de position et rotation (en Euler) de la caméra
        Rotation = transform.rotation.eulerAngles;
        Position = transform.position;
    }


    void Update()
    {
        
        // Si on presse le Clic Droit :
        if (Input.GetMouseButton(1))
        {
            // On mets à jour les composantes du Vecteur Rotation avec
            //les valeurs obtenues par le mouvement de la souris
            Rotation.z += Input.GetAxis("Mouse Y") * sensitivity;
            Rotation.y += Input.GetAxis("Mouse X") * sensitivity;

            // Si la rotation sur l'axe X est hors des bornes souhaitées, 
            //on tronque les valeurs
            Rotation.z = Mathf.Clamp(Rotation.z, -30f, 40f);
            // Ceci évite le dépassement de certaines positions pour la caméra

        }
        // Si le clic droit n'est pas maintenu, le vecteur Rotation reste inchangé


        // La rotation du cube est fixée à celle du vecteur Rotation
        InnerCube.rotation = Quaternion.Euler(0, Rotation.y, Rotation.z);



        // Le vecteur Position est mis à jour avec la position actuelle du C-C
        //avec un offset vers derrière lui (selon sa nouvelle rotation)
        Position = InnerCube.position + Vector3.up - InnerCube.right * CameraDist;
        // On empêche la caméra de passer sous le plan du sol ou trop haut
        Position.y = Mathf.Clamp(Position.y, 0.2f, InnerCube.position.y + 10);

        // On mets à jour la position de la caméra grâce au vecteur Position
        transform.position = Position;
        // On demande à la caméra de regarder vers un point fixé au dessus du cube
        //pour que le joueur reste centré sur l'écran
        transform.LookAt(InnerCube.position + Vector3.up);

    }
}

internal class SerializeFIeldAttribute : Attribute
{
}