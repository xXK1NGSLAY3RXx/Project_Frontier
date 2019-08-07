using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public float moveSpeed;
    public float sightDistance;
    public float shootingDistance;
    public float minimumDistance;
    public float groundLevel;
    public bool canShoot = true;
    public bool canMove = true;
    public bool canFly = true;
    public int fireRate = 600;
    public GameObject projectile;

    private float shootTimer;
    private float delayBetweenShots;
    private Transform player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        delayBetweenShots = 60f / fireRate;
        shootTimer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        if (canMove)
        {
            Vector3 targetPosition = player.position;
            if (!canFly)
                targetPosition.y = groundLevel;

            if (distanceToPlayer < minimumDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, targetPosition, -moveSpeed * Time.deltaTime);
            }
            else if (distanceToPlayer < sightDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
            }
        }

        if (canShoot && distanceToPlayer < shootingDistance)
        {
            if (shootTimer <= 0)
            {
                Instantiate(projectile, transform.position, Quaternion.identity);
                shootTimer = delayBetweenShots;
            }
            else
            {
                shootTimer -= Time.deltaTime;
            }
        }
    }
}