using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawGuysMovement : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 0.5f;
    [SerializeField] private bool gameStarted = false;
    private bool victory = false;
    private void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            gameStarted = true;
        }
        if(gameStarted)
        {
            for (int i = 0; i < GameObject.FindGameObjectsWithTag("amogus").Length; i++)
            {
                if(GameObject.FindGameObjectsWithTag("amogus")[i].transform.GetChild(1).GetComponent<Animator>().GetBool("death") == false)
                {
                    if(GameObject.FindGameObjectsWithTag("amogus")[i].transform.GetChild(1).GetComponent<Animator>().GetBool("victory") == false)
                    {
                        GameObject.FindGameObjectsWithTag("amogus")[i].transform.position += new Vector3(0, 0, Time.deltaTime * movementSpeed);
                        GameObject.FindGameObjectsWithTag("amogus")[i].transform.GetChild(1).GetComponent<Animator>().SetBool("isRunning", true);
                    }
                    else
                    {
                        victory = true;
                    }
                }
            }
            if (victory == false)
            {
                Camera.main.transform.position += new Vector3(0, 0, Time.deltaTime * movementSpeed);
            }
        }
    }
}
