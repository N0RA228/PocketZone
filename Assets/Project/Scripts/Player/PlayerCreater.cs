using ItemSystem;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCreater : MonoBehaviour
{
    [SerializeField] private Player _prefabPlayer;

    [Space]
    [SerializeField] private Transform _spawnPoint;

    [Space]
    [SerializeField] private Follower _camera;
    [SerializeField] private UIInventory _uiInventory;
    [SerializeField] private UIHealth _uiHealth;

    [Space]

    [SerializeField] private KeyBoardInput _keyBoardInput;
    [SerializeField] private MobileController _mobileController;

    public Player Create (PlayerData playerSave)
    {
        Player player = Instantiate(_prefabPlayer, _spawnPoint.position, Quaternion.identity);

        player.Init(playerSave);

        _uiHealth.SetHealth(player.Health);
        _uiInventory.SetInventory(player.Inventory);

        _camera.SetFollowTransform(player.transform);


        IMovable movable = player.GetComponent<IMovable>();
        IShot shot = player.GetComponent<IShot>();

        _keyBoardInput.SetControllable(movable);
        _keyBoardInput.SetShot(shot);

        _mobileController.SetControllable(movable);
        _mobileController.SetShot(shot);

        return player;
    }
}
