using UnityEngine;

public class PlayerCollision : MonoBehaviour {

    public playermovement movement;     // A reference to our PlayerMovement script

    // This function runs when we hit another obect
    // WE get information about the collision and call it "collisionInfo".
    void OnCollisionEnter (Collision collisionInfo)
    {
        // We check if the object we collided with has a tag called "Obstacle".
        if (collisionInfo.collider.tag == "Obstacle")
        {
            movement.enabled = false;   //Disable the players movement.
            FindObjectOfType<GameManager>().EndGame();
        }

    }
}
