using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseGame : MonoBehaviour
{
    public void StartCheck()
    {
        Player.OnDeadEvent += Lose;
    }

    private void OnDisable()
    {
        Player.OnDeadEvent -= Lose;
    }

    public void Lose(Player player)
    {
        SceneManager.LoadScene(0);
    }
}
