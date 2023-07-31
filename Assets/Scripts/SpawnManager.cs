using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemyPrefab;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        InvokeRepeating("SpawnEnemy", 2, 4.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SpawnEnemy()
    {
        if (player.GetComponent<Player>().gameOver == false) { 
        Instantiate(enemyPrefab[0], new Vector3(25, 2.3f, 28), Quaternion.identity);
        Instantiate(enemyPrefab[1], new Vector3(-25, 2.3f, 28), Quaternion.identity);
        Instantiate(enemyPrefab[2], new Vector3(-25, 2.3f, -31), Quaternion.identity);
        Instantiate(enemyPrefab[3], new Vector3(26, 2.3f, -31), Quaternion.identity);
    }
    }
}
