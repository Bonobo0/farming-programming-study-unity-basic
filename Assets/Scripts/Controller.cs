using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public float speed = 10.0f;
    private bool isMovingWithMovingTowards = false;
    private bool isMovingWithSmoothDamp = false;
    private bool isMovingWithLerp = false;
    private bool isMovingWithSLerp = false;
    void Start()
    {
        Vector3 initialPosition = new Vector3(0, 1, 0);
        transform.Translate(initialPosition);
    }

    void Update()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        transform.Translate(movement * Time.deltaTime * speed);
        // Time.deltaTime: 이전 프레임의 완료까지 걸린 시간
        // FPS(Frame Per Second)에 반비례하여 변화함.

        // Initial Position
        if (Input.GetButtonDown("Reset"))
        {
            Vector3 initialPosition = new Vector3(0, 1, 0);
            transform.position = initialPosition;
        }
        // MoveTowards
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isMovingWithMovingTowards = !isMovingWithMovingTowards;
            isMovingWithSmoothDamp = false;
            isMovingWithLerp = false;
            isMovingWithSLerp = false;
            if (isMovingWithMovingTowards)
            {
                Debug.Log("MoveTowards 함수를 사용하여 이동합니다.");
            }
        }
        if (isMovingWithMovingTowards)
        {
            Vector3 targetPosition = new Vector3(0, 1.3f, 20);
            float movingSpeed = 0.05f;
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, movingSpeed);
        }
        // SmoothDamp
        Vector3 velo = Vector3.zero;
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            isMovingWithSmoothDamp = !isMovingWithSmoothDamp;
            isMovingWithMovingTowards = false;
            isMovingWithLerp = false;
            isMovingWithSLerp = false;
            if (isMovingWithSmoothDamp)
            {
                Debug.Log("SmoothDamp 함수를 사용하여 이동합니다.");
            }
        }
        if (isMovingWithSmoothDamp)
        {
            Vector3 targetPosition = new Vector3(0, 1.3f, 20);
            float smoothTime = 0.1f;
            // smoothTime 값에 반비례하여 속도 증가
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velo, smoothTime);
        }
        // Lerp(선형 보간)
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            isMovingWithLerp = !isMovingWithLerp;
            isMovingWithMovingTowards = false;
            isMovingWithSmoothDamp = false;
            isMovingWithSLerp = false;
            if (isMovingWithLerp)
            {
                Debug.Log("Lerp 함수를 사용하여 이동합니다.");
            }
        }
        if (isMovingWithLerp)
        {
            Vector3 targetPosition = new Vector3(0, 1.3f, 20);
            float lerpSpeed = 0.01f;
            // lerpSpeed 값에 비례하여 속도 증가
            transform.position = Vector3.Lerp(transform.position, targetPosition, lerpSpeed);
        }
        // SLerp(구면 선형 보간)
        if (Input.GetKeyDown(KeyCode.LeftAlt))
        {
            isMovingWithSLerp = !isMovingWithSLerp;
            isMovingWithMovingTowards = false;
            isMovingWithSmoothDamp = false;
            isMovingWithLerp = false;
            if (isMovingWithSLerp)
            {
                Debug.Log("SLerp 함수를 사용하여 이동합니다.");
            }
        }
        if (isMovingWithSLerp)
        {
            Vector3 targetPosition = new Vector3(0, 1.3f, 20);
            float slerpSpeed = 0.01f;
            // slerpSpeed 값에 비례하여 속도 증가
            transform.position = Vector3.Slerp(transform.position, targetPosition, slerpSpeed);
        }


    }
}
