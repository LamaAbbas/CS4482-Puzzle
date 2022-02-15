using UnityEngine;
using UnityEngine.SceneManagement;

public class EndPhase : MonoBehaviour {

    private bool endGame = false;

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "Player") {
            endGame = true;
            Invoke("EndScene", 3f);
        }
    }

    private void EndScene() {
        SceneManager.LoadScene(0);
    }

    public bool EndGame() {
        return endGame;
    }

}
