using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D RigidBody;
    Animator anim;
    CircleCollider2D collider;
    SpriteRenderer sprite;
    public float speed = 5;
    public float RotationSpeed = 10;
    public GameObject bala;
    public GameObject Boquilla;
    public float tiempoBalaAleatoria = 1.0f;
    private float tiempoReal;
    public GameObject particulasmuerte;
    public UIManager GameOver;
    public bool controlparticulas;

    

    void Start()
    {
        RigidBody = GetComponent<Rigidbody2D>();     
        anim = GetComponent<Animator>();
        tiempoReal = tiempoBalaAleatoria;
        collider = GetComponent<CircleCollider2D>();    
        sprite = GetComponent<SpriteRenderer>();
    }

   
    
    void Update()

    {
        tiempoReal -= Time.deltaTime;
        if(tiempoReal <= 0.0f && (gameObject.activeSelf && sprite.enabled)) 
        { 
            DisparoAleatorio();
            tiempoReal = tiempoBalaAleatoria;


        }

        float vertical = Input.GetAxis("Vertical");
        if(vertical > 0)
        {
            RigidBody.AddForce(transform.up * vertical * speed * Time.deltaTime);
            anim.SetBool("Impulsing", true);
        }
        else
        {
            anim.SetBool("Impulsing", false);
        }

        float horizontal = Input.GetAxis("Horizontal");
        transform.eulerAngles += new Vector3(0, 0, horizontal * RotationSpeed * Time.deltaTime);
       
        if (Input.GetButtonDown("Jump") && (gameObject.activeSelf && sprite.enabled)) 
        {
            
            if(GameManager.instance.municion > 0) 
            {
                GameObject temp = Instantiate(bala, Boquilla.transform.position, transform.rotation);
                GameManager.instance.municion -= 1;
                GameManager.instance.listaBalas.Add(temp);
            }

        }
        if (!GameManager.instance.ComprobarBalasMoviendose() && GameManager.instance.municion <= 0)
        {
            Muerte();

        }
    }
    public void DisparoAleatorio() 
    {
        Vector3 rotacion = new Vector3(0, 0, Random.Range(0f, 360f));
        GameObject temp = Instantiate(bala, Boquilla.transform.position, Quaternion.Euler(rotacion));
        temp.GetComponent<BulletController>().soyAleatorio = true;

    }

    public void Muerte()
    {
       

        if (GameManager.instance.vida == 0 && controlparticulas)
        {
            GameObject temp = Instantiate(particulasmuerte, transform.position, transform.rotation);
            Destroy(temp, 2.5f);
            gameObject.SetActive(false);
            controlparticulas=false;


        }
        else if (GameManager.instance.vida > 0)
        {
            GameObject temp = Instantiate(particulasmuerte, transform.position, transform.rotation);
            Destroy(temp, 2.5f);
            StartCoroutine(Respawn_Coroutine());

        }
        else
        {
            
        
        }
           


    }
    public void restart() 
    {
        transform.position = new Vector3(0, 0, 0);
        RigidBody.velocity = new Vector2(0, 0);
        gameObject.SetActive(true);


    }

    IEnumerator Respawn_Coroutine()
    {
        collider.enabled = false;
        sprite.enabled = false;
        GameManager.instance.vida -= 1;
        GameManager.instance.municion = 15;
        yield return new WaitForSeconds(2);
        collider.enabled = true;
        sprite.enabled = true;


        
        transform.position = new Vector3(0, 0, 0);
        RigidBody.velocity = new Vector2(0, 0);

        if (GameManager.instance.vida <= 0)
        {
            gameObject.SetActive(false);


        }

    }

}


