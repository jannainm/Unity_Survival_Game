using UnityEngine;

public class EnemyManager : MonoBehaviour
{
	public PlayerHealth playerHealth;
	// player health reference
	public GameObject enemy;
	// game object reference of enemy prefab to spawn
	public float spawnTime = 3f;
	// 3 second spawn time; public so it can be changed
	public Transform[] spawnPoints;
	// public transform array of spawn points...we only use one instance for this


	void Start ()
	{
		InvokeRepeating ("Spawn", spawnTime, spawnTime);
	}


	void Spawn ()
	{
		if (playerHealth.currentHealth <= 0f) {
			return;
		}

		int spawnPointIndex = Random.Range (0, spawnPoints.Length);

		Instantiate (enemy, spawnPoints [spawnPointIndex].position, spawnPoints [spawnPointIndex].rotation);
//
	}
}
