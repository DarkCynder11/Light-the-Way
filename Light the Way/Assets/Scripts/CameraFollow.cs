using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;


    void LateUpdate()
    {
        transform.position = new Vector3(target.position.x -10, target.position.y + 9, target.position.z - 10);
    }
}
