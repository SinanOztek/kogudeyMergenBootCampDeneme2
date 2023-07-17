using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool nextScene = false;
    
    
    [Header("Enemies")]
    [SerializeField] private List<enemymovement> enemyList = new List<enemymovement>();

    private void Start()
    {
        enemymovement[] enemyArray = FindObjectsOfType<enemymovement>();
        enemyList.AddRange(enemyArray);
    }

    public void RemoveEnemy(enemymovement enemy)
    {
        enemyList.Remove(enemy);

        if (enemyList.Count == 1)
        {
            change();
            if (nextScene == true) 
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

            }

            
            
            
        }
    }





    IEnumerator change()
    {

        yield return new WaitForSeconds(5);
        nextScene = true;
       
    }


}


