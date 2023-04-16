using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField] GameObject nodes;
    MovementContoller movementContoller;
    SpriteRenderer sprite;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        sprite = GetComponentInChildren<SpriteRenderer>();
        movementContoller = GetComponent<MovementContoller>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            movementContoller.SetDirection("left");
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            movementContoller.SetDirection("right");
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            movementContoller.SetDirection("up");
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            movementContoller.SetDirection("down");
        }

        // changing the pacman animation by the direction
        bool flipX = false;
        bool flipY = false;
        if (movementContoller.lastMovingDirection == "left")
        {
            animator.SetInteger("direction", 0);
        }
        if (movementContoller.lastMovingDirection == "right")
        {
            flipX = true;
            animator.SetInteger("direction", 0);
        }
        if (movementContoller.lastMovingDirection == "up")
        {
            animator.SetInteger("direction", 1);
        }
        if (movementContoller.lastMovingDirection == "down")
        {
            flipY = true;
            animator.SetInteger("direction", 1);
        }

        sprite.flipY = flipY;
        sprite.flipX = flipX;

        // CHECK FOR GAME ENDING
        checkGameEnding();
    }

    private void checkGameEnding()
    {
        bool finished = true;
        // get all nodes
        Transform pelletNodesObj = nodes.transform.Find("PelletNodes");
        for (int i = 0; i < pelletNodesObj.childCount; i++)
        {
            GameObject node = pelletNodesObj.GetChild(i).gameObject;
            NodeController nodeController = node.GetComponent<NodeController>();
            if (nodeController.eaten == false)
            {
                finished = false;
            }
        }

        Transform spcialNodesObj = nodes.transform.Find("SpecialNodes");
        for (int i = 0; i < spcialNodesObj.childCount; i++)
        {
            GameObject node = spcialNodesObj.GetChild(i).gameObject;
            NodeController nodeController = node.GetComponent<NodeController>();
            if (nodeController.eaten == false)
            {
                finished = false;
            }
        }

        if (finished == true)
        {
            Debug.Log("You won!");
            SceneManager.LoadScene("YouWon");
        }
    }
}