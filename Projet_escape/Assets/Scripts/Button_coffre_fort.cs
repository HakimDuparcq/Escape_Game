using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Button_coffre_fort : MonoBehaviour
{


    // Start is called before the first frame update
    [SerializeField] GameObject canvas;
    [SerializeField] GameObject canvas_papier;
    public GameObject boncode;
    public GameObject mauvaiscode;
    public TextMeshProUGUI Code;
    public AudioSource sound_good_answer;
    public AudioSource sound_wrong_answer;
    [SerializeField] private GameObject coffre;
    public GameObject key;
    public string secretcode;
   

    private string code;
    int jouer_une_foix = 0;
    void Start()
    {
        //coffre.transform.rotation = Quaternion.Euler(0, 0, 0);
        canvas.SetActive(false);
        boncode.SetActive(false);
        mauvaiscode.SetActive(false);
        coffre.SetActive(true);
        Transform porte = transform.Find("Bank-2");
        key.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (code.Length == 4 && code != secretcode && code != "nice")
        {
            
            sound_wrong_answer.Play();

            code = "";
            StartCoroutine(MauvaisCodeEntrer());
        }

        if (code == secretcode)
        {
            
            sound_good_answer.Play();
            code = "nice";
            coffre.transform.rotation = Quaternion.Euler(0, -110, 0);
            Debug.Log(coffre.transform.position);
            key.SetActive(true);
            StartCoroutine(BonCodeEntrer());
            

        }

        Code.text = code;
    }


    IEnumerator BonCodeEntrer()
    {
        boncode.SetActive(true);
        yield return new WaitForSeconds(2);
        canvas.SetActive(false);
    }

    IEnumerator MauvaisCodeEntrer()
    {
        mauvaiscode.SetActive(true);
        yield return new WaitForSeconds(2);
        mauvaiscode.SetActive(false);
    }

    public void OnClickButton_CoffreFort(int chiffre)
    {
        if (code != "nice")
        {
            code = code + chiffre;
            Debug.Log(code);
        }
    }



    public void OnClikButtonClose()
    {
        canvas.SetActive(false);
        canvas_papier.SetActive(false);
    }
}
