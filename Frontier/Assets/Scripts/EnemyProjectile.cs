using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemysProjectile : MonoBehaviour
{
    public float moveSpeed;

    private Vector2 target;

    void Start()
    {
        Transform player = GameObject.FindGameObjectWithTag("Player").transform;
        target = new Vector2(player.position.x, player.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target, moveSpeed * Time.deltaTime);

        if(Vector2.Distance(transform.position, target) < 0.01f)
        {
            DestroyProjectile();
        }
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            DestroyProjectile();
        }
    }

    void DestroyProjectile()
    {
        Destroy(gameObject);
    }
}