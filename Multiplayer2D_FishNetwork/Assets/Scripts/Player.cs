using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Player Stats")]
    [SerializeField]
    float moveForce = 10f;

    [SerializeField]
    float jumpForce = 10f;

    [SerializeField]
    bool isAttack;

    [Header("Player Body")]
    [SerializeField]
    private Rigidbody2D myBody;

    [SerializeField]
    private Transform virtualBody;

    [SerializeField]
    private Animator animator;
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
        animator.SetFloat("yVelocity", myBody.velocity.y);
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
            animator.SetTrigger(TagManager.ATTACK_ANIMATION);
        }
    }

    void AnimatedPlayer()
    {
        Vector3 tempScale = virtualBody.localScale;
        if (movementX > 0)
        {
            animator.SetBool(TagManager.RUN_ANIMATION, true);
            tempScale.x = scaleVal;
        }
        else if (movementX < 0)
        {
            animator.SetBool(TagManager.RUN_ANIMATION, true);
            tempScale.x = -scaleVal;
        }
        else
        {
            animator.SetBool(TagManager.RUN_ANIMATION, false);
        }
        virtualBody.localScale = tempScale;
    }
}
