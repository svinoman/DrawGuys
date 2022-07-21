using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryTrigger : MonoBehaviour
{
    [SerializeField] private GameObject victorySound;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "amogus")
        {
            other.transform.GetChild(1).GetComponent<Animator>().SetBool("victory", true);
            victorySound.SetActive(true);
        }
    }
}
