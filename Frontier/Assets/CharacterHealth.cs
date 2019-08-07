using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterHealth : MonoBehaviour
{
    public static CharacterHealth characterhealth;
    private Animator animator;
    private float CurrentHealth;
    public float  MaxHealth = 100f;
    private bool gameover=false;
    
   
   
    void Start()
    {
        characterhealth = this;
        animator = GetComponent<Animator>();
        CurrentHealth = MaxHealth;

       
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(CurrentHealth);
       

        if (CurrentHealth <= 0)
        {
            died();
        }
        if (Input.GetKeyDown(KeyCode.Space) && gameover == true)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            Time.timeScale = 1;
        }

    }
    public void died()
    {
        animator.SetBool("Died", true);

        gameover = true;
    }
    public void freeze()
    {
        Time.timeScale = 0;
    }
  
    
    public void takingdamage(float damage)
    {
        animator.SetBool("hit", true);

        CurrentHealth = CurrentHealth - damage;
    }
}

