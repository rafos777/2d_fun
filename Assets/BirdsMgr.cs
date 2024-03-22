using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdsMgr : MonoBehaviour
{
    public GameObject Template;
    
    public List<GameObject> Birds = new List<GameObject>();
    public int BirdsNbr = 2;

    // Start is called before the first frame update

    void Start()
    {
        int seed = DateTime.Now.Millisecond;
        System.Random rnd = new System.Random(seed);

        for (int i = 0; i < BirdsNbr; i++)
        {
            Debug.Log("haha");

            

            var go = GameObject.Instantiate(Template);
            Birds.Add(go);

            var script = go.GetComponent<Bird>();
            script.birdsMgr = this;
            float rdmX = (float) rnd.Next(-100, 100) ;
            script.Rdmx  = rdmX;

            float rdmY = (float)rnd.Next(-100, 100);
            script.Rdmy = rdmY;

            float rdmvitX = rnd.Next(-100, 100) / 200.0f;
            script.vitesseX = rdmvitX;

            float rdmvitY = rnd.Next(-100,100) / 200.0f;
            script.vitesseY = rdmvitY;

            float[] colorN = new float[3];
            for (int g = 0; g < 3; g++)
            {
                float rdmcol = rnd.Next(0, 100) / 100.0f;
                colorN[g] = rdmcol;
            }


            var material = go.GetComponent<SpriteRenderer>().material;
            material.color = new Color(colorN[0], colorN[1], colorN[2]);

            go.SetActive(true);
        }

    }
}
