using UnityEngine;
using UnityEngine.SceneManagement;
[ExecuteAlways]
public class jump : MonoBehaviour
{
    public void jump2Scene(string scene)
    {
        SceneManager.LoadScene(scene);
    }
}
