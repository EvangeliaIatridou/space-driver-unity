using UnityEngine;
using Speed;

public class AttachToFloor : MonoBehaviour
{
    
    private void Update()
    {
        transform.position += Vector3.right * SharedSpeed.speed * Time.deltaTime; // Move backward
    }
}
