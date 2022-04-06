using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WantedBoardManager : MonoBehaviour
{
    public enum EnemyName { Goblin, Orc, Troll, Skeleton, Mushroom, Lich, Witch, Vampire, Derzin, Ingrar, Zarzog, Xenoria }; //Names of enemies and bosses
    public EnemyName enemyName;
    public bool levelComplete;
    [SerializeField]TextMeshProUGUI text;
    TextMeshProUGUI nameText;
    GameObject levelCompletion;
    bool addCompleted;
    GameObject spawner;
    List<GameObject> enemies = null;
    GameObject[] spawned;
    private void Awake()
    {
        gameObject.tag = "WantedBoard";
        float currentDestroyed = 0;

        switch (enemyName)
        {

            case EnemyName.Goblin:
                PlayerPrefs.SetFloat(enemyName + "WantedPoster", currentDestroyed);
                PlayerPrefs.SetFloat(enemyName + "Spawned", 0);
                PlayerPrefs.SetFloat(enemyName + "TotalSpawned", 0);

                break;
            case EnemyName.Orc:
                PlayerPrefs.SetFloat(enemyName + "WantedPoster", currentDestroyed);
                PlayerPrefs.SetFloat(enemyName + "Spawned", 0);
                PlayerPrefs.SetFloat(enemyName + "TotalSpawned", 0);

                break;
            case EnemyName.Troll:
                PlayerPrefs.SetFloat(enemyName + "WantedPoster", currentDestroyed);
                PlayerPrefs.SetFloat(enemyName + "Spawned", 0);
                PlayerPrefs.SetFloat(enemyName + "TotalSpawned", 0);
                break;
            case EnemyName.Skeleton:
                PlayerPrefs.SetFloat(enemyName + "WantedPoster", currentDestroyed);
                PlayerPrefs.SetFloat(enemyName + "Spawned", 0);
                PlayerPrefs.SetFloat(enemyName + "TotalSpawned", 0);
                break;
            case EnemyName.Mushroom:
                PlayerPrefs.SetFloat(enemyName + "WantedPoster", currentDestroyed);
                PlayerPrefs.SetFloat(enemyName + "Spawned", 0);
                PlayerPrefs.SetFloat(enemyName + "TotalSpawned", 0);
                break;
            case EnemyName.Lich:
                PlayerPrefs.SetFloat(enemyName + "WantedPoster", currentDestroyed);
                PlayerPrefs.SetFloat(enemyName + "Spawned", 0);
                PlayerPrefs.SetFloat(enemyName + "TotalSpawned", 0);
                break;
            case EnemyName.Witch:
                PlayerPrefs.SetFloat(enemyName + "WantedPoster", currentDestroyed);
                PlayerPrefs.SetFloat(enemyName + "Spawned", 0);
                PlayerPrefs.SetFloat(enemyName + "TotalSpawned", 0);
                break;
            case EnemyName.Vampire:
                PlayerPrefs.SetFloat(enemyName + "WantedPoster", currentDestroyed);
                PlayerPrefs.SetFloat(enemyName + "Spawned", 0);

                break;
            case EnemyName.Derzin:
                PlayerPrefs.SetFloat(enemyName + "WantedPoster", currentDestroyed);
                PlayerPrefs.SetFloat(enemyName + "Spawned", 0);
                PlayerPrefs.SetFloat(enemyName + "TotalSpawned", 0);
                break;
            case EnemyName.Ingrar:
                PlayerPrefs.SetFloat(enemyName + "WantedPoster", currentDestroyed);
                PlayerPrefs.SetFloat(enemyName + "Spawned", 0);
                PlayerPrefs.SetFloat(enemyName + "TotalSpawned", 0);
                break;
            case EnemyName.Zarzog:
                PlayerPrefs.SetFloat(enemyName + "WantedPoster", currentDestroyed);
                PlayerPrefs.SetFloat(enemyName + "Spawned", 0);
                PlayerPrefs.SetFloat(enemyName + "TotalSpawned", 0);
                break;
            case EnemyName.Xenoria:
                PlayerPrefs.SetFloat(enemyName + "WantedPoster", currentDestroyed);
                PlayerPrefs.SetFloat(enemyName + "Spawned", 0);
                PlayerPrefs.SetFloat(enemyName + "TotalSpawned", 0);
                break;

            default:
                Debug.Log("Not an enemy");
                break;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
       
        spawner = GameObject.FindGameObjectWithTag("Spawner");
        nameText = transform.GetChild(0).GetChild(1).GetComponent<TextMeshProUGUI>();
        nameText.SetText(enemyName.ToString() + 's');
        addCompleted = false;
        levelComplete = false;
        if (GameObject.FindGameObjectWithTag("LevelCompletion") != null)
        {
            levelCompletion = GameObject.FindGameObjectWithTag("LevelCompletion");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (spawner.GetComponent<EnemySpawner>().AllEnemiesSpawned())
        {
            spawned = GameObject.FindGameObjectsWithTag("Enemy");
        }

        switch (enemyName)
        {

            case EnemyName.Goblin:
                Manager();
                break;
            case EnemyName.Orc:
                Manager();
                break;
            case EnemyName.Troll:
                Manager();
                break;
            case EnemyName.Skeleton:
                Manager();
                break;
            case EnemyName.Mushroom:
                Manager();
                break;
            case EnemyName.Lich:
                Manager();
                break;
            case EnemyName.Witch:
                Manager();
                break;
            case EnemyName.Vampire:
                Manager();
                break;
            case EnemyName.Derzin:
                Manager();
                break;
            case EnemyName.Ingrar:
                Manager();
                break;
            case EnemyName.Zarzog:
                Manager();
                break;
            case EnemyName.Xenoria:
                Manager();
                break;

            default:
                Debug.Log("Not an enemy");
                break;
        }


    }
    private void Manager()
    {
        text.SetText(PlayerPrefs.GetFloat(enemyName + "WantedPoster").ToString() + " / " + PlayerPrefs.GetFloat(enemyName + "Spawned").ToString());

        if (spawner.GetComponent<EnemySpawner>().AllEnemiesSpawned())
        {
            

            if (PlayerPrefs.GetFloat(enemyName + "WantedPoster") == PlayerPrefs.GetFloat(enemyName + "Spawned"))
            {
                levelComplete = true;
                //levelCompletion.GetComponent<LevelCompletion>().boardsCompleted++;
            }
        }
    }

}
