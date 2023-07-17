using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneTrigger : MonoBehaviour
{
    public GameObject stone; // Hareket ettirilecek taş objesi
    public float moveSpeed = 2f; // Taşın hareket hızı
    public float moveDistance = 1f; // Taşın hareket edeceği maksimum mesafe

    private Vector3 startPosition; // Taşın başlangıç pozisyonu
    private bool isActivated = false; // Tetikleyicinin etkinleştirildiğini kontrol etmek için bayrak

    private void Start()
    {
        startPosition = stone.transform.position; // Taşın başlangıç pozisyonunu kaydet
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isActivated = true; // Tetikleyici etkinleştirildi
        }
    }

    private void Update()
    {
        if (isActivated)
        {
            float newYPosition = startPosition.y + Mathf.PingPong(Time.time * moveSpeed, moveDistance);
            stone.transform.position = new Vector3(stone.transform.position.x, newYPosition, stone.transform.position.z);
        }
    }
}
