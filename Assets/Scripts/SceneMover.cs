using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using static Unity.Burst.Intrinsics.X86;

public class SceneMover : MonoBehaviour {

    public PlayerController pc;

    public void MoveScene() {
        SceneManager.LoadScene("Floor_top");
    }

    public void ExitGame() {
        Application.Quit();
    }

    void Update() {
        Scene sce = SceneManager.GetActiveScene();

        if (pc != null) {
            if (pc.playerHealth <= 0) {
                pc.gameObject.SetActive(false);
                if (sce == SceneManager.GetSceneByName("Floor 5")) {
                    SceneManager.LoadScene("Floor 5");
                }
            }
        }
    }


}
