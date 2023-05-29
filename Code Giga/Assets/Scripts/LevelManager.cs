using UnityEngine;
public class LevelManager : MonoBehaviour
{
    [SerializeField] private GameObject _ruby;
    [SerializeField] private WorldManager _world;
    [SerializeField] private GameObject _tryAgainPopUp;
    [SerializeField] private GameObject _nextLevelPopUp;
    [SerializeField] private GameObject _exitPopUp;

    public int currentLevel = 1;

    private void Start()
    {
        HideAllPopUps();

        ResetPlayers();
        DisableAllLevels();
        EnableCurrentLevel();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !_nextLevelPopUp.activeSelf && !_tryAgainPopUp.activeSelf)
        {
            if (_exitPopUp.activeSelf)
            {
                HideAllPopUps();
            }
            else
            {
                ShowExitPopUp();
            }
        }
    }

    public void ToNextLevel()
    {
        if(currentLevel > transform.childCount)
        {
            currentLevel = 1;
        }
        else
        {
            currentLevel++;
        }
        DisableAllLevels();
        EnableCurrentLevel();
        HideAllPopUps();
    }

    public void RetryLevel()
    {
        DisableAllLevels();
        EnableCurrentLevel();
        HideAllPopUps();
    }

    public GameObject GetRubyGameObject()
    {
        return _ruby;
    }

    private void DisableAllLevels()
    {
        foreach(Transform level in transform)
        {
            level.gameObject.SetActive(false);
        }
    }

    private void EnableCurrentLevel()
    {
        transform.GetChild(currentLevel - 1).gameObject.SetActive(true);
    }

    public void ResetPlayers()
    {
        _world.ResetPlayers();
    }

    public void CheckWinCondition()
    {
        transform.GetChild(currentLevel - 1).GetComponent<Level>().CheckWinCondition();
    }

    public void ShowTryAgainPopUp()
    {
        HideAllPopUps();

        _tryAgainPopUp.SetActive(true);

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void ShowNextLevelPopUp()
    {
        HideAllPopUps();

        _nextLevelPopUp.SetActive(true);

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void ShowExitPopUp()
    {
        HideAllPopUps();

        _exitPopUp.SetActive(true);

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        Time.timeScale = 0;
    }

    public void HideAllPopUps()
    {
        _nextLevelPopUp.SetActive(false);
        _tryAgainPopUp.SetActive(false);
        _exitPopUp.SetActive(false);

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        Time.timeScale = 1;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
