using System;
using UnityEngine;

public class TowerScript : MonoBehaviour
{
    public float range = 1000f;
    public float fireCooldown = 1.5f;
    private float firecooldownleft = 0f;
    private Transform turrettransform;
    [Serializable]
    class Debugs
    {
        public bool printCooldown = false;
        public bool printShoot = false;
    }

    public Vector3 Offset;
    public float Damage = 1f;
    public GameObject Bullet_Emitter;
    public GameObject bulletPrefab;

    public int Cost = 5;
    [SerializeField]
    Debugs debugs = new Debugs();

    // Use this for initialization
    void Start()
    {
        turrettransform = transform.Find("turret");

    }

    // Update is called once per frame
    void Update()
    {
        EnemyScript[] enemies = GameObject.FindObjectsOfType<EnemyScript>();

        EnemyScript nearestEnemy = null;
        float dist = Mathf.Infinity;

        foreach (EnemyScript e in enemies)
        {
            float d = Vector3.Distance(this.transform.position, e.transform.position);
            if (nearestEnemy == null || d < dist)
            {
                nearestEnemy = e;
                dist = d;
            }
        }

        if (nearestEnemy == null)
        {
            Debug.Log("No enemies");
            return;
        }

        Vector3 dir = nearestEnemy.transform.position - transform.position;

        Quaternion lookRot = Quaternion.LookRotation(dir);

        turrettransform.rotation = Quaternion.Euler(0 + Offset.x, lookRot.eulerAngles.y + 180 + Offset.y, 0 + Offset.z);

        firecooldownleft -= Time.deltaTime;
        if (firecooldownleft <= 0 && dir.magnitude <= range)
        {
            firecooldownleft = fireCooldown;
            ShootAt(nearestEnemy);
        }

        if(debugs.printCooldown)
            Debug.Log("Fire cooldown: " + firecooldownleft);
    }

    void ShootAt(EnemyScript e)
    {
        if(debugs.printShoot)
            Debug.Log("Shooting");
        GameObject BulletGO = Instantiate(bulletPrefab, Bullet_Emitter.transform.position,Bullet_Emitter.transform.rotation) as GameObject;

        bullet_script b = BulletGO.GetComponent<bullet_script>();
        b.Target = e.transform;
    }
}



