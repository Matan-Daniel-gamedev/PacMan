using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostUnlock : MonoBehaviour
{

    public GameObject ghost;
    public bool enabled = true;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (enabled == true)
            {
                enabled = false;
                ghost.GetComponent<EnemyController>().unlock();
            }
        }
    }
}
