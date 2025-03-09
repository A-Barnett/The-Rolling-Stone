using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float torque,force, jumpforce,jumpDelay, slopeJump, maxSpeed, acceleration;
    private Rigidbody2D rb; // Reference to the player's Rigidbody2D component
    private float jumpTimer;
    private bool onSlope, onGround;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Get the player's Rigidbody2D component

    }

    private void Jump()
    {
        jumpTimer = jumpDelay;
        if (!onSlope)
        {
            rb.AddForce(new Vector2(0f, jumpforce), ForceMode2D.Impulse);
        }
        else
        {
            rb.AddForce(new Vector2(0f, jumpforce * slopeJump), ForceMode2D.Impulse);
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            onGround = true;
            onSlope = false;
        }
        else if (collision.gameObject.CompareTag("Slope"))
        {
            onGround = true;
            onSlope = true;
        }

    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Slope"))
        {
            onGround = false;
            onSlope = false;
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            onGround = true;
            onSlope = false;
        }
        else if (collision.gameObject.CompareTag("Slope"))
        {
            onGround = true;
            onSlope = true;
        }
   
    }
    private void FixedUpdate()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float jump = Input.GetAxis("Jump");
        rb.angularDrag = 5f;
        if (moveX != 0){
            rb.velocity = new Vector2(moveX*force, rb.velocity.y);
        }
        else
        {
            rb.drag = 3f;
        }

        if (rb.velocity.magnitude > 0.1)
        {
            float torqueMultiplier = Mathf.Sign(rb.velocity.x) * torque * rb.velocity.magnitude;
            rb.angularVelocity = (-torqueMultiplier);
                 
        }
      
        if (jumpTimer > 0)
        {
            jumpTimer -= Time.deltaTime;
        }

        if (jumpTimer <= 0 && jump > 0 && onGround)
        {
            Jump();
            jumpTimer = jumpDelay;
        }
    }
}