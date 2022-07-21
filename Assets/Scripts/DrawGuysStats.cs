using UnityEngine;

public class DrawGuysStats : MonoBehaviour
{
    private float deathTimer = 0;
    private void Update()
    {
        if(gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Death"))
        {
            gameObject.transform.parent.GetChild(0).GetComponent<SkinnedMeshRenderer>().enabled = false;
            gameObject.transform.parent.GetChild(2).gameObject.SetActive(true);
            deathTimer += Time.deltaTime;
            if (deathTimer > 2)
                Destroy(gameObject.transform.parent.gameObject);
        }
    }
}
