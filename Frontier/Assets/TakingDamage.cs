﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakingDamage : MonoBehaviour
{
    private Animator animator;
    
    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("sword"))
        {
            animator.SetBool("Died", true);
        }
    }
    public void DestroyGameObject()
    {
        Destroy(gameObject);
    }
}
