using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
   public void Transition() =>  SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
   public void Exit() => Application.Quit();
}
