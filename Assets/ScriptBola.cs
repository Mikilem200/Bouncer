using UnityEngine;
using System.IO;
using TMPro;
using System.Xml;
[System.Serializable]
public class DatosRebotes
{
    public int Rebotes;
}

public class ScriptBola : MonoBehaviour
{
    private int rebotes = 0;
    private string rutaArchivoJson;
    private string rutaArchivoXML;
    public TMP_Text textoRebotes;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rutaArchivoJson = Application.dataPath + "/rebotes.json";
        rutaArchivoXML = Application.dataPath + "/rebotes.XML";

    }

    // Update is called once per frame
    void Update()
    {
        
        
    }

    void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("superficie"))
        {
            rebotes++;
            textoRebotes.text = "Rebotes = " + rebotes;
        }
    }

    public void GuardarRebotesJson()
    {
        DatosRebotes datos = new DatosRebotes();

        datos.Rebotes = rebotes;
        string json = JsonUtility.ToJson(datos);

        File.WriteAllText(rutaArchivoJson, json);
        Debug.Log("Guardado");
    }

    public void CargarJson()
    {
        string json = File.ReadAllText(rutaArchivoJson);
        DatosRebotes datos = JsonUtility.FromJson<DatosRebotes>(json);
        rebotes = datos.Rebotes;
        textoRebotes.text = "Rebotes = " + rebotes;

    }


    // Metodo guardar en XML
    public void GuardarRebotesXML()
    {
        // Crear documento
        XmlDocument guardarXML = new XmlDocument();

        // Crear primer elemento y ponerlo como hijo de root
        XmlElement root = guardarXML.CreateElement("pelota");
        guardarXML.AppendChild(root);


        // Crear rebotes y añadir como append

        XmlElement jugador = guardarXML.CreateElement("jugador");
        jugador.InnerText = rebotes.ToString();
        root.AppendChild(jugador);

        // Guardar
        guardarXML.Save(rutaArchivoXML);
    }

    // Metodo cargar en XML

    public void CargarRebotesXML()
    {
        XmlDocument guardarXML = new XmlDocument();
        guardarXML.Load(rutaArchivoXML);



        XmlNodeList numeroRebotes = guardarXML.GetElementsByTagName("jugador");
        foreach (XmlNode content in guardarXML)
        {
            if (content.Name == "jugador")
            {
                rebotes = int.Parse(content.InnerText);
                textoRebotes.text = "Rebotes = " + rebotes;

            }
        }


    }
}
