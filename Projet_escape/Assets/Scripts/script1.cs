using UnityEngine;
using UnityEngine.SceneManagement;

public class script1 : MonoBehaviour
{

    [SerializeField] private GameObject controle;
    [SerializeField] private GameObject sound;
    [SerializeField] private GameObject credit;
    [SerializeField] private GameObject close;
    [SerializeField] private GameObject panneau;


    public int paneau_num = 0;
    // Start is called before the first frame update
    void Start()
    {
        controle.SetActive(true);
        sound.SetActive(true);
        credit.SetActive(true);
        close.SetActive(true);
        panneau.SetActive(true);
        panneau.GetComponent<RectTransform>().localPosition = new Vector3(1, 23, 0);
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(paneau_num);
        if (paneau_num == 0)
        {
            controle.SetActive(false);
            sound.SetActive(false);
            credit.SetActive(false);
            close.SetActive(false);
            panneau.SetActive(false);
        }
        else{
            controle.SetActive(true);
            sound.SetActive(true);
            credit.SetActive(true);
            close.SetActive(true);
            panneau.SetActive(true);
        }
    }

    public void OnClickPlay()
    {
        SceneManager.LoadScene("Game");
    }


    public void OnClickSettings()
    {
        paneau_num = 1;
    }

    public void OnClickControle()
    {
        paneau_num = 1;
    }

    public void OnClickSound()
    {
        paneau_num = 2;
    }


    public void OnClickCredit()
    {
        paneau_num = 3;
    }

    public void OnClickCroix()
    {
        paneau_num = 0;
    }

}
