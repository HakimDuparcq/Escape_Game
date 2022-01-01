using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TVscreenController : MonoBehaviour
{
        // Quel chaine sera la chaine sur laquelle l'indice est révélé?
    [SerializeField] [Range(0, 10)] int codeChannel;
    [Space]

        // Les différents objets à utiliser
    [SerializeField] GameObject screen;
    [SerializeField] GameObject textObject;
    [SerializeField] GameObject screenLight;
    [HideInInspector] public int channel = 0;
    bool TVOn = false;
    [Space]
        // Les différents écrans possibles :
        //les écrans de statique quand la chaine n'est pas la meme
        //que l'indice
    [SerializeField] Sprite[] staticSprites;
    int staticIndex = 0;
    Sprite staticSprite;

        //l'écran noir
    [SerializeField] Sprite blackSprite;
        //l'écran d'indice
    [SerializeField] Sprite codeSprite;


    void Start()
    { 
            // initialisation de la télé à un écran noir sans lumière
        screen.GetComponent<Image>().sprite = blackSprite;
        textObject.SetActive(false);
        screenLight.SetActive(false);

    }


        // fonction pour faire "grésiller" l'écran statique
    public IEnumerator staticChange()
    {
        while(true)
        {
            staticSprite = staticSprites[staticIndex];                          //toutes les 0.1 secondes on change l'image de l'écran à la suivante
            staticIndex += 1;                                                   //dans un tableau fixé dans l'éditeur contenant les différents écrans statiques
            if (staticIndex >= staticSprites.Length) { staticIndex = 0; }
            screen.GetComponent<Image>().sprite = staticSprite;
            yield return new WaitForSeconds(0.1f);
        }
    }


        // Fonction présente pour pouvoir activer la coroutine "ChannelAdd" via un boutton
    public void ChannelBrowse()
    {
        StartCoroutine("ChannelAdd");
    }


        // Fonction pour passer à l'écran suivant
    public IEnumerator ChannelAdd()
    {
            // On commence par s'assurer que l'écran est allumé
        if(TVOn)
        {
                // On arrete l'écran de grésillement s'il est actif
            StopCoroutine("staticChange");
                // On éteint l'écran, le texte et la lumière pour un effet de transition de 0.2 secondes
            screen.GetComponent<Image>().sprite = blackSprite;
            textObject.SetActive(false);
            screenLight.SetActive(false);
            yield return new WaitForSeconds(0.2f);
                // On passe à la chaine suivante en sassurant de ne pas dépasser la valeur max de 10 chaines
            channel += 1;
            if (channel > 10) { channel = 0; }

                // si la chaine est celle de l'indice, on affiche l'indice
            if (channel == codeChannel)
            {
                screen.GetComponent<Image>().sprite = codeSprite;
            }
                // sinon on Lance l'écran statique
            else
            {
                StartCoroutine("staticChange");
            }
                // On change le texte d'affichage de chaine, puis on le réactive et on allume la lumière
            textObject.GetComponent<Text>().text = channel.ToString();
            textObject.SetActive(true);
            screenLight.SetActive(true);
        }
    }

        // Fonction pour allumer ou éteindre la télévision
    public void TvToggle()
    {
            // Dans le cas où la télé est allumée
        if(TVOn)
        {
                // On coupe l'écran statique s'il est actif
            StopCoroutine("staticChange");
                // On mets l'écran noir, et éteint le texte et la lumière
            screen.GetComponent<Image>().sprite = blackSprite;
            textObject.SetActive(false);
            screenLight.SetActive(false);
                // On indique que la télé est dans l'état éteint
            TVOn = !TVOn;
        }
            // Dans le cas où la télé est éteinte
        else
        {
                // si la chaine est celle de l'indice, on affiche l'indice
            if (channel == codeChannel)
            {
                screen.GetComponent<Image>().sprite = codeSprite;
            }
                // sinon on Lance l'écran statique
            else
            {
                StartCoroutine("staticChange");
            }
                // On réactive le texte d'affichage de chaine et on allume la lumière
            textObject.SetActive(true);
            screenLight.SetActive(true);
                // On indique que la télé est dans l'état allumé
            TVOn = !TVOn;
        }
    }

    void Update()
    {

    }
}
