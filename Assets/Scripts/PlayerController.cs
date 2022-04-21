using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float horizontalInput = 0f;
    public float speed = 5f;
    public PlayerMovement movement;
    public bool isAlive = true;
    public GameManager manager;
    public Animator anim;
    public AudioSource audioS;
    public AudioClip coinSound;
    public AudioClip hurtSound;
    public AudioClip jumpSound;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   //Player movement
        horizontalInput = Input.GetAxisRaw("Horizontal"); //Para que el jugador se mueva a izq y der con teclas
        


        //Player Jump
        if (Input.GetButtonDown("Jump") && isAlive == true)  //condición de si aprietas el espacio que salte
        {
            if (movement.m_Grounded)
            {
                anim.SetTrigger("Jump");
                audioS.PlayOneShot(jumpSound, 1f);//Reproduce 1 sonido una vez
            }
            movement.Jump(); //Movimiento de salto con espacio
        }

        //Set animations
        anim.SetBool("Grounded", movement.m_Grounded);
        anim.SetBool("IsAlive", isAlive);

        if(horizontalInput == 0)
        {
            anim.speed = 1f;
            anim.SetBool("Move", false);
        }
        else  {
            if(isAlive && movement.m_Grounded)
            {
               anim.speed = 1 * Mathf.Abs(horizontalInput);
            }
            anim.SetBool("Move", true);
        }
    }

    private void FixedUpdate() //Se autogestiona con las físicas de los juegos
    {
        if (isAlive == true) {
            movement.Move(horizontalInput * speed * Time.deltaTime);
        }
    }
    //gestionar colisiones en 2d de tipo trigger
    private void OnTriggerEnter2D(Collider2D collision)//Imprime que cuando el jugador agarre algo que tenga el código desde
    //if hasta el debug entra ahí y comprueba si el otro objeto es cherry y si lo tiene manda el debug
    {
        if (collision.gameObject.tag == "Cherry")
        {
            Debug.Log("Cherry Picked!");
            Destroy(collision.gameObject); //Destruye el gameobject que se le indica
            manager.totalCoins++; //++ significa incrementar en un total
            audioS.PlayOneShot(coinSound, 1f);//Reproduce 1 sonido una vez
            
        }

            if (collision.gameObject.tag == "CheckPoint") {

            manager.spawnPoint = collision.gameObject.transform;
        }

        if(collision.gameObject.tag == "LevelEnd")  {
           manager.FinishLevel();
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Spikes" || collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "PoisonedCherry") // EN C# || es o
        {
            Die();
        }

        if(collision.gameObject.tag == "WeakPoint") {
            collision.transform.parent.GetComponent<BoxCollider2D>().enabled = false;
           Destroy(collision.transform.parent.gameObject);

            }
    }

    public void Die(){
        isAlive = false;
        anim.SetTrigger("Die");
        audioS.PlayOneShot(hurtSound, 1f);//Reproduce 1 sonido una vez
    }
 
}
