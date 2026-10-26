using System.IO;
using System.Xml;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
[System.Serializable]
public class GameData
{
    public int bounces;
}

public class Bounter : MonoBehaviour
{
    private int bounces = 0;
    //private string pathXML;
    //string pathCSV;
    string pathBIN;
    public TMP_Text textoRebs;

    void Start()
    {
        //pathXML = Application.dataPath + "/rebotes.XML";
        //pathCSV = Application.dataPath + "/rebotes.csv";
        pathBIN = Application.dataPath + "/rebotes.dat";
    }

    [HideInInspector] public UnityEvent onBouncedOffGround = new UnityEvent();

    void OnCollisionEnter(Collision collision)
    {
        bounces++;
        onBouncedOffGround.Invoke();
    }
    public int Getbounces() { return bounces; }
    /*
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

    }*/

    /* CSV
    public void GuardCSV()
    {
        StreamWriter writer = new StreamWriter(pathCSV);

        writer.WriteLine(bounces.ToString());
        writer.Flush();
        writer.Close();
        Debug.Log("Saved to " + pathCSV);
    }

    public static List<string[]> Read(string pathCSV)
    {
        var result = new List<string[]>();
        foreach (var line in File.ReadAllLines(pathCSV))
        {
            result.Add(line.Split(','));
        }
        return result;
    }

    public void loadCSV()
    {
        if (File.Exists(pathCSV))
        {
            List<string[]> strings = Read(pathCSV);

            foreach (string[] s in strings)
            {
                foreach (string a in s)
                {
                    if (int.TryParse(a, out int valor))
                    {
                        bounces = valor;
                        textoRebs.text = "" + Getbounces();
                    }
                }
            }
        }
    }*/

    /*Binari*/
    public void GuarBin()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream(pathBIN, FileMode.Create);

        formatter.Serialize(stream, bounces);
        stream.Close();
    }

    public void LoadBin()
    {
        if (File.Exists(pathBIN))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(pathBIN, FileMode.Open);

            bounces = (int)formatter.Deserialize(stream);
            textoRebs.text = "" + Getbounces();
            stream.Close();
        }
        else
        {
            Debug.Log("Nuh uh dawg, at " + pathBIN);
        }
    }
}





