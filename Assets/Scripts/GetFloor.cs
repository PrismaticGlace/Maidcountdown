using UnityEngine;
using UnityEngine.SceneManagement;
using static Unity.Burst.Intrinsics.X86;

public class GetFloor : MonoBehaviour {

    public TMPro.TMP_Text floorText;

    // Update is called once per frame
    void Update() {

        Scene sce = SceneManager.GetActiveScene();

        if (sce == SceneManager.GetSceneByName("Floor 5")) {
            floorText.text = "Floor 5";
        }
        else {
            floorText.text = "Floor 6";
        }
    }
}
