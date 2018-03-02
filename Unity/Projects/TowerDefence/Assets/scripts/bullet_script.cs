using System;
using UnityEngine;

public class bullet_script : MonoBehaviour
{
    [Serializable]
    class Debugs
    {
        public bool bulletHit = false;
        public bool printCreated = false;
    }

    public float Speed = 15f;
    public Transform Target;
    public float Damage;
    [SerializeField]
    Debugs debugs = new Debugs();

    // Use this for initialization
    void Start()
    {
        if(debugs.printCreated)
            Debug.Log("Bullet created");
    }

    // Update is called once per frame
    void Update()
    {
        if (Target == null)
        {
            Debug.Log("Bullet no target");
            Destroy(gameObject);
            return;
        }

        Vector3 dir = Target.position - this.transform.localPosition;

        float distThisFrame = Speed * Time.deltaTime;

        if (dir.magnitude <= distThisFrame)
        {
            // BulletHit();
        }
        else
        {
            transform.Translate(dir.normalized * distThisFrame, Space.World);
            Quaternion targetRotation = Quaternion.LookRotation(dir);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * 5);
        }
    }

    void BulletHit(Collider targetGameObject)
    {
        try
        {
            targetGameObject.GetComponent<EnemyScript>().TakeDamage(Damage);
            if(debugs.bulletHit)
                Debug.Log("Bullet hit");
            Destroy(this.gameObject);
        }
        catch
        {
            if(debugs.bulletHit)
                Debug.Log("Enemy is gone");
            Destroy(this.gameObject);
        }
    }

    void OnTriggerStay(Collider collider)
    {
        Debug.Log(collider.name);
        if(collider.tag == "Enemy")
            BulletHit(collider);
    }
}
