using Unity.VectorGraphics;
using UnityEngine;
using UnityEngine.SceneManagement;
using static Unity.Burst.Intrinsics.X86;

public class SetScene : MonoBehaviour {


    UnityEngine.SceneManagement.Scene scene;

    void Update() {
        scene = SceneManager.GetActiveScene();
    }

    void OnTriggerEnter2D(Collider2D collision) {
        if (scene == SceneManager.GetSceneByName("Floor_Top")) {
            SceneManager.LoadScene("Floor 5");
        }
        else if (scene == SceneManager.GetSceneByName("Floor 5")) {
            SceneManager.LoadScene("MainMenu");
        }
    }

}
