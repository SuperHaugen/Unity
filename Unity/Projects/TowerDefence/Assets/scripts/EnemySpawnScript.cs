using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnScript : MonoBehaviour {

	public float spawnCoolDown = 250f;
	public float spawnCoolDownRemaining = 50;
	
	[System.Serializable]
	public class WaveComponent {
		public GameObject enemyPrefab;
		public int num;
		[System.NonSerialized]
		public int spawned = 0;
	}

	public WaveComponent[] wavecomps;

	
	// Update is called once per frame
	void Update () {
		spawnCoolDownRemaining -= Time.deltaTime;
		if(spawnCoolDownRemaining < 0) {
			spawnCoolDownRemaining = spawnCoolDown;

			bool didSpawn = false;

			foreach(WaveComponent wc in wavecomps) {
				if(wc.spawned < wc.num) {

					wc.spawned++;
					Instantiate(wc.enemyPrefab, this.transform.position, this.transform.rotation);
					didSpawn = true;
					break;
				}
			}

			if(didSpawn == false){

				if(transform.parent.childCount <= 1)
				try
				{
				transform.parent.GetChild(1).gameObject.SetActive(true);
				Destroy(gameObject);
				}
				catch{
					Debug.Log("that was the last wave!");
				}

		
			}
		}
	}
}

