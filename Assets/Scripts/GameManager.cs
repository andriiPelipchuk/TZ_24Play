using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private Spawner _spawner;
        [SerializeField] private WorkWithBoxArray _addbox;
        [SerializeField] private MovePlayer _movePlayer;
        [SerializeField] private DestroyMap _destroyMap;

        [SerializeField] private GameObject _player;
        [SerializeField] private GameObject _firstPlatform;

        [SerializeField] private GameObject _startButton;
        [SerializeField] private GameObject _tryAgainButton;
        private void Start()
        {
            TriggerBox.addBox += CreateBox;
            TriggerForCreatePlatform.triggerPlatform += CreatePlatform;
            WorkWithBoxArray.activeGameOver += GameOver;
        }

        public void StartGame()
        {
            _startButton.SetActive(false);

            _player.SetActive(true);
            _firstPlatform.SetActive(true);

            _spawner.StartGame();
        }
        public void TryPlayAgain()
        {
            _destroyMap.Destroyer();
            _tryAgainButton.SetActive(false);

            Camera.main.transform.position = new Vector3(3, 7, -15);

            _spawner.RestartPosition();
            _spawner.StartGame();
            CreateBox();
            _movePlayer.SetSpeed(3);
        }

        private void CreatePlatform()
        {
            _spawner.SpawnPlatform();
        }

        private void CreateBox()
        {
            _addbox.SpawnBox();
        }
        private void GameOver()
        {
            _movePlayer.SetSpeed(0);
            _tryAgainButton.SetActive(true);
        }
    }
}