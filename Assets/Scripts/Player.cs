using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static string  PLAYER_TAG = "";
    // Start is called before the first frame update
    void Start()
    {
        Player.PLAYER_TAG = gameObject.tag;
    }

    // Update is called once per frame
    void Update()
    {

        
    }
}
