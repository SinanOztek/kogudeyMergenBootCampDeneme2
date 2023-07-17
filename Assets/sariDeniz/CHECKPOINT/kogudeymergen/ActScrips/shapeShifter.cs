using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shapeShifter : MonoBehaviour
{
    [SerializeField] GameObject _mainChar;
    [SerializeField] GameObject _bird;
    [SerializeField] GameObject _human;
    [SerializeField] GameObject _bear;
    [SerializeField] GameObject _wildPig;
    public Vector3 tempPosition;
    private bool canChange = true;
    private bool birdTimer = true;
    


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && canChange == false )
        {
            tempPosition = _mainChar.transform.position;
            _mainChar.transform.position = _bird.transform.position;
            _bird.transform.position = tempPosition;
            
            _mainChar.SetActive(true);
            _bird.SetActive(false);
            _human.SetActive(true);
            StartCoroutine(changeToHuman());
            StartCoroutine(birdtime());
            
            
            
            



        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && canChange == true  )
        {
            tempPosition = _bird.transform.position;
            _bird.transform.position = _mainChar.transform.position;
            _mainChar.transform.position = tempPosition;
            
            _mainChar.SetActive(true);
            _bird.SetActive(true);
            _human.SetActive(false);
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                canChange = false;

            }
            
            
            StartCoroutine(timer());
            StartCoroutine(Canbirdtime());
            

        }

        if (birdTimer == false) 
        {
            tempPosition = _mainChar.transform.position;
            _mainChar.transform.position = _bird.transform.position;
            _bird.transform.position = tempPosition;

            _mainChar.SetActive(true);
            _bird.SetActive(false);
            _human.SetActive(true);
            StartCoroutine(changeToHuman());
            StartCoroutine(Canbirdtime());

        }

        
    }
    IEnumerator timer()
    {
        yield return new WaitForSeconds(15);
        
        canChange = false;

    }
    IEnumerator changeToHuman()
    {
        
        yield return new WaitForSeconds(15);
        canChange = true;
    }

    IEnumerator birdtime()
    {

        yield return new WaitForSeconds(15);
        birdTimer = true;
    }

    IEnumerator Canbirdtime()
    {

        yield return new WaitForSeconds(15);
        birdTimer = false;
    }


}
