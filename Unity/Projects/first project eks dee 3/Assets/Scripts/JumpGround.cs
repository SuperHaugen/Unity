using UnityEngine;

public class JumpGround : MonoBehaviour
{
    public playermovement movement;
    public void OnTriggerStay(Collider other)
    {

        if (other.gameObject.tag == "JumpGround")
        {
            movement.jumpallow = true;
            Debug.Log("Jumpallow = true");
        }
    }

    public void OnTriggerExit(Collider collision)
    {
        if(collision.gameObject.tag == "JumpGround")
        {
            movement.jumpallow = false;
        }
    }

}