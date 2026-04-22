using UnityEngine;

public class LockRotation : MonoBehaviour
{
    public Transform target;
    public void LateUpdate()
    {
        if (target == null) return;

        Vector3 dir = target.position - transform.position;

        if (dir.sqrMagnitude < 0.0001f) return;

        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

        // Fix: Add 180 degrees when pointing left
        if (dir.x < 0)
        {
            angle += 180f;
        }
        
        
        transform.rotation = Quaternion.Euler(0,180 ,-angle);
        
    }
    
    
    
}
