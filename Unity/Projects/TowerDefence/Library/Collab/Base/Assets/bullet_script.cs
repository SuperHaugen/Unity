using UnityEngine;

public class bullet_script : MonoBehaviour
{

    public float Speed = 15f;
    public Transform Target;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	    Vector3 dir = Target.position - this.transform.localPosition;

	    float distThisFrame = speed * Time.deltaTime;

	    if (dir.magnitude <= distThisFrame)
	    {
	        DoBullethit();
	    }
	    else
	    {
	        transform.Translate(dir.normalized * distThisFrame, Space.World);
	        Quaternion targetRotation = Quaternion.LookRotation(dir);
	        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * 3);
	    }
    }

    void BulletHit()
    {
        gameObject.GetComponent<EnemyScript>().Takedamage(damage);
        Destroy(gameObject);
    }
}E
