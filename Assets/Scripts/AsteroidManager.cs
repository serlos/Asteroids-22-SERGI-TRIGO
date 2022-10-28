using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidManager : MonoBehaviour
{
    public int asteroides_min = 2;
    public int asteroides_max = 8;
    public int asteroides;
    public float limitX = 10;
    public float limitY = 6;
    public GameObject asteroide;
    public bool limpiar = false;
    public bool inicializar = false;
    // Start is called before the first frame update
    void Start()
    {
        
        limpiar = false;
        CrearAsteroides();
        inicializar = true;

    }

    // Update is called once per frame
    void Update()
    {
       

        if (asteroides <= 0 && inicializar) 
        {
            asteroides_min += 2;
            asteroides_max += 2;
            CrearAsteroides();
        }
    }

    void CrearAsteroides()
    {
        int asteroideslocal = Random.Range(asteroides_min, asteroides_max);
        Debug.Log("asteroides local " + asteroideslocal.ToString());

        for (int i = 0; i < asteroideslocal; i++)
        {
            Vector3 posicion = new Vector3(Random.Range(-limitX, limitX), Random.Range(-limitY, limitY));

            while (Vector3.Distance(posicion, new Vector3(0,0)) < 2)
            {
                posicion = new Vector3(Random.Range(-limitX, limitX), Random.Range(-limitY, limitY));
            }

            Vector3 rotacion = new Vector3(0, 0, Random.Range(0f, 360f));
            GameObject temp = Instantiate(asteroide, posicion, Quaternion.Euler(rotacion));
            temp.GetComponent<AsteroideController>().manager = this;
            asteroides += 1;
        }

    }

}
