using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroll : MonoBehaviour
{
    public float speed = 2f;
   

    // Update is called once per frame
    void Update()
    {
        transform.Translate( speed * Time.deltaTime *  Vector2.up);     
    }
}
