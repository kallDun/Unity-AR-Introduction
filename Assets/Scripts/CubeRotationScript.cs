using UnityEngine;

public class CubeRotationScript : MonoBehaviour
{
    private void Update()
    {
        transform.Rotate(Vector3.up, Time.deltaTime * 5);
    }
}