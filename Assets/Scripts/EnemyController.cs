using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class EnemyController : MonoBehaviour
{
    public enum GhostColour
    {
        red,
        blue,
        pink,
        orange
    }

    public GhostColour ghostColour;
    public GameObject ghostNodeStart;
    public bool locked = true;
    public MovementContoller movementContoller;
    public GameObject pacman;
    public bool shieldOn = false;

    // Start is called before the first frame update
    void Start()
    {
        movementContoller = GetComponent<MovementContoller>();
        if (ghostColour == GhostColour.red)
        {
            locked = false;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void NextNode(NodeController nodeController)
    {
        if (locked == false)
        {
            FollowPlayer();
        }
    }

    void FollowPlayer()
    {
        float shortestDistance = -1;
        string lastMovingDirection = movementContoller.lastMovingDirection;
        string newDirection = "";
        NodeController nodeController = movementContoller.currentNode.GetComponent<NodeController>();

        // if we can move up and we aren't reversing
        if (nodeController.canMoveUp && lastMovingDirection != "down")
        {
            //get the node above us
            GameObject nodeUp = nodeController.nodeUp;
            // get the distance between our top node and pacman
            float distance = Vector2.Distance(nodeUp.transform.position, pacman.transform.position);
            // if this is the shortest distance so far, set our direction
            if (distance < shortestDistance || shortestDistance == -1)
            {
                shortestDistance = distance;
                newDirection = "up";
            }
        }

        // if we can move up and we aren't reversing
        if (nodeController.canMoveDown && lastMovingDirection != "up")
        {
            //get the node above us
            GameObject nodeDown = nodeController.nodeDown;
            // get the distance between our top node and pacman
            float distance = Vector2.Distance(nodeDown.transform.position, pacman.transform.position);
            // if this is the shortest distance so far, set our direction
            if (distance < shortestDistance || shortestDistance == -1)
            {
                shortestDistance = distance;
                newDirection = "down";
            }
        }

        // if we can move up and we aren't reversing
        if (nodeController.canMoveLeft && lastMovingDirection != "right")
        {
            //get the node above us
            GameObject nodeLeft = nodeController.nodeLeft;
            // get the distance between our top node and pacman
            float distance = Vector2.Distance(nodeLeft.transform.position, pacman.transform.position);
            // if this is the shortest distance so far, set our direction
            if (distance < shortestDistance || shortestDistance == -1)
            {
                shortestDistance = distance;
                newDirection = "left";
            }
        }

        // if we can move up and we aren't reversing
        if (nodeController.canMoveRight && lastMovingDirection != "left")
        {
            //get the node above us
            GameObject nodeRight = nodeController.nodeRight;
            // get the distance between our top node and pacman
            float distance = Vector2.Distance(nodeRight.transform.position, pacman.transform.position);
            // if this is the shortest distance so far, set our direction
            if (distance < shortestDistance || shortestDistance == -1)
            {
                shortestDistance = distance;
                newDirection = "right";
            }
        }

        movementContoller.SetDirection(newDirection);
    }

    public void unlock()
    {
        this.transform.position = movementContoller.currentNode.transform.position;
        movementContoller.currentNode = ghostNodeStart;
        locked = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (shieldOn == false)
            {
                Debug.Log("game over!");
                SceneManager.LoadScene("GameOver");
            }
        }
    }

    public void SetShieldOn()
    {
        this.shieldOn = true;
    }

    public void SetShieldOff()
    {
        this.shieldOn = false;
    }
}