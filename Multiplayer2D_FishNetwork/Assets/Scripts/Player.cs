using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : PlayerController
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
        this.tag = TagManager.Team2;
    }

    // Update is called once per frame
    void Update()
    {
        if (!base.IsOwner)
            return;
        animator.SetFloat(TagManager.yVelocity_ANIMATION, myBody.velocity.y);
    }

    private void FixedUpdate()
    {
        if (!base.IsOwner)
            return;
        PlayerMoveKeyboard();
        PlayerAttack();
        AnimatedPlayer();
    }

    void PlayerMoveKeyboard()
    {
        if (!base.IsOwner)
            return;
        movementX = Input.GetAxisRaw("Horizontal");
        transform.position += new Vector3(movementX, 0f, 0f) * moveForce * Time.fixedDeltaTime;
    }

    void PlayerAttack()
    {
        if (!base.IsOwner)
            return;
        if (Input.GetKey(KeyCode.Space))
        {
            networkAnimator.SetTrigger(TagManager.ATTACK_ANIMATION);
        }
    }

    void AnimatedPlayer()
    {
        if (!base.IsOwner)
            return;
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
