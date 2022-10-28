using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed = 10;
    public float duracionBala = 1.0f;
    public bool soyAleatorio = false;   
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(transform.up * speed);
    }

    // Update is called once per frame
    void Update()
    {
        duracionBala -= Time.deltaTime;
        if (duracionBala <= 0.0f) 
        {
            if (!soyAleatorio) 
            {
                GameManager.instance.listaBalas.Remove(this.gameObject);
            }
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Asteroid") 
        {
            collision.gameObject.GetComponent<AsteroideController>().Muerte();
            GameManager.instance.listaBalas.Remove(this.gameObject);
            Destroy(gameObject);
            GameManager.instance.municion += 2;
        
        }
    }

   




} 
