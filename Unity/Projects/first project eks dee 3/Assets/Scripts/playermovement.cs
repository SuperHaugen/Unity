using UnityEngine;
using UnityEngine.SceneManagement;

public class playermovement : MonoBehaviour
{
    //This is a reference to the Rigidbod component called "rb"
    public Rigidbody rb;

    public float Forwardforce = 8000f;
    public float Sidewaysforce = 170f;
    public float upwardsforce = 100f;
    public bool jumpallow;



    // we maked this as "FixedUpdate becouse we
    // are using it to mess with physics.
    void FixedUpdate()
    {

        //add a forward force
        rb.AddForce(0, 0, Forwardforce * Time.deltaTime);

        if (Input.GetKey("d"))
        {
            //only executed if condition is met
            rb.AddForce(Sidewaysforce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);

        }

        if (Input.GetKey("a"))
        {
            //only executed if condition is met
            rb.AddForce(-Sidewaysforce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);

        }



        if (Input.GetKey("r"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        if (rb.position.y < -1f)
        {
            FindObjectOfType<GameManager>().EndGame();
        }

        if (jumpallow == true)
        {
            if (Input.GetKey("space"))
            {
                rb.AddForce(0, upwardsforce * Time.deltaTime, 0, ForceMode.VelocityChange);
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "jumppad")
        {
            jumpallow = true;
            rb.AddForce(0, upwardsforce * Time.deltaTime, 0, ForceMode.VelocityChange);
        }
        else
        {
            jumpallow = false;
        }

    }

}    


