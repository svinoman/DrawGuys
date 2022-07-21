using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "amogus")
        {
            other.transform.GetChild(1).GetComponent<Animator>().SetBool("death", true);
        }
    }
}
