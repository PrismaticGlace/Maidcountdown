using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMover : MonoBehaviour {

    public void MoveScene() {
        SceneManager.LoadScene("Floor_top");
    }

    public void ExitGame() {
        Application.Quit();
    }
}
