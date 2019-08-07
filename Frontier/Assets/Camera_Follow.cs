using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Camera_Follow : MonoBehaviour
{
    [SerializeField]
    private Transform playerTarget;
    private Transform target;
    [SerializeField]
    private float smoothness;
    [SerializeField]
    private float minX;
    [SerializeField]
    private float maxX;
    [SerializeField]
    private float minY;
    [SerializeField]
    private float maxY;
    [SerializeField]
    private bool boundless;
    private Vector3 clampedTarget;
    private static Camera_Follow instance;
    //Armin Shake
    private Vector3 screenShakeActive;
    private float screenShakeAmount;
    private float screenShakeDecay;
    //Size
    private float targetSize;
    //
    private bool followPlayer = true;
    private void Start()
    {
        target = playerTarget;
        targetSize = Camera.main.orthographicSize;
        instance = this;
    }
    // Update is called once per frame
    void Update()
    {
        CameraMovement();
        CameraZoom();
        CameraShake();
    }
    private void CameraMovement()
    {
        if (followPlayer)
        {
            if (!boundless)
                clampedTarget = new Vector3(Mathf.Clamp(target.position.x, minX, maxX), Mathf.Clamp(target.position.y, minY, maxY));
            else
                clampedTarget = target.position;
            clampedTarget.z = transform.position.z;
            transform.position = Vector3.Lerp(transform.position, clampedTarget, smoothness);
        }
       
      
    }
    private void CameraShake()
    {
        if (screenShakeAmount > 0)
        {
            screenShakeActive = new Vector3(Random.Range(-screenShakeAmount, screenShakeAmount), Random.Range(-screenShakeAmount, screenShakeAmount));
            screenShakeAmount -= Time.deltaTime * screenShakeDecay;
        }
        else
        {
            screenShakeActive = Vector3.zero;
        }
        transform.position += screenShakeActive;
    }
    private void CameraZoom()
    {
        if (Camera.main.orthographicSize != targetSize)
            Camera.main.orthographicSize = Mathf.Lerp(Camera.main.orthographicSize, targetSize, smoothness);
    }
    public static void ScreenShake(float toShake, float shakeDecay)
    {
        instance.screenShakeAmount = toShake;
        instance.screenShakeDecay = shakeDecay;
    }
    public static void ChangeBoundries(float minX, float maxX, float minY, float maxY, bool boundless)
    {
        instance.boundless = boundless;
        instance.minX = minX;
        instance.maxX = maxX;
        instance.minY = minY;
        instance.maxY = maxX;
    }
    public static void ChangeZoom(float size)
    {
        instance.targetSize = size;
    }
    public static void ChangeTarget()
    {
        instance.followPlayer = !instance.followPlayer;
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Vector2 center = new Vector2((minX + (maxX - minX) / 2), (minY + (maxY - minY) / 2));
        Vector2 size = new Vector2((maxX - minX), (maxY - minY)) + new Vector2(2 * Camera.main.aspect * Camera.main.orthographicSize, 2 * Camera.main.orthographicSize);
        Gizmos.DrawWireCube(center, size);
    }
}
