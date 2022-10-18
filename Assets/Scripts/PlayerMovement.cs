using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D RigidBody;
    Animator anim;
    public float speed = 5;
    public float RotationSpeed = 10;
    public GameObject bala;
    public GameObject Boquilla;

    void Start()
    {
        RigidBody = GetComponent<Rigidbody2D>();     /*el getcomponent busca el componente que hemos añadido en unity busca componente y lo iguala para poder trabajar con el*/
        anim = GetComponent<Animator>();
    }

   
    
    void Update()
    {
        float vertical = Input.GetAxis("Vertical");
        if(vertical > 0)
        {
            /*reconoce el movimiento por la formula del movimiento que es mi posicion * la velocidad * por cuadrar los frames para todos los PCs*/
            /*el transform.up mira la posicion de donde apunta en este caso el eje vertical se sigue manteniendo la formalua del movimiento y el transform.up es Vector3*/
            RigidBody.AddForce(transform.up * vertical * speed * Time.deltaTime);
            anim.SetBool("Impulsing", true);
        }
        else
        {
            anim.SetBool("Impulsing", false);
        }

        float horizontal = Input.GetAxis("Horizontal");
        transform.eulerAngles += new Vector3(0, 0, horizontal * RotationSpeed * Time.deltaTime);
       
        if (Input.GetButtonDown("Jump")) //estamos instanciamos la bala para que darle al espacio dispare, ponemos Jump prq es el standard del espacio el getbutton sale la bala todo el rato si no dejamos de pulsar por eso utilizamos el DOWN porq asi solo sale UNA bala cuando le damos al espacio
        {
            GameObject temp = Instantiate(bala, Boquilla.transform.position, transform.rotation); //le pasamos la posicion de la nave guardamos la instantiate en la variable temp para poder hacer cositas con ella, en el momento que se instancia la bala se guarda en la variable temporal y podemos modificar cosas de la bala.
            Destroy(temp, 1f);
         
        }
    }

        public void Muerte()
    {
        //Destroy(gameObject);
    }

   
    }

