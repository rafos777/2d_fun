using System;
using System.Collections; 
using System.Collections.Generic;
using UnityEngine;

public class FireworksManager : MonoBehaviour
{
    public GameObject Template;
    public int Number = 10;
    public int intervalleDevitesseMin = 0;
    public int intervalleDevitesseMax = 0;


    private List<GameObject> list = new List<GameObject>();
    //changer la couleur material.color = new Color(0.5f, 0.5f, 0.5f);

    // Start is called before the first frame update
    void Start()
    {

        int seed = DateTime.Now.Millisecond;
        System.Random rnd = new System.Random(seed);

        for (int i=0; i<Number; i++)
        {
            var go = GameObject.Instantiate(Template);
            list.Add(go);

            var script = go.GetComponent<Rebondir>();
            
            float rdmvitX = rnd.Next(0,500) / 1000.0f - 0.25f;
            script.vitesseX = rdmvitX;

            float rdmvitY = rnd.Next(intervalleDevitesseMin, intervalleDevitesseMax) / 100.0f;
            script.vitesseY = rdmvitY;

            float[] colorN = new float[3];
            for (int g = 0; g < 3; g++)
            {
                float rdmcol = rnd.Next(0, 100) / 100.0f;
                colorN[g] = rdmcol;
            }


            var material = go.GetComponent<SpriteRenderer>().material;
            material.color = new Color( colorN [0],colorN [1] , colorN [2]);
        }
        
    }

    // Update is called once per frame
    void Update()
    {

    }
}
