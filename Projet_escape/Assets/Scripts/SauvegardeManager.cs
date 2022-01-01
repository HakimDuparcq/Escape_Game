using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


public class SauvegardeManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject objet1;
    public GameObject objet2;



    // Update is called once per frame
    void Update()
    {
        //sauvegarde dans le txt
        if (Input.GetKeyDown(KeyCode.S))
        {
            Save(objet1, objet2);
        }

        //charger les données
        if (Input.GetKeyDown(KeyCode.C))
        {
            Load(objet1, objet2);
        }
    }

    void Save(GameObject obj1, GameObject obj2)
    {
        Vector3 position1 = obj1.transform.position;
        Vector3 position2 = obj2.transform.position;
        string saveSeparator = "%VALUE%";

        string[] content = new string[]
        {
            position1.ToString(),
            position2.ToString()
        };
        string saveString = string.Join(saveSeparator, content);
        File.WriteAllText(Application.dataPath + "/data.txt", saveString);
        Debug.Log("Sauvegarde effectuée");
    }

    void Load(GameObject obj1, GameObject obj2 )
    {
        string saveSeparator = "%VALUE%";
        string position =File.ReadAllText(Application.dataPath + "/data.txt");

        string[] Array = position.Split(new[] { saveSeparator },System.StringSplitOptions.None);

        obj1.transform.position = StringToVector3(Array[0]);
        obj2.transform.position = StringToVector3(Array[1]);
        Debug.Log("Chargement effectuée");
    }






    public static Vector3 StringToVector3(string sVector)
    {
        // Remove the parentheses
        if (sVector.StartsWith("(") && sVector.EndsWith(")"))
        {
            sVector = sVector.Substring(1, sVector.Length - 2);
        }
        // split the items
        string[] sArray = sVector.Split(',');
        string sArray0 = sArray[0].Replace('.', ',');
        string sArray1 = sArray[1].Replace('.', ',');
        string sArray2 = sArray[2].Replace('.', ',');
        Vector3 result = new Vector3(float.Parse(sArray0), float.Parse(sArray1), float.Parse(sArray2));

        return  result;
    }
}
