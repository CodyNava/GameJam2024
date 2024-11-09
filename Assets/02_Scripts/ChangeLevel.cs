using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeLevel : MonoBehaviour
{
	[SerializeField]
	private LevelConnection _connection;
	
	[SerializeField]
	private string _targetScene;
	
	[SerializeField]
	private Transform _spawnPoint;

	private void Start()
	{
		if (_connection == LevelConnection.ActiveLevelConnection)
		{
			GameObject player = GameObject.FindGameObjectWithTag("Player");
			player.transform.position = _spawnPoint.position;
		}
	}
	
	private void OnTriggerEnter2D(Collider2D collission)
	{
		if (collission.tag == "Player")
		{
			LevelConnection.ActiveLevelConnection = _connection;
			SceneManager.LoadScene(_targetScene);
		}
		
	}
}
