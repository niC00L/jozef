using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField]
    private GameManager gameManager;

    private Animator animator;
    private float defaultAnimatorSpeed;

    //speed by difficulty
    
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        defaultAnimatorSpeed = animator.speed;
    }

    private void Update()
    {
        animator.speed = defaultAnimatorSpeed * DifficultyManager.GameSpeed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            gameManager.GameOver(collision.gameObject);
        }
    }
}
