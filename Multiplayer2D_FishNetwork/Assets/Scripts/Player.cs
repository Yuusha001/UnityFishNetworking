using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float moveForce = 10f,
        jumpForce = 10f;

    [SerializeField]
    private Rigidbody2D mybody;

    [SerializeField]
    private Animator animator;
    private string RUN_ANIMATION = "Run";
    private string ATTACK_ANIMATION = "Attack";
    private string GROUND_TAG = "Ground";
    private bool isGrounded;
    private float movementX,
        scaleVal;

    private void Awake()
    {
        scaleVal = transform.localScale.x;
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("yVelocity", mybody.velocity.y);
    }

    private void FixedUpdate()
    {
        PlayerMoveKeyboard();
        PlayerAttack();
        AnimatedPlayer();
    }

    void PlayerMoveKeyboard()
    {
        movementX = Input.GetAxisRaw("Horizontal");
        transform.position += new Vector3(movementX, 0f, 0f) * moveForce * Time.fixedDeltaTime;
    }

    void PlayerAttack()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            animator.SetTrigger(ATTACK_ANIMATION);
        }
    }

    void AnimatedPlayer()
    {
        Vector3 tempScale = transform.localScale;
        if (movementX > 0)
        {
            animator.SetBool(RUN_ANIMATION, true);
            tempScale.x = scaleVal;
        }
        else if (movementX < 0)
        {
            animator.SetBool(RUN_ANIMATION, true);
            tempScale.x = -scaleVal;
        }
        else
        {
            animator.SetBool(RUN_ANIMATION, false);
        }
        transform.localScale = tempScale;
    }
}
