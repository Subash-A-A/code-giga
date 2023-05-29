using UnityEngine;

public class WorldManager : MonoBehaviour
{
    [SerializeField] MouseLook _look;
    [SerializeField] Color _playerWorldBgColor;
    [SerializeField] Color _coderWorldBgColor;
    [SerializeField] float _colorLerpSpeed = 2f;
    [SerializeField] PlayerTestMovement _player;

    private Color _bgColor;
    private void Start()
    {
        _bgColor = _playerWorldBgColor;
    }

    private void Update()
    {
        BGColorLerper();

        if (Input.GetKeyDown(KeyCode.Tab) && !_player.isRunningCode)
        {
            SwitchPlayer();
        }
    }

    public void SwitchPlayer()
    {
        _look.SwitchPlayer();
        SwichWorld();
    }

    public void SwitchCamera(bool focusCoder)
    {
        _look.Focus(focusCoder);
        SwichWorld();
    }

    public void SwichWorld()
    {
        if (_look.IsPlayerCoder())
        {
            _bgColor = _coderWorldBgColor;
        }
        else
        {
            _bgColor = _playerWorldBgColor;
        }
    }

    private void BGColorLerper()
    {
        Camera.main.backgroundColor = Color.Lerp(Camera.main.backgroundColor, _bgColor, _colorLerpSpeed * Time.deltaTime);
    }
}
