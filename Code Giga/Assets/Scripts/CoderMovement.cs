using UnityEngine;
public class CoderMovement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private Animator _anim;
    [SerializeField] private Vector2 _bounds;

    private Rigidbody _rb;

    private Vector2 _input;

    private void Start()
    {   
        _rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        MyInput();
        _anim.SetBool("isRunning", _rb.velocity.magnitude > 0.5f);

        transform.forward = Camera.main.transform.forward;
    }

    private void FixedUpdate()
    {
        Vector3 dir = transform.forward * _input.y + transform.right * _input.x;
        dir.Normalize();
        _rb.velocity = dir * _moveSpeed;
        _rb.position = new Vector3(
            Mathf.Clamp(_rb.position.x, -_bounds.x - 100, _bounds.x - 100),
            0f,
            Mathf.Clamp(_rb.position.z, -_bounds.y, _bounds.y));
    }

    private void MyInput()
    {
        _input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }
}
