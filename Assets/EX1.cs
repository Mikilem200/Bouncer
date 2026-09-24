using System.IO;
using Unity.VisualScripting;
using UnityEngine;

public class EX1 : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        CreaCarpeta();
        CreateSave();

    }

    //Crear

    //Define ruta del archivo
    public string GetSaveFolder()
    {
        return Application.persistentDataPath + "SavedBalls/";
    }

    //Define Nombre Archivo
    public string GetSaveFile()
    {
        return GetSaveFolder() + "SaveBall.json";
    }

    private void CreaCarpeta()
    {
        if (!Directory.Exists(GetSaveFolder()))
        {
            Directory.CreateDirectory(GetSaveFolder());
        }
    }

    private void CreateSave()
    {
        string path = GetSaveFile();
        using (FileStream filestream = new FileStream(path, FileMode.Create))
        {
            using (StreamWriter writer = new StreamWriter(filestream))
            {
                writer.WriteLine("Archivo de Guardado 1, featuring Dante from the Devil May Cry series");
            }
        }
    }

}