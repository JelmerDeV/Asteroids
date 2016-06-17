using UnityEngine;
using System.Collections;

public class Spawning : MonoBehaviour
{
    public GameObject enemy;
    public float spawnTime = 3f;
    public Transform[] spawnPoints;
	private int fishesInScene;
	public int maxFish = 40;


    void Start()
    {

        InvokeRepeating("Spawn", spawnTime, spawnTime);


    }

	void Update(){
		GameObject[] collectableObjs = GameObject.FindGameObjectsWithTag ("fish");
		fishesInScene = collectableObjs.Length;
	}


    void Spawn()
    {
		if (fishesInScene < maxFish) {
			int spawnPointIndex = Random.Range (0, spawnPoints.Length);


			Instantiate (enemy, spawnPoints [spawnPointIndex].position, spawnPoints [spawnPointIndex].rotation);
		}
    }
}