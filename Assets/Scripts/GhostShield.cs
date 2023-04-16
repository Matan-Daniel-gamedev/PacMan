using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostShield : MonoBehaviour
{
    [SerializeField] float duration = 15;
    bool enabled = true;

    GameObject[] ghost;

    // Start is called before the first frame update
    void Start()
    {
        ghost = GameObject.FindGameObjectsWithTag("Enemy");
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (enabled == true)
            {
                Debug.Log("Shield triggered by player");
                enabled = false;
                for (int i = 0; i < ghost.Length; i++)
                {
                    var enemyController = ghost[i].GetComponent<EnemyController>();
                    if (enemyController)
                    {
                        enemyController.StartCoroutine(ShieldTemporarily(enemyController));
                    }
                }
            }
        }
    }

    private IEnumerator ShieldTemporarily(EnemyController enemyController)
    {
        //co-routines
        enemyController.SetShieldOn();
        for (float i = duration; i > 0; i--)
        {
            Debug.Log("Shield: " + i + " seconds remaining!");
            yield return new WaitForSeconds(1);       // co-routines
        }
        Debug.Log("Shield gone!");
        enemyController.SetShieldOff();
    }
}