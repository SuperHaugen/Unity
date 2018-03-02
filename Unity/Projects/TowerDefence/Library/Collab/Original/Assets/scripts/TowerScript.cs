using UnityEngine;

public class TowerScript : MonoBehaviour {

    Transform turrettransform;

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

        Vector3 dir = nearestEnemy.transform.position - this.transform.position;

        Quaternion lookRot = Quaternion.LookRotation( dir );

        turrettransform.rotation = Quaternion.Euler( 0, lookRot.eulerAngles.y + 180, 0 );
	}

}
