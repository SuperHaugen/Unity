using UnityEngine;

public class TowerScript : MonoBehaviour {

    Transform turrettransform;
    public Vector3 Offset;
    public float Damage = 1f;
    private float range = 10f;

    private float fireCooldown = 0.5f;
    private float firecooldownleft = 0f;


	// Use this for initialization
	void Start () {
        turrettransform = transform.Find("turret");

	}
	
	// Update is called once per frame
	void Update () {
        EnemyScript[] enemies = GameObject.FindObjectsOfType<EnemyScript>();

        EnemyScript nearestEnemy = null;
        float dist = Mathf.Infinity;

        foreach(EnemyScript e in enemies)
        {
            float d = Vector3.Distance(this.transform.position, e.transform.position);
            if(nearestEnemy == null || d < dist)
            {
                nearestEnemy = e;
                dist = d;
            }
        }

        if(nearestEnemy == null)
        {
            Debug.Log("No enemies");
            return;
        }

        Vector3 dir = nearestEnemy.transform.position - transform.position;

        Quaternion lookRot = Quaternion.LookRotation( dir );

        turrettransform.rotation = Quaternion.Euler( 0 + Offset.x, lookRot.eulerAngles.y + 180 + Offset.y, 0 + Offset.z );
	}
    firecooldownleft -= Time.deltatime;
    if(firecooldownleft -= <= 0 && CapsuleDirection2D.magnitude <= range)
    {
        firecooldownleft = fireCooldown;
        shootAt(nearestEnemy);
    }


    void shootAt(EnemyScript e)
    {
        GameObject BulletGO = (GameObject) Instantiate(bulletprefab, this.transform.position, this.transform.rotation);

        BulletGO b = BulletGO.GetComponent<bullet>()
        b.target = e.transform;
    }

}
