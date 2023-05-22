using UnityEngine;

public class MouseLook : MonoBehaviour
{   
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private float _posFollowSmooth = 5f;
    [SerializeField] private float _camRotSmooth = 10f;
    private float _rotation = 45f;

    private void Update()
    {
        MyInput();
        RotateCamera();
        MoveCamera();
    }

    private void MyInput()
    {
        _rotation -= Input.GetAxisRaw("Horizontal");
    }

    private void RotateCamera()
    {
        Quaternion rot = Quaternion.Euler(30, _rotation, 0);
        transform.rotation = Quaternion.Lerp(transform.rotation, rot, _camRotSmooth * Time.deltaTime);
    }

    private void MoveCamera()
    {
        Vector3 pos = new (_playerTransform.position.x, 0f, _playerTransform.position.z);
        transform.position = Vector3.Lerp(transform.position, pos, _posFollowSmooth * Time.deltaTime);
    }
}
