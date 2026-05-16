using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player1;
    public Transform player2;
    public float smoothSpeed = 0.125f;
    public float offsetY = 2f;
    public float minY = 0f;
    public float maxY = 100f;

    void LateUpdate()
    {
        if (player1 == null || player2 == null) return;

        float highestY = Mathf.Max(player1.position.y, player2.position.y);
        float targetY = Mathf.Clamp(highestY + offsetY, minY, maxY);

        Vector3 target = new Vector3(transform.position.x, targetY, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, target, smoothSpeed);
    }
}