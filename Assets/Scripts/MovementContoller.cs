using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementContoller : MonoBehaviour
{
    public GameObject currentNode;
    public float speed = 4f;
    public string direction = "";
    public string lastMovingDirection = "";
    public bool isGhost = false;


    // Start is called before the first frame update
    void Start()
    {
        if (this.gameObject.tag == "Enemy")
        {
            isGhost = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        NodeController currentNodeController = currentNode.GetComponent<NodeController>();
        transform.position = Vector2.MoveTowards(transform.position, currentNode.transform.position, speed * Time.deltaTime);
        // figure out if we're at the center of our current node
        if (transform.position.x == currentNode.transform.position.x && transform.position.y == currentNode.transform.position.y)
        {
            if (isGhost)
            {
                GetComponent<EnemyController>().NextNode(currentNodeController);
            }
            // get the next node from our node controller using our current direction
            GameObject newNode = currentNodeController.GetNodeFromDirection(direction);
            // if we can move to the desired direction
            if (newNode != null)
            {
                currentNode = newNode;
                lastMovingDirection = direction;
            }
            // we cant move in desired location, try to keep going in the last moving direction
            else
            {
                direction = lastMovingDirection;
                newNode = currentNodeController.GetNodeFromDirection(direction);
                if (newNode != null)
                {
                    currentNode = newNode;
                }
            }
        }
    }

    public void SetDirection(string newDirection)
    {
        direction = newDirection;
    }
}