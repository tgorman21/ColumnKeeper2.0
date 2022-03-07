using System.Collections;
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
    GameObject levelCompletion;
    bool addCompleted;
    GameObject spawner;

    private void Awake()
    {
        float currentDestroyed = 0;

        switch (enemyName)
        {

            case EnemyName.Goblin:
                PlayerPrefs.SetFloat(enemyName + "WantedPoster", currentDestroyed);
                PlayerPrefs.SetFloat(enemyName + "Spawned", 0);

                break;
            case EnemyName.Orc:
                PlayerPrefs.SetFloat(enemyName + "WantedPoster", currentDestroyed);
                PlayerPrefs.SetFloat(enemyName + "Spawned", 0);

                break;
            case EnemyName.Troll:
                PlayerPrefs.SetFloat(enemyName + "WantedPoster", currentDestroyed);
                PlayerPrefs.SetFloat(enemyName + "Spawned", 0);

                break;
            case EnemyName.Skeleton:
                PlayerPrefs.SetFloat(enemyName + "WantedPoster", currentDestroyed);
                PlayerPrefs.SetFloat(enemyName + "Spawned", 0);

                break;
            case EnemyName.Mushroom:
                PlayerPrefs.SetFloat(enemyName + "WantedPoster", currentDestroyed);
                PlayerPrefs.SetFloat(enemyName + "Spawned", 0);

                break;
            case EnemyName.Lich:
                PlayerPrefs.SetFloat(enemyName + "WantedPoster", currentDestroyed);
                PlayerPrefs.SetFloat(enemyName + "Spawned", 0);

                break;
            case EnemyName.Witch:
                PlayerPrefs.SetFloat(enemyName + "WantedPoster", currentDestroyed);
                PlayerPrefs.SetFloat(enemyName + "Spawned", 0);

                break;
            case EnemyName.Vampire:
                PlayerPrefs.SetFloat(enemyName + "WantedPoster", currentDestroyed);
                PlayerPrefs.SetFloat(enemyName + "Spawned", 0);

                break;
            case EnemyName.Derzin:
                PlayerPrefs.SetFloat(enemyName + "WantedPoster", currentDestroyed);
                PlayerPrefs.SetFloat(enemyName + "Spawned", 0);

                break;
            case EnemyName.Ingrar:
                PlayerPrefs.SetFloat(enemyName + "WantedPoster", currentDestroyed);
                PlayerPrefs.SetFloat(enemyName + "Spawned", 0);

                break;
            case EnemyName.Zarzog:
                PlayerPrefs.SetFloat(enemyName + "WantedPoster", currentDestroyed);
                PlayerPrefs.SetFloat(enemyName + "Spawned", 0);

                break;
            case EnemyName.Xenoria:
                PlayerPrefs.SetFloat(enemyName + "WantedPoster", currentDestroyed);
                PlayerPrefs.SetFloat(enemyName + "Spawned", 0);

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

        switch (enemyName)
        {
            case EnemyName.Goblin:
                text.SetText(PlayerPrefs.GetFloat(enemyName + "WantedPoster").ToString() + " / " + PlayerPrefs.GetFloat(enemyName + "Spawned").ToString());
                if(PlayerPrefs.GetFloat(enemyName + "WantedPoster") == spawner.GetComponent<EnemySpawner>().amountOfEnemiesSpawned)
                {
                    levelComplete = true;
                    //levelCompletion.GetComponent<LevelCompletion>().boardsCompleted++;
                }
                break;
            case EnemyName.Orc:
                text.SetText(PlayerPrefs.GetFloat(enemyName + "WantedPoster").ToString() + " / " + PlayerPrefs.GetFloat(enemyName + "Spawned").ToString());
                if (PlayerPrefs.GetFloat(enemyName + "WantedPoster") == spawner.GetComponent<EnemySpawner>().amountOfEnemiesSpawned)
                {
                    levelComplete = true;
                    //levelCompletion.GetComponent<LevelCompletion>().boardsCompleted++;
                }
                break;
            case EnemyName.Troll:
                text.SetText(PlayerPrefs.GetFloat(enemyName + "WantedPoster").ToString() + " / " + PlayerPrefs.GetFloat(enemyName + "Spawned").ToString());
                if (PlayerPrefs.GetFloat(enemyName + "WantedPoster") == spawner.GetComponent<EnemySpawner>().amountOfEnemiesSpawned)
                {
                    levelComplete = true;
                    //levelCompletion.GetComponent<LevelCompletion>().boardsCompleted++;
                }
                break;
            case EnemyName.Skeleton:
                text.SetText(PlayerPrefs.GetFloat(enemyName + "WantedPoster").ToString() + " / " + PlayerPrefs.GetFloat(enemyName + "Spawned").ToString());
                if (PlayerPrefs.GetFloat(enemyName + "WantedPoster") == spawner.GetComponent<EnemySpawner>().amountOfEnemiesSpawned)
                {
                    levelComplete = true;
                    //levelCompletion.GetComponent<LevelCompletion>().boardsCompleted++;
                }
                break;
            case EnemyName.Mushroom:
                text.SetText(PlayerPrefs.GetFloat(enemyName + "WantedPoster").ToString() + " / " + PlayerPrefs.GetFloat(enemyName + "Spawned").ToString());
                if (PlayerPrefs.GetFloat(enemyName + "WantedPoster") == spawner.GetComponent<EnemySpawner>().amountOfEnemiesSpawned)
                {
                    levelComplete = true;
                    //levelCompletion.GetComponent<LevelCompletion>().boardsCompleted++;
                }
                break;
            case EnemyName.Lich:
                text.SetText(PlayerPrefs.GetFloat(enemyName + "WantedPoster").ToString() + " / " + PlayerPrefs.GetFloat(enemyName + "Spawned").ToString());
                if (PlayerPrefs.GetFloat(enemyName + "WantedPoster") == spawner.GetComponent<EnemySpawner>().amountOfEnemiesSpawned)
                {
                    levelComplete = true;
                    //levelCompletion.GetComponent<LevelCompletion>().boardsCompleted++;
                }
                break;
            case EnemyName.Witch:
                text.SetText(PlayerPrefs.GetFloat(enemyName + "WantedPoster").ToString() + " / " + PlayerPrefs.GetFloat(enemyName + "Spawned").ToString());
                if (PlayerPrefs.GetFloat(enemyName + "WantedPoster") == spawner.GetComponent<EnemySpawner>().amountOfEnemiesSpawned)
                {
                    levelComplete = true;
                    //levelCompletion.GetComponent<LevelCompletion>().boardsCompleted++;
                }
                break;
            case EnemyName.Vampire:
                text.SetText(PlayerPrefs.GetFloat(enemyName + "WantedPoster").ToString() + " / " + PlayerPrefs.GetFloat(enemyName + "Spawned").ToString());
                if (PlayerPrefs.GetFloat(enemyName + "WantedPoster") == spawner.GetComponent<EnemySpawner>().amountOfEnemiesSpawned)
                {
                    levelComplete = true;
                    //levelCompletion.GetComponent<LevelCompletion>().boardsCompleted++;
                }
                break;
            case EnemyName.Derzin:
                text.SetText(PlayerPrefs.GetFloat(enemyName + "WantedPoster").ToString() + " / " + PlayerPrefs.GetFloat(enemyName + "Spawned").ToString());
                if (PlayerPrefs.GetFloat(enemyName + "WantedPoster") == spawner.GetComponent<EnemySpawner>().amountOfEnemiesSpawned)
                {
                    levelComplete = true;
                    //levelCompletion.GetComponent<LevelCompletion>().boardsCompleted++;
                }
                break;
            case EnemyName.Ingrar:
                text.SetText(PlayerPrefs.GetFloat(enemyName + "WantedPoster").ToString() + " / " + PlayerPrefs.GetFloat(enemyName + "Spawned").ToString());
                if (PlayerPrefs.GetFloat(enemyName + "WantedPoster") == PlayerPrefs.GetFloat(enemyName + "Spawned"))
                {
                    levelComplete = true;
                }
                break;
            case EnemyName.Zarzog:
                text.SetText(PlayerPrefs.GetFloat(enemyName + "WantedPoster").ToString() + " / " + PlayerPrefs.GetFloat(enemyName + "Spawned").ToString());
                if (PlayerPrefs.GetFloat(enemyName + "WantedPoster") == spawner.GetComponent<EnemySpawner>().amountOfEnemiesSpawned)
                {
                    levelComplete = true;
                    //levelCompletion.GetComponent<LevelCompletion>().boardsCompleted++;
                }
                break;
            case EnemyName.Xenoria:
                text.SetText(PlayerPrefs.GetFloat(enemyName + "WantedPoster").ToString() + " / " + PlayerPrefs.GetFloat(enemyName + "Spawned").ToString());
                if (PlayerPrefs.GetFloat(enemyName + "WantedPoster") == spawner.GetComponent<EnemySpawner>().amountOfEnemiesSpawned)
                {
                    levelComplete = true;
                    //levelCompletion.GetComponent<LevelCompletion>().boardsCompleted++;
                }
                break;

            default:
                Debug.Log("Not an enemy");
                break;
        }


    }
    
}
