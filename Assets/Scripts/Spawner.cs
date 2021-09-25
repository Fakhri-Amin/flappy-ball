using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject blockPrefab;
    public float timer = 2f;
    private float time = 0f;
    private PlayerMovement playerMovement;

    // Update is called once per frame
    private void Start()
    {
        playerMovement = FindObjectOfType<PlayerMovement>();
    }
    void Update()
    {
        if (playerMovement.gameHasStarted)
        {
            if (time <= 0)
            {
                Instantiate(blockPrefab, transform.position, Quaternion.identity);
                time = timer;
            }
            else
            {
                time -= Time.deltaTime;
            }
        }
    }
}
