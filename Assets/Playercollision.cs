using UnityEngine;

public class Playercollision : MonoBehaviour
{
    
public Playermovement movement;
    
public Rigidbody rb;
    
    void OnCollisionEnter (Collision collisionInfo)
    {
    
        if (collisionInfo.collider.tag == "Obstacle")
        {
            movement.enabled = false;
            FindObjectOfType<GameManager>().EndGame();
        }
    
        
    }   
}