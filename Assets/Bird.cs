using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    public float vitesseY = 0;
    public float vitesseX = 0;
    public float radius = 10;
    
    public int nbrOiseauxAutour = 6;

    public float Rdmx = 0;
    public float Rdmy = 0;
    float x = 0, y = 0;
    public BirdsMgr birdsMgr = null;
    // Start is called before the first frame update

    void Start()
    {
        var pos = transform.position;
        var x = Rdmx;
        var y = Rdmy;
        pos.x = x; pos.y = y;
        transform.position = pos;
    }

    // Update is called once per frame
    void Update()
    {
        var pos = transform.position;
        var rayon = transform.localScale.x / 2;
        var x = pos.x;
        var y = pos.y;

        // chercher notre propre index

        /*
        int myIndex = -1;

        for (int indexOis = 0; indexOis < birdsMgr.BirdsNbr; indexOis++)
        {
            if (birdsMgr.Birds[indexOis] == this)
            {
                myIndex = indexOis;
            }
        }

        if (myIndex == -1) return;
        */

        Vector3 moyenneVector = new Vector3(0.0f, 0.0f, 0.0f);
        int nbOiseauxAutour = 0;

        // iterons sur tous les oiseaux qui ne sont pas nous
        for (int indexOis = 0; indexOis < birdsMgr.BirdsNbr; indexOis++)
        {
            var bird = birdsMgr.Birds[indexOis];

            if (bird == this) continue;

            float totalX = 0.0f;
            float totalY = 0.0f;

            // trouvons la distance entre nous et cet oiseau

            Vector3 myPos = transform.localPosition;
            Vector3 otherPos = bird.transform.localPosition;

            Vector3 vec = otherPos - myPos;

            float distance = vec.magnitude;


            float influence = 0;
            // si cet oiseau est dans le rayon
            influence = (1f / (distance+0.001f))*5f;
            // ajouter à la moyenne
            moyenneVector = moyenneVector + vec*influence;
            nbOiseauxAutour++;
         


            /*
            float moyenneX = 0.0f;
            float moyenneY = 0.0f;

            //for (int index2 = 0;index2 < nbrOiseauxAutour; index2++)
            {
                Debug.Log("index2");

                // si le bird autour n'est pas dans la liste car il est trop grand
                if (indexOis+ myIndex > birdsMgr.BirdsNbr)
                {
                    int indexNew = indexOis + myIndex - birdsMgr.BirdsNbr;
                    moyenneX = (moyenneX * indexNew + x) / (myIndex + 1);
                    moyenneY = (moyenneY * indexNew + y) / (myIndex + 1);
                }
                else
                {
                    moyenneX = (moyenneX * myIndex + x) / (myIndex + 1);
                    moyenneY = (moyenneY * myIndex + y) / (myIndex + 1);
                }

            }
            vitesseY = vitesseY + (moyenneY - x) / 4;
            vitesseX = vitesseX + (moyenneX - x) / 4;

            */
        }

        Vector3 finalVector = moyenneVector / nbOiseauxAutour;
        /*
        Vector3 vectorToZero = -transform.localPosition / 500.0f;
        
        finalVector += vectorToZero;*/

        vitesseX += finalVector.x / 1000.0f;
        vitesseY += finalVector.y / 1000.0f;

        

        x = x + vitesseX;
        y = y + vitesseY;

        pos.x = x; pos.y = y;
        transform.position = pos;
    }
}