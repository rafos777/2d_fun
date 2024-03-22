using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rebondir : MonoBehaviour
{
    public float vitesseY = -0.01f;
    public float vitesseX = 0.2f;
    public float acceleration = -0.01f;
    public float elasticite = 0.99f ;

    bool descendre = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var pos = transform.position;
        var  rayon = transform.localScale.x/2;
        var x = pos.x;
        var y = pos.y;

        Debug.Log($"y: {y}, vitesse: {vitesseY}");
        
        y = y + vitesseY;

        vitesseY = vitesseY + acceleration;
        x = x + vitesseX-0.001f;

        if( y-rayon < 0 )
        {
            Debug.Log("Boing");
            vitesseY = -vitesseY * elasticite;
            y = -y+ 2*rayon ;
        }

        /*
        if (descendre )
        {
            if (y > rayon)
            {
                y = y-vitesse;
                vitesse = vitesse + 0.01f;
            }
            else { descendre = false; }
        }
        else
        {
            if (vitesse >= 0)
            {
                y = y + vitesse;
                vitesse = vitesse - 0.01f;
            }
            else { descendre = true ; }
        }
        */



        pos.x = x; pos.y = y;
        transform.position = pos;
    }
}
