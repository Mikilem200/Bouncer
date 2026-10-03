using UnityEngine;
using UnityEngine.Events;
using TMPro;
using System.Xml;
using System.IO;
[System.Serializable]
public class GameData
{
    public int bounces;
}

public class Bounter : MonoBehaviour
{
    private int bounces = 0;
    private string pathXML;
    public TMP_Text textoRebs;

    void Start()
    {
        pathXML = Application.dataPath + "/rebotes.XML";
    }

    [HideInInspector] public UnityEvent onBouncedOffGround = new UnityEvent();
    
    void OnCollisionEnter(Collision collision)
    {
        bounces++;
        onBouncedOffGround.Invoke();
    }
    public int Getbounces() { return bounces; }
    public void SavBouncXML()
    {
        //crea XML
        XmlDocument savXML = new XmlDocument();

        
        XmlElement root = savXML.CreateElement("pelota");
        savXML.AppendChild(root);


        
        XmlElement jugador = savXML.CreateElement("jugador");
        jugador.InnerText = Getbounces().ToString();
        root.AppendChild(jugador);

        //guarda XML
        savXML.Save(pathXML);
    }

    public void LoadBouncXML()
    {
        XmlDocument savXML = new XmlDocument();
        savXML.Load(pathXML);


        XmlNodeList numeroRebotes = savXML.GetElementsByTagName("jugador");
        foreach (XmlNode content in savXML)
        {
            if (content.Name == "jugador")
            {
                bounces = int.Parse(content.InnerText);
                textoRebs.text = "Bounces = " + Getbounces();

            }
        }


    }

}



