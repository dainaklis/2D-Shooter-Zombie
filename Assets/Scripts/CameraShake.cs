using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{   
    public static CameraShake cameraShake;
    [SerializeField] private float moveAmount = 0.5f; 
    [SerializeField] private int cycleCount = 1; // kaip daznai shakins
    [SerializeField] private float interval = 0.2f; //  kiek tesis

    void Awake()
    {
        cameraShake = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CameraShaking()
    {
        StartCoroutine(CameraShakeRoutine(moveAmount,cycleCount,interval));

    }

    IEnumerator CameraShakeRoutine(float moveAmount, int cycleCount, float interval)
    {
        Vector3 lastPos = transform.position;
        Vector3 pos;


        for (int i = 0; i < cycleCount; i++)
        {
            float x = Random.Range(-moveAmount,moveAmount);
            float y = Random.Range(-moveAmount,moveAmount);

            pos = transform.position;
            pos.x += x;
            pos.y += y;
            transform.position = pos;

            yield return new WaitForSeconds(interval);

            pos = transform.position;
            pos.x += x;
            pos.y += y;
            transform.position = pos;
            yield return new WaitForSeconds(interval);

        }

        transform.position = lastPos;
    }
}
