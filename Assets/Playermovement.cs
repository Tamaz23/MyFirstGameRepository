using UnityEngine;

public class Playermovement : MonoBehaviour
{
    public Rigidbody rb;
    
    private bool IsGrounded = true;
    public float forwardForce = 2000f;
    public float sidewaysForce = 500f;
    public float jumpForce = 300f;

     void OnCollisionStay (Collision other)
    {
        if (other.collider.name != "Ground")
        {
            IsGrounded = false;
        }
       
        if (other.collider.name == "Ground")
        {
            IsGrounded = true;
        }
    }
    
    // Update is called once per frame
    void FixedUpdate()
    {
       rb.AddForce(0, 0, forwardForce * Time.deltaTime); 
       
       if ( Input.GetKey("d"))
       {
           rb.AddForce(sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
       }
       
       if ( Input.GetKey("a"))
       {
           rb.AddForce(-sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
       }
       
       if ( Input.GetKey("space") && IsGrounded == true)
       {
           rb.AddForce(0, jumpForce * Time.deltaTime, 0, ForceMode.VelocityChange);
           IsGrounded = false;
       }
       
       if (rb.position.y < -0.5)
       {
           FindObjectOfType<GameManager>().EndGame();
       }
    }
    
}
