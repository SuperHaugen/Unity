using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class towerPlacement : MonoBehaviour {

	void OnMouseUp(){
		Debug.Log("TowerPacement clicked.");

		BuildingManager bm = GameObject.FindObjectOfType<BuildingManager>();
		if(bm.selectedTower != null){
			ScoreManager sm = GameObject.FindObjectOfType<ScoreManager>();
			if(sm.money < bm.selectedTower.GetComponent<TowerScript>().Cost){
				Debug.Log("Not Enough money!");
				return;
			}

			sm.money -= bm.selectedTower.GetComponent<TowerScript>().Cost;


			Instantiate(bm.selectedTower, transform.position, transform.rotation);
			Destroy(transform.gameObject);
		}
	}



}
