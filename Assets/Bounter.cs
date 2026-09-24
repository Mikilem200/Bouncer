using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;
using Unity.VisualScripting;

public class Bounter : MonoBehaviour
{
    public int bounces = 0;

    [HideInInspector] public UnityEvent onBouncedOffGround = new UnityEvent();
    public int Getbounces() { return bounces; }
    private void OnCollisionEnter(Collision collision)
    {
        bounces++;
        onBouncedOffGround.Invoke();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
[System.Serializable]
public class GameData
{
    public int bounces;
}