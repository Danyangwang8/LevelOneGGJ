using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    // Start is called before the first frame update
    public float moveSpeed = 0.1f;
    private GameObject character;


    private float moveHorizontal;
    private float moveVertical;
    private Vector2 moveTo;
    private Vector2 characterPos;

    private Rigidbody2D rb2D;


    void Start()
    {
        character = GameObject.FindGameObjectWithTag("Player");
        rb2D = character.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        CharacterMoveController();
        rb2D.MovePosition(rb2D.position + moveTo * moveSpeed);
        if(moveHorizontal == 0f & moveVertical == 0f)
         { 
         gameObject.GetComponent<Animator>().SetBool("Walking", false);
          } else
           { gameObject.GetComponent<Animator>().SetBool("Walking", true); }
    }
    void CharacterMoveController()
    {
        moveHorizontal = Input.GetAxis("Horizontal");
        moveVertical = Input.GetAxis("Vertical");

        Vector2 forwardDirection = character.transform.TransformDirection(Vector2.up);
        Vector2 moveForward = moveVertical * forwardDirection * Time.deltaTime;
        Vector2 rightDirection = character.transform.TransformDirection(Vector2.right);
        Vector2 moveRight = moveHorizontal * rightDirection * Time.deltaTime;

        moveTo = moveForward + moveRight;

    }
    void CharacterPickUpController()
    {
        
    }
    void AnimaitonController()
    {
        
    }
}
