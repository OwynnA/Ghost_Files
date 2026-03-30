using UnityEngine;

public class TwoBoneIK : MonoBehaviour
{
    public Transform root;   // shoulder / hip
    public Transform mid;    // elbow / knee
    public Transform end;    // hand / foot

    public Transform target; // IK target
    public Transform pole;   // pole vector (elbow/knee direction)

    void LateUpdate()
    {
        Solve();
    }

    void Solve()
    {
        Vector3 rootPos = root.position;
        Vector3 midPos = mid.position;
        Vector3 endPos = end.position;
        Vector3 targetPos = target.position;

        float upperLength = Vector3.Distance(rootPos, midPos);
        float lowerLength = Vector3.Distance(midPos, endPos);

        Vector3 targetDir = targetPos - rootPos;
        float distance = targetDir.magnitude;

        distance = Mathf.Min(distance, upperLength + lowerLength - 0.001f);

        float a = upperLength;
        float b = lowerLength;
        float c = distance;

        float cosAngle = (a*a + c*c - b*b) / (2*a*c);
        float angle = Mathf.Acos(Mathf.Clamp(cosAngle, -1f, 1f));

        Vector3 bendNormal = Vector3.Cross(targetDir, pole.position - rootPos).normalized;

        Quaternion rootRotation =
            Quaternion.LookRotation(targetDir) *
            Quaternion.AngleAxis(-angle * Mathf.Rad2Deg, bendNormal);

        root.rotation = rootRotation;

        Vector3 midToTarget = targetPos - mid.position;
        mid.rotation = Quaternion.LookRotation(midToTarget, bendNormal);

        end.position = targetPos;
    }
}
