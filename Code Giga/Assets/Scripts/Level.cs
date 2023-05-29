using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] Transform _rubies;
    [SerializeField] int _level = 1;
    [SerializeField] Vector3[] _rubyPos;

    public bool _completed = false;
    private PlayerTestMovement _player;
    private LevelManager _manager;

    private void Awake()
    {
        _manager = GetComponentInParent<LevelManager>();
    }

    private void OnEnable()
    {
        _completed = false;
        if(_rubies.childCount < _rubyPos.Length)
        {
            while (_rubies.childCount > 0)
            {
                DestroyImmediate(_rubies.GetChild(0).gameObject);
            }
            InitLevel();
        }
        // _manager.ResetPlayers();
    }

    private void Start()
    {   
        _player = FindObjectOfType<PlayerTestMovement>();
        _manager.ResetPlayers();
    }

    private void InitLevel()
    {
        IntiRubies();
    }

    private void IntiRubies()
    {
        foreach(var pos in _rubyPos)
        {
            GameObject ruby = Instantiate(_manager.GetRubyGameObject(), _rubies);
            ruby.transform.position = pos;
        }
    }

    public void CheckWinCondition()
    {
        if (_rubies.childCount <= 0 && !_player.isRunningCode && !_completed)
        {
            Debug.Log("Level " + _level + " Completed!");
            _completed = true;
            _manager.ResetPlayers();
            _manager.ShowNextLevelPopUp();
        }
        else
        {
            Debug.Log("Try Again!");
            _manager.ResetPlayers();
            _manager.ShowTryAgainPopUp();
        }
    }
}
