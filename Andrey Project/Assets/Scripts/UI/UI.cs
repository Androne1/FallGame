using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public static UI Instance;
    [SerializeField] private Button startButton;
    [SerializeField] private Button resumeButton;
    [SerializeField] private Button restartButton;
    [SerializeField] private Button exitButton;
    [SerializeField] private GameObject menu;
    [SerializeField] private GameObject loadingScreen;
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        menu.SetActive(false);
        loadingScreen.SetActive(false);
        startButton.onClick.AddListener(StartTime);
        resumeButton.onClick.AddListener(Resume);
        restartButton.onClick.AddListener(Restart);
        exitButton.onClick.AddListener(Exit);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ShowMenu(false);
        }
    }

    public void StartTime()
    {
        Time.timeScale = 1;
        startButton.gameObject.SetActive(false);
    }

    public void ShowMenu(bool byDeath)
    {
        if (menu.activeSelf == true) return;
        resumeButton.gameObject.SetActive(!byDeath);
        Time.timeScale = 0;
        menu.SetActive(true);
    }

    private void Resume()
    {
        StartTime();
        menu.SetActive(false);
    }

    private void Restart()
    {
        loadingScreen.SetActive(true);
        int index = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(index);
    }

    private void Exit()
    {
        loadingScreen.SetActive(true);
        SceneManager.LoadScene(0);
    }
}
