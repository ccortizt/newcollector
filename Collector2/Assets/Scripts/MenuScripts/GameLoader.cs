using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class GameLoader : MonoBehaviour
{

    GameObject hud;
    GameObject board;
    GameObject inGameHUD;
    GameObject gamePad;

    private Button playButton;
    private Button quitButton;

    private GameObject player;
    private GameObject enemy;

    private Vector3 playerInitialPos = new Vector3(3f, 0.55f, -3f);
    private Vector3 enemyInitialPos = new Vector3(-3f, 0.55f, 3f);

    public GameObject target;


    void Awake()
    {
        LoadMenu();
    }

    void StartGamePlay()
    {

        GameObject.Find("HUD").SetActive(false);

        board = (GameObject)Instantiate(Resources.Load("Prefabs/Board"), Vector3.zero, Quaternion.Euler(90, 0, 0));
        board.name = "Board";

        SetPlayer();

        SetEnemy();

        inGameHUD = (GameObject)Instantiate(Resources.Load("Prefabs/BoardHUD"), Vector3.zero, Quaternion.identity);
        inGameHUD.name = "InGameHUD";

        gamePad = (GameObject)Instantiate(Resources.Load("Prefabs/GamePad"), Vector3.zero, Quaternion.identity);
        gamePad.name = "GamePad";
#if !UNITY_ANDROID
        gamePad.SetActive(false);            
#endif

    }


    void QuitGame()
    {
        Application.Quit();
    }

    public void LoadMenu()
    {
        hud = (GameObject)Instantiate(Resources.Load("Prefabs/MainMenu"), transform.position, transform.rotation);
        hud.name = "HUD";

        playButton = (Button)GameObject.Find("MainPanel/ButtonPanel/PlayButton").GetComponent<Button>();
        playButton.onClick.AddListener(() => StartGamePlay());

        quitButton = (Button)GameObject.Find("MainPanel/ButtonPanel/QuitButton").GetComponent<Button>();
        quitButton.onClick.AddListener(() => QuitGame());

    }

    private void SetPlayer()
    {
        player = (GameObject)Instantiate(Resources.Load("Prefabs/Player"), playerInitialPos, Quaternion.Euler(90, 90, 0));
        player.name = "Player";
        player.GetComponent<NavMeshObstacle>().enabled = true;
    }

    private void SetEnemy()
    {
        enemy = (GameObject)Instantiate(Resources.Load("Prefabs/Player"), enemyInitialPos, Quaternion.Euler(90, 90, 0));
        enemy.name = "Enemy";

        enemy.GetComponent<PlayerController>().enabled = false;
        enemy.GetComponent<IAPlayerController>().enabled = true;
        enemy.GetComponent<NavMeshObstacle>().enabled = false;
        enemy.GetComponent<NavMeshAgent>().enabled = true;
    }
}
