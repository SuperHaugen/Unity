using UnityEngine.SceneManagement;
using UnityEngine;

public class change_scene : MonoBehaviour {

public void ChangeScene(string scene_name) 
{
SceneManager.LoadScene("scene");
}

}
