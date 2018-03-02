using System.Collections;
using UnityEngine;

public class EnemyScript : MonoBehaviour {

    GameObject pathGo;
    ScoreManager sm = new ScoreManager();
    Transform targetPathNode;
    int pathNodeIndex = 0;

    float speed = 15f;
    
    public float health = 1;

    public int moneyValue = 1;

    public Vector3 Offset;

	void Start ()
    {
        pathGo = GameObject.Find("Path");
	}

    void GetNextPathNode()
    {
        {
            if(pathNodeIndex < pathGo.transform.childCount){
            targetPathNode = pathGo.transform.GetChild(pathNodeIndex);
            pathNodeIndex++;
            }
            else{
                ReachedGoal();
            }
        }
    }
	void Update ()
    {
        if (targetPathNode == null)
        {
            GetNextPathNode();
            if (targetPathNode == null)
            {
                ReachedGoal();
                return;
            }
            
        }

        Vector3 dir = targetPathNode.position - this.transform.localPosition;

        float distThisFrame = speed * Time.deltaTime;

        if(dir.magnitude <= distThisFrame)
        {
            targetPathNode = null;
        }
        else
        {
            transform.Translate(dir.normalized * distThisFrame, Space.World);
            Quaternion targetRotation = Quaternion.LookRotation(dir);
            this.transform.rotation = Quaternion.Lerp(this.transform.rotation, targetRotation, Time.deltaTime * 3);
        }
	}

    void ReachedGoal()
    {
        Destroy(gameObject);
        GameObject.FindObjectOfType<ScoreManager>().LoseLife();
    }

    public void TakeDamage(float Damage)
    {
        health -= Damage;
        if (health <= 0)
        {
            die();
        }
    }

    public void die()
    {
        GameObject.FindObjectOfType<ScoreManager>().money += moneyValue;
        Destroy(gameObject);
    }
}