using UnityEngine;

public class Motion : MonoBehaviour
{
    private CharacterController         cController;
    private Animator                    animator;
    private Vector3                     animVelocity;
    private Vector3                     moveDirection;
    private Vector2                     lookDirection;

    public GameObject                   testObject;
    public float                        speed;
    public float                        acceleration;
    public float                        deacceleration;
    public float                        cameraRadius;

    void Start()
    {
        cController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        animVelocity = Vector3.zero;
        lookDirection = Vector2.zero;
    }

    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        float mx = Input.GetAxis("Mouse X");
        moveDirection = (transform.right * h + transform.forward * v).normalized;
        animVelocity.x = Mathf.Lerp(animVelocity.x, -h, moveDirection.x > 0f ? acceleration : deacceleration);
        animVelocity.z = Mathf.Lerp(animVelocity.z, -v, moveDirection.z > 0f ? acceleration : deacceleration);
        
        transform.Rotate(Vector3.up * mx);
        
        if (moveDirection.magnitude != 0.0f)
            cController.Move(moveDirection * speed * 0.005f);

        animator.SetFloat("Horizontal Speed", -animVelocity.x);
        animator.SetFloat("Vertical Speed", -animVelocity.z);
    }
}
