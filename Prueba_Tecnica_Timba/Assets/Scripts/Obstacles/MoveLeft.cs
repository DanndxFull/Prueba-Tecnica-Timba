using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    [SerializeField] private Vector2 speedRange;
    [SerializeField] private float speed;
    [SerializeField] private float liveTime;

    private float currentTime;

    private void OnEnable()
    {
        currentTime = 0;
        speed = Random.Range(speedRange.x,speedRange.y);
        speed += ScoreTime.currentScore / 100;
    }

    private void FixedUpdate()
    {
        currentTime += Time.deltaTime;
        transform.Translate(Vector3.left * Time.deltaTime * speed);
        if (currentTime >= liveTime)
        {
            currentTime = 0;
            this.gameObject.SetActive(false);
        }
    }
}
