using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {
    
    [SerializeField] public Image image;
    public void BeginButton() {
        SceneManager.LoadScene(1);
    }

    public void ExitButton() {
        Application.Quit();
    }
}
