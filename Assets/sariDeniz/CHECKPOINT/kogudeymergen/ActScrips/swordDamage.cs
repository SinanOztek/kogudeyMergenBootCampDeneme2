using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class swordDamage : MonoBehaviour
{
    public int Damage = 100;
    
    
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<animcontroller>().TakeDamage(Damage);
            other.gameObject.GetComponent<animcontroller>().healthChange(100);
        }
    }
}
