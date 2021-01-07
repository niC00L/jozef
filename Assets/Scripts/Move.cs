using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{

    //speed by difficulty
    private float speed = 4.9f;

    void Update()
    {
        transform.position += Vector3.left * speed * DifficultyManager.gameSpeed * Time.deltaTime;
    }

    public void ChangeSpeed(float speedAdd)
    {
        speed += speedAdd;
    }
}
