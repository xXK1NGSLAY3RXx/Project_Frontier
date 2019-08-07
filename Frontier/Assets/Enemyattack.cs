using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemyattack : MonoBehaviour
{
    public float CurrentDamage = 10f;
    private bool damageblock = false;
    public float time_between_attacks = 1f;
    private float timer=0;
    private Vector2 knockback_dir;
    private void Start()
    {
        
        //characterhealth = new CharacterHealth();
    }
    private void Update()
    {
        if (damageblock == true)
        {
            timer -= Time.deltaTime;
            if (timer <= 0f)
            {
                damageblock = false;
            }
        }

        if (PlayerMovement.playermovement.lastDir == 1)
        {
            knockback_dir = new Vector2(-3, 1);
        }
        else
        {
            knockback_dir = new Vector2(3, 1);
        }
        
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player") && damageblock == false)
        {
            //CharacterPhysic.characterphysic.rb.AddForce(new Vector2 (1) * 300);
            CharacterPhysic.characterphysic.rb.AddForce(knockback_dir * 100);

            CharacterHealth.characterhealth.takingdamage(CurrentDamage);

            
            
            
            timer = time_between_attacks;
            damageblock = true;

        }
    }
    //private void OnCollisionExit2D(Collision2D collision)
    //{
    //    if (collision.collider.CompareTag("Player"))
    //    {

    //        damageblock = false;

    //    }
    //}
}
