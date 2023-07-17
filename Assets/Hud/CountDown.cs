using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CountDown : MonoBehaviour
{
    public TextMeshProUGUI textMeshPro;
    public Image image;
    private Coroutine countdownTwoCoroutine;
    private Coroutine countdownOneCoroutine;
    private bool colorChanged = false;
    public float countdownTime = 15f;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha2) && countdownTwoCoroutine == null && countdownOneCoroutine == null && !colorChanged)
        {
            StartCountdownTwo();
        }

        if (Input.GetKeyDown(KeyCode.Alpha1) && countdownTwoCoroutine != null && countdownOneCoroutine == null)
        {
            StopCountdownTwo();
            ChangeColor();
            countdownOneCoroutine = StartCoroutine(CountdownOneCoroutine());
        }
    }

    private void StartCountdownTwo()
    {
        countdownTwoCoroutine = StartCoroutine(CountdownTwoCoroutine());
    }

    private IEnumerator CountdownTwoCoroutine()
    {
         countdownTime = 15f;

        while (countdownTime > 0)
        {
            countdownTime -= Time.deltaTime;
            textMeshPro.text = countdownTime.ToString("F0");
            yield return null;
        }

        ChangeColor();
        yield return new WaitForSeconds(5f);
        ChangeColorBack();

        countdownTwoCoroutine = null;
    }

    private IEnumerator CountdownOneCoroutine()
    { 
        countdownTime = 0f;
        yield return new WaitForSeconds(5f);
        

        ChangeColorBack();
        countdownOneCoroutine = null;
    }

    private void StopCountdownTwo()
    {
        if (countdownTwoCoroutine != null)
        {
            StopCoroutine(countdownTwoCoroutine);
        }

        ChangeColorBack();
        countdownTwoCoroutine = null;
    }

    private void ChangeColor()
    {
        image.color = Color.red;
        colorChanged = true;
    }

    private void ChangeColorBack()
    {
        image.color = Color.white;
        colorChanged = false;
    }
}