using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Shooter : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    public float stoppingDistance;
    public float retreatDistance;
    public float SightDistance = 10;
    public bool CanMove = true;
    public bool CanShoot = true;

    private float timeBtwShots;
    public float startTimeBtwShots;

    private Transform player;
    public GameObject projectile;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        timeBtwShots = startTimeBtwShots;
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector2.Distance(transform.position, player.position);

        if (distance > SightDistance)
            return;

        if (CanMove)
        {
            if (distance > stoppingDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
            }
            else if (distance < stoppingDistance && distance > retreatDistance)
            {
                transform.position = this.transform.position;
            }
            else if (distance > retreatDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);
            }
        }

        if (CanShoot)
        {
            if (timeBtwShots <= 0)
            {
                Instantiate(projectile, transform.position, Quaternion.identity);
                timeBtwShots = startTimeBtwShots;
            }
            else
            {
                timeBtwShots -= Time.deltaTime;
            }
        }
    }
}