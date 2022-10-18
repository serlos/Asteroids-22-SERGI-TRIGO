using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed = 10;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(transform.up * speed); //transform.add nos da la direccion en la que el objeto está rotado, el vector gira con la rotacion del objeto actual
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision) //funcion ontrigger nos la da unity y nos dice q cualquier cosa que entre en nuestro trigger nos dira que ha entrado
    {
        if (collision.tag == "Asteroid") //con un = dice que algo contiene algo, si ponemos 2 es para comparar
        {
            collision.GetComponent<AsteroideController>().Muerte();  //pillamos la funcion de ASteroide Controller y asi le decimos que el astoroide se destruye
            Destroy(gameObject);
        
        } 
        

      

    }
} 
