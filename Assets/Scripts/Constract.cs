using System.Diagnostics.Contracts;
using UnityEngine;

[CreateAssetMenu(fileName = "Constract", menuName = "Scriptable Object/Constract", order = 1)]
public class Constract : ScriptableObject
{
    public float speedUpTimeInterval;
    public float scrollIncreaseSpeed;
    public float initSpeed;
    public float maxScrollSpeed;

     void Reset()
    {
        speedUpTimeInterval = 2f;
        scrollIncreaseSpeed = 1.05f;
        initSpeed = 3f;
        maxScrollSpeed = 5f;
    }
   
}

