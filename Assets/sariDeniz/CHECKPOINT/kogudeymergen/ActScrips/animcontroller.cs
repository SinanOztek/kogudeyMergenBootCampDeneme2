
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public class animcontroller : MonoBehaviour
{


    Animator animator;
    float horizontal;
    float vertical;
    public bool isDead = false;
    public GameObject Canvas;

    public Image _bar;

    public int health = 100;


    void Start()
    {

        animator = GetComponentInChildren<Animator>();

    }

    public void healthChange(int damage) 
    {
        health -= damage;
        float amount = (health / 100.0f) * 180.0f / 360;
        _bar.fillAmount = amount;
    
    }
        

    public void TakeDamage(int damage)
    {

 

        health -= damage;
        animator.SetTrigger("isHit");
        Debug.Log("kögüdeye vurdu");
        if (health <= 0)
        {
            Debug.Log("öldü");
            Die();
        }

    }



    

    private void Die()
    {

        animator.SetTrigger("dead");
        isDead = true;
        Canvas.SetActive(true);


    }
    

    void Update()
    {

        

        if (Input.GetKey(KeyCode.A)) 
        {
            horizontal = Input.GetAxis("Horizontal");
            animator.SetFloat("MoveX" , horizontal);
        }
        else if (Input.GetKeyUp(KeyCode.A))
        {
            horizontal = Input.GetAxis("Horizontal");
            animator.SetFloat("MoveX", 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            horizontal = Input.GetAxis("Horizontal");
            animator.SetFloat("MoveX", -horizontal);
        }
        else if (Input.GetKeyUp(KeyCode.D))
        {
            horizontal = Input.GetAxis("Horizontal");
            animator.SetFloat("MoveX", 0);
        }
        if (Input.GetKey(KeyCode.W) )
        {
            vertical = Input.GetAxis("Vertical");
            animator.SetFloat("MoveZ", vertical );
        }

        else if (Input.GetKeyUp(KeyCode.W))
        {
            vertical = Input.GetAxis("Vertical");
            animator.SetFloat("MoveZ", 0);
        }

        if (Input.GetKey(KeyCode.S))
        {
            vertical = Input.GetAxis("Vertical");
            animator.SetFloat("MoveZ", (vertical) );
        }
        else if (Input.GetKeyUp(KeyCode.S))
        {
            vertical = Input.GetAxis("Vertical");
            animator.SetFloat("MoveZ", 0);
        }

        if (Input.GetKey(KeyCode.LeftShift)) 
        
        {
            animator.SetFloat("MoveZ", 1.46f);
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))

        {
            animator.SetFloat("MoveZ", 0);
        }



        if (Input.GetKey(KeyCode.Space))
        {
            animator.SetBool("isJump", true);
        }

        if (!Input.GetKey(KeyCode.Space)) 
        {
            animator.SetBool("isJump", false);
        }
        if (Input.GetMouseButtonDown(1)) 
        {
            animator.SetBool("heavyAtacked", true);
        }
        if (!Input.GetMouseButtonDown(1))
        {
            animator.SetBool("heavyAtacked", false);
        }
        if (Input.GetMouseButtonDown(0))
        {
            animator.SetBool("lightAtacked", true);
        }
        if (!Input.GetMouseButtonDown(0))
        {
            animator.SetBool("lightAtacked", false);
        }
        if (Input.GetKey(KeyCode.X))
        {
            animator.SetBool("sitting", true);
        }
        if (!Input.GetKey(KeyCode.X))
        {
            animator.SetBool("sitting", false);
        }
    }
}
