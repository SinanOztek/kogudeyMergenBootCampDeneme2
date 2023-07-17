using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerSwordDamage : MonoBehaviour
{
    public int Damage = 100;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "enemy")
        {
            other.gameObject.GetComponent<enemymovement>().TakeDamage(Damage);
            other.gameObject.GetComponent<animcontroller>().healthChange(100);
        }

    }
}
