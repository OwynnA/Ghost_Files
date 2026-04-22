using UnityEngine;

public class MatchPostion : MonoBehaviour
{
    public Transform target;

     void LateUpdate()
    {
        transform.position.Set(target.position.x, target.position.y, transform.position.z);
    }
    
}
