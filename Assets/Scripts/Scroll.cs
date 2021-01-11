using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll : MonoBehaviour
{
    //speed by difficulty

    [SerializeField]
    private float speed = 1;

    void Update()
    {
        Vector2 offset = new Vector2(Time.timeSinceLevelLoad * speed * DifficultyManager.gameSpeed, 0);

        GetComponent<Renderer>().material.mainTextureOffset = offset;
    }
}
