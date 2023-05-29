using InventorySystem;
using ItemSystem;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneGame : MonoBehaviour
{
    private const string SAVE_KEY = "save";

    [SerializeField] private ItemConfig _ammunitionItem;
    [SerializeField] private int _count;

    [Space] [Header ("Start enemy count + player level (start player level - 1)")]
    [SerializeField] private int _startEnemyCount;

    [Space]
    [SerializeField] private TextMeshProUGUI _textLevel;

    [Space]
    [SerializeField] private PlayerCreater _playerCreater;
    [SerializeField] private EnemySpawner _enemySpawner;
    [SerializeField] private LoseGame _loseGame;
    [SerializeField] private WinGame _winGame;

    private void Awake()
    {
        Application.targetFrameRate = 60;
    }

    private IEnumerator Start()
    {
        IStorageService storageService = new JsonToFileStorageService();

        storageService.Load(SAVE_KEY, (PlayerData save) =>
        {
            if(save == null) 
            {
                save = new PlayerData();
                save.Health = 30;
                save.HealthMax = 30;
                save.InventoryData = new InventoryData(-1);
                save.InventoryData.SlotsData.Add(new InventorySlot(_ammunitionItem.GetItem(), _count).GetSlotData());
                save.Level = 1;
            }

            Load(save);
        });

        yield return null;
    }

    private void Load (PlayerData playerSave)
    {
        _enemySpawner.Init();

        Player player = _playerCreater.Create(playerSave);
        _enemySpawner.Spawn(playerSave.Level + _startEnemyCount);

        _winGame.StartCheck(_enemySpawner, player, SAVE_KEY);
        _loseGame.StartCheck();

        _textLevel.text = "Lv. " + playerSave.Level;
    }

    public void NewGame ()
    {
        JsonToFileStorageService jsonToFileStorageService = new JsonToFileStorageService();
        jsonToFileStorageService.DeleteSave(SAVE_KEY);

        SceneManager.LoadScene(0);
    }
}
