using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;
using Unity.VisualScripting;

using System.IO;
using JetBrains.Annotations;

public class Bounter : MonoBehaviour
{
    public int bounces = 0;
    public string path;

    void Start()
    {
        path = Application.persistentDataPath + "SavedBalls/";
    }

    [HideInInspector] public UnityEvent onBouncedOffGround = new UnityEvent();
    public int Getbounces() { return bounces; }
    private void OnCollisionEnter(Collision collision)
    {
        bounces++;
        onBouncedOffGround.Invoke();
    }

    public void Save()
    {
    GameData gameData = new GameData();
    gameData.bounces = Getbounces();
        string json = JsonUtility.ToJson(gameData, true);

        File.WriteAllText(path, json);

    }
    /*
    public void Carga()
    {
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);

            GameData datos = JsonUtility.FromJson<GameData>(json);

            
        }
    }*/


    
}
[System.Serializable]
public class GameData
{
    public int bounces;
}


