using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class charactercombat : MonoBehaviour
{
    public Collider2D Sword_collider;
    public Animator animator;

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Sword_collider.enabled = true;
            animator.SetBool("IsAttacking", true);
        }

        
    }

    public void AttackEnded ()
    {
        Sword_collider.enabled = false;
        animator.SetBool("IsAttacking", false);
    }

}
