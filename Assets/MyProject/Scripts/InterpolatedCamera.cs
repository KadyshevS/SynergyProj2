using UnityEngine;

public class InterpolatedCamera : MonoBehaviour
{
    public GameObject   followTarget;
    public GameObject   lookTarget;
    public float        interpolationSpeed;

    void FixedUpdate()
    {
        var pos1 = transform.position;
        var pos2 = followTarget.transform.position;
        transform.position = new Vector3(
            Mathf.Lerp(pos1.x, pos2.x, interpolationSpeed),
            Mathf.Lerp(pos1.y, pos2.y, interpolationSpeed),
            Mathf.Lerp(pos1.z, pos2.z, interpolationSpeed)
        );

        transform.LookAt(lookTarget.transform.position);
    }
}
