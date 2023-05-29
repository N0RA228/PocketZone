using UnityEngine;
using UnityEngine.SceneManagement;

public class WinGame : MonoBehaviour
{
    [SerializeField] private Transform _winMenu;

    private Player _player;
    private string _saveKey;

    public void StartCheck (EnemySpawner enemySpawner, Player player, string saveKey)
    {
        enemySpawner.OnDeadAllEnemyEvent += OnDeadAllEnemy;
        _player = player;
        _saveKey = saveKey;
    }

    private void OnDeadAllEnemy()
    {
        WinMod();
    }

    public void WinMod ()
    {
        _winMenu.gameObject.SetActive(true);
    }

    public void Win ()
    {
        PlayerData playerData = _player.GetPlayerData();
        playerData.Level += 1;

        Save(playerData);
    }

    public void Return()
    {
        SceneManager.LoadScene(0);
    }

    private void Save(PlayerData save)
    {
        IStorageService storageService = new JsonToFileStorageService();

        storageService.Save(_saveKey, save, (flag) =>
        {
            SceneManager.LoadScene(0);
        });
    }
}
