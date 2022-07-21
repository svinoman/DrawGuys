using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpTrigger : MonoBehaviour
{
    [SerializeField] private GameObject drawGuyPrefab;
    private Transform spawnPoint;
    private bool powerUpActivated;
    private float timer = 0f;
    private void Update()
    {
        if(powerUpActivated)
        {
            timer += Time.deltaTime;
            if (timer > 0.1f)
            {
                Destroy(gameObject);
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "amogus")
        {
            powerUpActivated = true;
            gameObject.transform.GetChild(2).transform.gameObject.SetActive(true);
            Instantiate(drawGuyPrefab, spawnPoint);
        }
    }
}
