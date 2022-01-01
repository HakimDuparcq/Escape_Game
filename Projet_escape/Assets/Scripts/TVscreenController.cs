using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TVscreenController : MonoBehaviour
{
        // Quel chaine sera la chaine sur laquelle l'indice est r�v�l�?
    [SerializeField] [Range(0, 10)] int codeChannel;
    [Space]

        // Les diff�rents objets � utiliser
    [SerializeField] GameObject screen;
    [SerializeField] GameObject textObject;
    [SerializeField] GameObject screenLight;
    [HideInInspector] public int channel = 0;
    bool TVOn = false;
    [Space]
        // Les diff�rents �crans possibles :
        //les �crans de statique quand la chaine n'est pas la meme
        //que l'indice
    [SerializeField] Sprite[] staticSprites;
    int staticIndex = 0;
    Sprite staticSprite;

        //l'�cran noir
    [SerializeField] Sprite blackSprite;
        //l'�cran d'indice
    [SerializeField] Sprite codeSprite;


    void Start()
    { 
            // initialisation de la t�l� � un �cran noir sans lumi�re
        screen.GetComponent<Image>().sprite = blackSprite;
        textObject.SetActive(false);
        screenLight.SetActive(false);

    }


        // fonction pour faire "gr�siller" l'�cran statique
    public IEnumerator staticChange()
    {
        while(true)
        {
            staticSprite = staticSprites[staticIndex];                          //toutes les 0.1 secondes on change l'image de l'�cran � la suivante
            staticIndex += 1;                                                   //dans un tableau fix� dans l'�diteur contenant les diff�rents �crans statiques
            if (staticIndex >= staticSprites.Length) { staticIndex = 0; }
            screen.GetComponent<Image>().sprite = staticSprite;
            yield return new WaitForSeconds(0.1f);
        }
    }


        // Fonction pr�sente pour pouvoir activer la coroutine "ChannelAdd" via un boutton
    public void ChannelBrowse()
    {
        StartCoroutine("ChannelAdd");
    }


        // Fonction pour passer � l'�cran suivant
    public IEnumerator ChannelAdd()
    {
            // On commence par s'assurer que l'�cran est allum�
        if(TVOn)
        {
                // On arrete l'�cran de gr�sillement s'il est actif
            StopCoroutine("staticChange");
                // On �teint l'�cran, le texte et la lumi�re pour un effet de transition de 0.2 secondes
            screen.GetComponent<Image>().sprite = blackSprite;
            textObject.SetActive(false);
            screenLight.SetActive(false);
            yield return new WaitForSeconds(0.2f);
                // On passe � la chaine suivante en sassurant de ne pas d�passer la valeur max de 10 chaines
            channel += 1;
            if (channel > 10) { channel = 0; }

                // si la chaine est celle de l'indice, on affiche l'indice
            if (channel == codeChannel)
            {
                screen.GetComponent<Image>().sprite = codeSprite;
            }
                // sinon on Lance l'�cran statique
            else
            {
                StartCoroutine("staticChange");
            }
                // On change le texte d'affichage de chaine, puis on le r�active et on allume la lumi�re
            textObject.GetComponent<Text>().text = channel.ToString();
            textObject.SetActive(true);
            screenLight.SetActive(true);
        }
    }

        // Fonction pour allumer ou �teindre la t�l�vision
    public void TvToggle()
    {
            // Dans le cas o� la t�l� est allum�e
        if(TVOn)
        {
                // On coupe l'�cran statique s'il est actif
            StopCoroutine("staticChange");
                // On mets l'�cran noir, et �teint le texte et la lumi�re
            screen.GetComponent<Image>().sprite = blackSprite;
            textObject.SetActive(false);
            screenLight.SetActive(false);
                // On indique que la t�l� est dans l'�tat �teint
            TVOn = !TVOn;
        }
            // Dans le cas o� la t�l� est �teinte
        else
        {
                // si la chaine est celle de l'indice, on affiche l'indice
            if (channel == codeChannel)
            {
                screen.GetComponent<Image>().sprite = codeSprite;
            }
                // sinon on Lance l'�cran statique
            else
            {
                StartCoroutine("staticChange");
            }
                // On r�active le texte d'affichage de chaine et on allume la lumi�re
            textObject.SetActive(true);
            screenLight.SetActive(true);
                // On indique que la t�l� est dans l'�tat allum�
            TVOn = !TVOn;
        }
    }

    void Update()
    {

    }
}
