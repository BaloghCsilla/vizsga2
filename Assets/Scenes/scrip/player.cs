using System.Collections;

using UnityEngine;

public class player : MonoBehaviour
{

         float horizontal;
         float speed = 8f;
         float jumpingPower = 16f;
         bool isFacingRight = true;

        bool canDash = true;
        bool isDashing;
        float dashingPower = 24f;
        float dashingTime = 0.2f;
        float dashingCooldown = 1f;

        [SerializeField] Rigidbody2D rb;
        [SerializeField] Transform groundCheck;
        [SerializeField] LayerMask groundLayer;
        [SerializeField] TrailRenderer tr;

        void Update()
        {
            if (isDashing)
            {
                return;
            }

            horizontal = Input.GetAxisRaw("Horizontal");

            if (Input.GetButtonDown("Jump") && IsGrounded())
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
            }

            if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
            {
                rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
            }

            if (Input.GetKeyDown(KeyCode.LeftShift) && canDash)
            {
                StartCoroutine(Dash());
            }

            Flip();
        }

         void FixedUpdate()
        {
            if (isDashing)
            {
                return;
            }

            rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
        }

        bool IsGrounded()
        {
            return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
        }

        void Flip()
        {
            if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
            {
                isFacingRight = !isFacingRight;
                Vector3 localScale = transform.localScale;
                localScale.x *= -1f;
                transform.localScale = localScale;
            }
        }

        IEnumerator Dash()
        {
            canDash = false;
            isDashing = true;
            float originalGravity = rb.gravityScale;
            rb.gravityScale = 0f;
            rb.velocity = new Vector2(transform.localScale.x * dashingPower, 0f);
            tr.emitting = true;
            yield return new WaitForSeconds(dashingTime);
            rb.gravityScale = originalGravity;
            isDashing = false;
            yield return new WaitForSeconds(dashingCooldown);
            canDash = true;

        }

}

