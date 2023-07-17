using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movementScripts : MonoBehaviour
{
    public moveStyle moveStyle;

    public CharacterController controller;

    Vector3 velocity;
    public float gravity = -9.81f;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask Ground;
    bool groundede;
    public float jumpHeight = 4f;
    public Vector3 moveDirection;
    [SerializeField] public float speed, levitationSpeed, birdSpeed;
    private bool canChange = true;
    private bool canBird = true;









    void Update()

    {
        

        if (Input.GetKey(KeyCode.Alpha1) && canChange == false)
        {
            
            moveStyle = moveStyle.human;
            StartCoroutine(change());
            
        }

        if (Input.GetKey(KeyCode.Alpha2) && canChange == true)
        {
                if (Input.GetKey(KeyCode.Alpha1)) 
                { 
                canChange = false;
                Debug.Log("canChange=false");
            
            
                }    
                moveStyle = moveStyle.bird;
                StartCoroutine(timer());
                StartCoroutine(canBirdTime());

                
            

        }





        if (canBird == false) 
        {
            moveStyle = moveStyle.human;
            StartCoroutine(change());
            StartCoroutine(BirdTime());

        }


        if (moveStyle == moveStyle.bird)
        {
            birdFly();
        }
        else if (moveStyle == moveStyle.human)
        {
            humanWalk();
        }

    }

    IEnumerator timer()
    {
        yield return new WaitForSeconds(15);

        canChange = false;
        //Kuþ olma limiti

    }

    IEnumerator change()
    {

        yield return new WaitForSeconds(5);
        canChange = true;
        Debug.Log("saydým");
        // kuþa yeniden dönüþme zamaný
    }

    IEnumerator canBirdTime()
    {
        yield return new WaitForSeconds(15);
        canBird = false;

        // kuþa dönüþtükten sonra yeniden olmak
    
    }

    IEnumerator BirdTime()
    {
        yield return new WaitForSeconds(5);
        canBird = true;
        // bunu false yapmak için
    }
    void birdFly() 

{

        Move();

        Fly();




    }

void humanWalk()

    {

        
        groundede = Physics.CheckSphere(groundCheck.position, groundDistance, Ground);

        if (groundede && velocity.y < 0)
        {

            velocity.y = -2f;
        }
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);

        if (Input.GetKey(KeyCode.LeftShift))
        {

            controller.Move(move * speed * 2 * Time.deltaTime);
        }
        if (Input.GetButtonDown("Jump") && groundede)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * speed * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);




    }

    private void Fly()
    {
        
        moveDirection = Vector3.up * levitationSpeed * Time.deltaTime;

        if (Input.GetKey(KeyCode.Space))
            controller.Move(moveDirection);
        else if (Input.GetKey(KeyCode.LeftShift))
            controller.Move(-moveDirection);
    }

    private void Move()
    {
        
        float horizontalInput = Input.GetAxis("Horizontal") * birdSpeed * Time.deltaTime;
        float verticalInput = Input.GetAxis("Vertical") * birdSpeed * Time.deltaTime;
        Vector3 move = transform.forward * verticalInput + transform.right * horizontalInput;
        controller.Move(move);
    }

}


public enum moveStyle 
    {
        bird,
        human 
    }



