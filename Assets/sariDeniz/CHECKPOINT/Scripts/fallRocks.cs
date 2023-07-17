using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fallRocks : MonoBehaviour
{

    [SerializeField] GameObject birincikaya;
    [SerializeField] float dusmeKuvveti = 500f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Rigidbody rb = birincikaya.GetComponent<Rigidbody>();
            rb.isKinematic = false;
            rb.AddForce(Vector3.down * dusmeKuvveti);
        }
    }

}