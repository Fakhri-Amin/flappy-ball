using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float distance = 30f;
    public float timeToDestroy = 5f;
    private float randomPos;
    void Start()
    {
        randomPos = Random.Range(-2.7f, 3.4f);
        transform.position = new Vector2(transform.position.x, randomPos);
        Invoke("DestroySelf", timeToDestroy);
    }

    void Update()
    {
        // transform.position = Vector2.MoveTowards(transform.position, Vector2.left * distance, Time.deltaTime * moveSpeed);

        transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
    }

    private void DestroySelf()
    {
        Destroy(gameObject);
    }

}
