using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;
    public float smoothSpeed = 0.125f;

    // Update is called once per frame
    void Update()
    {
/*        Debug.Log("followPlayer update called! Player position is " + player.position);
*/        transform.position = player.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, transform.position, smoothSpeed);
        transform.position = smoothedPosition;
    }
}
