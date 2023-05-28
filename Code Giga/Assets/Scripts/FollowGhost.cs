using UnityEngine;

public class FollowGhost : MonoBehaviour
{
    [SerializeField] Transform _playerGhost;
    [SerializeField] float _yPos = 0.5f;
    [SerializeField] float _moveSpeed = 10f;
    [SerializeField] float _rotSpeed = 10f;

    private void Update()
    {   
        Quaternion rot = _playerGhost.rotation;
        rot.eulerAngles = new Vector3(0f, rot.eulerAngles.y, 0f);
        Vector3 targetPos = new Vector3(_playerGhost.position.x, _yPos, _playerGhost.position.z);

        transform.position = Vector3.Lerp(transform.position, targetPos, _moveSpeed * Time.deltaTime);
        transform.rotation = Quaternion.Lerp(transform.rotation, rot, _rotSpeed * Time.deltaTime);
    }
}
