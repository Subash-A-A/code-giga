using UnityEngine;

public class MouseLook : MonoBehaviour
{   
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private Transform _coderTransform;
    [SerializeField] private float _posFollowSmooth = 5f;
    [SerializeField] private float _camRotSmooth = 10f;
    [SerializeField] private float _zoomSmooth = 10f;
    [SerializeField] private float _minZoom = 3f;
    [SerializeField] private float _maxZoom = 7f; 
    [SerializeField] private float _mouseSensitivity = 1.5f;
    [SerializeField] private bool _isCoder = false;
    private float _rotationY = 45f;
    private float _zoomDistance = 4f;
    private Vector3 _targetPos;

    private void Start()
    {
        _targetPos = _playerTransform.position;

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        _targetPos = _isCoder ?_coderTransform.position : _playerTransform.position;

        MyInput();
        RotateCamera();
        MoveCamera();
    }

    private void MyInput()
    {
        _rotationY += Input.GetAxisRaw("Mouse X") * _mouseSensitivity;
        // _rotationX -= Input.GetAxisRaw("Mouse Y") * _mouseSensitivity;
        // _rotationX = Mathf.Clamp(_rotationX, 20f, 60f);
        _zoomDistance -= Input.GetAxisRaw("Mouse ScrollWheel");
        _zoomDistance = Mathf.Clamp(_zoomDistance, _minZoom, _maxZoom);
    }

    private void RotateCamera()
    {
        Quaternion rot = Quaternion.Euler(30f, _rotationY, 0);
        transform.rotation = Quaternion.Lerp(transform.rotation, rot, _camRotSmooth * Time.deltaTime);
        Camera.main.orthographicSize = Mathf.Lerp(Camera.main.orthographicSize, _zoomDistance, _zoomSmooth * Time.deltaTime);
    }

    private void MoveCamera()
    {
        Vector3 pos = new (_targetPos.x, 0f, _targetPos.z);
        transform.position = Vector3.Lerp(transform.position, pos, _posFollowSmooth * Time.deltaTime);
    }

    public void SwitchPlayer()
    {
        _isCoder = !_isCoder;
    }

    public bool IsPlayerCoder()
    {
        return _isCoder;
    }

    public void Focus(bool isCoder)
    {
        _isCoder = isCoder;
    }
}
