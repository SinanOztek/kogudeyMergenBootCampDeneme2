using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class killPlayer : MonoBehaviour
{
    public GameObject Canvas;
    public bool isDead = false;

     void Update() 
        { 
            if (Input.GetKeyDown(KeyCode.Escape) &&  isDead == true)
            {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            
            Time.timeScale = 1.0f;
            isDead = false;
            
            Debug.Log("esc");
            }  
        
        }
        private void OnTriggerEnter(Collider collision)
        {
        if (collision.gameObject.CompareTag("rocks"))
        {

            openCanvas();
            
            isDead = true;
            
  

        }

        

        }
        public void openCanvas()
        {
            
            
            Canvas.SetActive(true);
            Debug.Log("deydi");
            Time.timeScale = 0;

            
        }   
}

    


    

