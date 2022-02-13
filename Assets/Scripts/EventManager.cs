using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using CodeMonkey.Utils;

public class EventManager : MonoBehaviour
{
    public bool scene1Active;
    public bool scene2Active;
    public bool scene3Active;
    public bool scene4Active;
    public bool scene5Active;

    public GameObject loadingPlayer;

    public GameObject fadeEffects;
    public GameObject wheelScreen;
    GameObject MainCamera;
    GameObject Speaks;
    GameObject UI;
    GameObject UI_Buttons;
    GameObject improveScreen;
    GameObject blackScreenBetweenScenes;
    GameObject readyScreen;

    GameObject cronometer;
    public GameObject roundsObject;

    GameObject blackscreenOn;
    GameObject blackscreenOff;
    GameObject blackscreenFULL;
    GameObject endGamePanel;

    public GameObject spawnsParentGameobject;
    public GameObject pointsCounter;
    public GameObject endGameScreen;

    GameObject spawnPlayer1;
    GameObject spawnPlayer2;
    GameObject spawnPlayer3;
    GameObject spawnPlayer4;
    GameObject spawnPlayer5;

    public GameObject roundNUM;
    public GameObject[] enemiesArray;

    bool done;
    public bool roundEnds;
    bool onClick;
    public bool timeStops;

    public float minutes;
    public float seconds;
    public int round;
    public float enemyKills;

    private void Awake()
    {
        fadeEffects = GameObject.Find("FadeEffects");
        MainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        Speaks = MyUtils.FindIncludingInactive("Speaks");
        UI = GameObject.Find("Interface");
        UI_Buttons = MyUtils.FindInChildrenIncludingInactive(UI, "UI - Button Layer");
        improveScreen = MyUtils.FindInChildrenIncludingInactive(UI, "Fortune Wheel Window");
        blackScreenBetweenScenes = MyUtils.FindInChildrenIncludingInactive(UI, "UI").transform.Find("BlackScreenLoading").transform.gameObject;
        cronometer = MyUtils.FindInChildrenIncludingInactive(UI, "UI").transform.Find("Round Texts").transform.Find("Crono").transform.Find("Cronometer").transform.gameObject;
        blackscreenOn = MyUtils.FindInChildrenIncludingInactive(fadeEffects, "BlackScreenOn");
        blackscreenOff = MyUtils.FindInChildrenIncludingInactive(fadeEffects, "BlackScreenOff");
        blackscreenFULL = MyUtils.FindInChildrenIncludingInactive(fadeEffects, "BlackScreenFull");
        readyScreen = MyUtils.FindInChildrenIncludingInactive(UI, "UI").transform.Find("ReadyScreen").transform.gameObject;
        endGamePanel = MyUtils.FindInChildrenIncludingInactive(UI, "EndGame");
        spawnPlayer1 = GameObject.FindGameObjectWithTag("PlayerSpawn1");
        spawnPlayer2 = GameObject.FindGameObjectWithTag("PlayerSpawn2");
        spawnPlayer3 = GameObject.FindGameObjectWithTag("PlayerSpawn3");
        spawnPlayer4 = GameObject.FindGameObjectWithTag("PlayerSpawn4");
        spawnPlayer5 = GameObject.FindGameObjectWithTag("PlayerSpawn5");

        scene1Active = System.Convert.ToBoolean(PlayerPrefs.GetString("Scene1"));
        scene2Active = System.Convert.ToBoolean(PlayerPrefs.GetString("Scene2"));
        scene3Active = System.Convert.ToBoolean(PlayerPrefs.GetString("Scene3"));
        scene4Active = System.Convert.ToBoolean(PlayerPrefs.GetString("Scene4"));
        scene5Active = System.Convert.ToBoolean(PlayerPrefs.GetString("Scene5"));

        PlayerPrefs.SetString("UnlockL2", false.ToString());

        timeStops = true;

        if (scene1Active)
        {
            MyUtils.FindInChildrenIncludingInactive(loadingPlayer, "Standard").SetActive(true);
            MyUtils.FindInChildrenIncludingInactive(loadingPlayer, "Standard").transform.position = spawnPlayer1.transform.position;
        }

        if (scene2Active)
        {
            MyUtils.FindInChildrenIncludingInactive(loadingPlayer, "Scientist").SetActive(true);
            MyUtils.FindInChildrenIncludingInactive(loadingPlayer, "Scientist").transform.position = spawnPlayer2.transform.position;
        }

        if (scene3Active)
        {
            MyUtils.FindInChildrenIncludingInactive(loadingPlayer, "Nun").SetActive(true);
            MyUtils.FindInChildrenIncludingInactive(loadingPlayer, "Nun").transform.position = spawnPlayer3.transform.position;
        }

        if (scene4Active)
        {
            MyUtils.FindInChildrenIncludingInactive(loadingPlayer, "PoliceAgent").SetActive(true);
            MyUtils.FindInChildrenIncludingInactive(loadingPlayer, "PoliceAgent").transform.position = spawnPlayer4.transform.position;
        }

        if (scene5Active)
        {
            MyUtils.FindInChildrenIncludingInactive(loadingPlayer, "Punk").SetActive(true);
            MyUtils.FindInChildrenIncludingInactive(loadingPlayer, "Punk").transform.position = spawnPlayer5.transform.position;
        }
    }

    // Start is called before the first frame update
    void Start()
    {

        if (scene1Active)
        {
            StartCoroutine(Spawn_L1());
        }

        if (scene2Active)
        {
            StartCoroutine(Spawn_L2());
        }

        if (scene3Active)
        {
            StartCoroutine(Spawn_L3());
        }

        if (scene4Active)
        {
            StartCoroutine(Spawn_L4());
        }

        if (scene5Active)
        {
            StartCoroutine(Spawn_L5());
        }
    }

    // Update is called once per frame
    void Update()
    {
        enemiesArray = GameObject.FindGameObjectsWithTag("Enemy");
        roundsObject.GetComponent<Text>().text = "Oleada " + roundsObject.GetComponent<RoundCount>().roundNum;

        Cronometer();

        roundCounter(scene1Active);
        roundCounter2(scene2Active);
        roundCounter3(scene3Active);
        roundCounter4(scene4Active);
        roundCounter5(scene5Active);

        if (endGameScreen.activeInHierarchy)
        {
            endGameScreen.transform.Find("KilledEnemies").transform.GetComponent<Text>().text = "Enemigos eliminados = " + enemyKills;
            endGameScreen.transform.Find("Points").transform.GetComponent<Text>().text = "Puntos = " + enemyKills * 10;

            if (scene1Active)
            {
                endGameScreen.transform.Find("Text").transform.GetComponent<Text>().text = "Nivel 1 Completado";
                if (PlayerPrefs.GetString("UnlockL2") != true.ToString())
                {
                    endGameScreen.transform.Find("Unlock").transform.GetComponent<Text>().text = "Nivel 2 desbloqueado";
                }
            }

            if (scene2Active)
            {
                endGameScreen.transform.Find("Text").transform.GetComponent<Text>().text = "Nivel 2 Completado";
                if (PlayerPrefs.GetString("UnlockL3") != true.ToString())
                {
                    endGameScreen.transform.Find("Unlock").transform.GetComponent<Text>().text = "Nivel 3 desbloqueado";
                }
            }

            if (scene3Active)
            {
                endGameScreen.transform.Find("Text").transform.GetComponent<Text>().text = "Nivel 3 Completado";
                if (PlayerPrefs.GetString("UnlockL4") != true.ToString())
                {
                    endGameScreen.transform.Find("Unlock").transform.GetComponent<Text>().text = "Nivel 4 desbloqueado";
                }
            }

            if (scene4Active)
            {
                endGameScreen.transform.Find("Text").transform.GetComponent<Text>().text = "Nivel 4 Completado";
                if (PlayerPrefs.GetString("UnlockL5") != true.ToString())
                {
                    endGameScreen.transform.Find("Unlock").transform.GetComponent<Text>().text = "Nivel 5 desbloqueado";
                }
            }

            if (scene5Active)
            {
                endGameScreen.transform.Find("Text").transform.GetComponent<Text>().text = "Nivel 5 Completado";
            }


        }
    }

    void EnemyManager()
    {
        foreach (GameObject enemy in enemiesArray)
        {
            if(enemy.GetComponent<HealthScript>().health <= 0)
            {
                enemy.SetActive(false);
                enemyKills += 1;
            }
            
        }

        for (int i = 0; i < spawnsParentGameobject.transform.childCount; i++)
        {
            var child = spawnsParentGameobject.transform.GetChild(i).gameObject;
            if (child != null)
                child.SetActive(false);
        }

    }

    private void LateUpdate()
    {
        LevelFinished();

        if(round > 1)
        {
            blackscreenOff.SetActive(false);
            blackscreenOn.SetActive(false);
        }
    }

    void UI_Active()
    {
        UI.transform.Find("Tutorial").gameObject.SetActive(false);
        Destroy(UI.transform.Find("Tutorial").gameObject);
        UI_Buttons.SetActive(true);
        UI.transform.Find("UI").GetComponent<CanvasGroup>().alpha = 1f;
        UI_Buttons.GetComponent<CanvasGroup>().alpha = 1f;
    }

    IEnumerator TutFinished()
    {
        UI.transform.Find("Tutorial").GetComponent<Animator>().SetTrigger("TutorialEnded");
        yield return new WaitForSecondsRealtime(1);
        UI_Active();
        scene1Active = false;
    }

    void LevelFinished()
    {
        if (GameObject.Find("Endline").GetComponent<DerivedEvent>().levelFinished)
        {
            Debug.Log("Salta");
            blackscreenOn.SetActive(true);
            fadeEffects.GetComponent<Animator>().SetBool("In", true);

            blackscreenOn.transform.Find("Panel").GetComponent<Button_UI>().ClickFunc = () =>
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            };
        }
    }

    public IEnumerator Spawn_L1()
    {
        if(round <= 1)
        {
            //Fundido hacia fuera
            fadeEffects.GetComponent<Animator>().SetBool("Out", true);
            yield return new WaitUntil(() => !blackscreenOff.activeInHierarchy);
            //Aparece el texto oleada
            roundsObject.GetComponent<Animator>().SetBool("RoundActive", true);
            yield return new WaitForSeconds(2.55f);
            roundsObject.GetComponent<Animator>().SetBool("RoundActive", false);
            //Aparece la UI
            UI.GetComponent<Animator>().SetTrigger("Begins");
            //Indicamos el tiempo del reloj
            minutes = 2;
            seconds = 0;
            //Aparece el reloj
            cronometer.GetComponent<Animator>().SetBool("TimeOn", true);
            //Empieza la cuenta-atrás
            timeStops = false;
        }
        else if(round > 1)
        {
            //Sacamos texto de oleada
            roundsObject.GetComponent<Animator>().SetBool("RoundActive", true);
            yield return new WaitForSeconds(2.55f);
            roundsObject.GetComponent<Animator>().SetBool("RoundActive", false);
            //Indicamos el tiempo del reloj
            minutes = 2;
            seconds = 0;
            //Aparece el reloj
            cronometer.GetComponent<Animator>().SetBool("TimeOn", true);
            //Empieza la cuenta-atrás
            timeStops = false;
        }
        
    }

    IEnumerator RoundCoroutine()
    {
        roundsObject.GetComponent<Animator>().SetBool("RoundActive", true);
        yield return new WaitForSeconds(2.55f);
        roundsObject.GetComponent<Animator>().SetBool("RoundActive", false);
    }

    IEnumerator Spawn_L2()
    {
        if (round <= 1)
        {
            //Fundido hacia fuera
            fadeEffects.GetComponent<Animator>().SetBool("Out", true);
            yield return new WaitUntil(() => !blackscreenOff.activeInHierarchy);
            //Aparece el texto oleada
            roundsObject.GetComponent<Animator>().SetBool("RoundActive", true);
            yield return new WaitForSeconds(2.55f);
            roundsObject.GetComponent<Animator>().SetBool("RoundActive", false);
            //Aparece la UI
            UI.GetComponent<Animator>().SetTrigger("Begins");
            //Indicamos el tiempo del reloj
            minutes = 2;
            seconds = 0;
            //Aparece el reloj
            cronometer.GetComponent<Animator>().SetBool("TimeOn", true);
            //Empieza la cuenta-atrás
            timeStops = false;
        }
        else if (round > 1)
        {
            //Sacamos texto de oleada
            roundsObject.GetComponent<Animator>().SetBool("RoundActive", true);
            yield return new WaitForSeconds(2.55f);
            roundsObject.GetComponent<Animator>().SetBool("RoundActive", false);
            //Indicamos el tiempo del reloj
            minutes = 2;
            seconds = 0;
            //Aparece el reloj
            cronometer.GetComponent<Animator>().SetBool("TimeOn", true);
            //Empieza la cuenta-atrás
            timeStops = false;
        }
    }

    IEnumerator Spawn_L3()
    {
        if (round <= 1)
        {
            //Fundido hacia fuera
            fadeEffects.GetComponent<Animator>().SetBool("Out", true);
            yield return new WaitUntil(() => !blackscreenOff.activeInHierarchy);
            //Aparece el texto oleada
            roundsObject.GetComponent<Animator>().SetBool("RoundActive", true);
            yield return new WaitForSeconds(2.55f);
            roundsObject.GetComponent<Animator>().SetBool("RoundActive", false);
            //Aparece la UI
            UI.GetComponent<Animator>().SetTrigger("Begins");
            //Indicamos el tiempo del reloj
            minutes = 2;
            seconds = 0;
            //Aparece el reloj
            cronometer.GetComponent<Animator>().SetBool("TimeOn", true);
            //Empieza la cuenta-atrás
            timeStops = false;
        }
        else if (round > 1)
        {
            //Sacamos texto de oleada
            roundsObject.GetComponent<Animator>().SetBool("RoundActive", true);
            yield return new WaitForSeconds(2.55f);
            roundsObject.GetComponent<Animator>().SetBool("RoundActive", false);
            //Indicamos el tiempo del reloj
            minutes = 2;
            seconds = 0;
            //Aparece el reloj
            cronometer.GetComponent<Animator>().SetBool("TimeOn", true);
            //Empieza la cuenta-atrás
            timeStops = false;
        }
    }

    IEnumerator Spawn_L4()
    {
        if (round <= 1)
        {
            //Fundido hacia fuera
            fadeEffects.GetComponent<Animator>().SetBool("Out", true);
            yield return new WaitUntil(() => !blackscreenOff.activeInHierarchy);
            //Aparece el texto oleada
            roundsObject.GetComponent<Animator>().SetBool("RoundActive", true);
            yield return new WaitForSeconds(2.55f);
            roundsObject.GetComponent<Animator>().SetBool("RoundActive", false);
            //Aparece la UI
            UI.GetComponent<Animator>().SetTrigger("Begins2");
            //Indicamos el tiempo del reloj
            minutes = 2;
            seconds = 0;
            //Aparece el reloj
            cronometer.GetComponent<Animator>().SetBool("TimeOn", true);
            //Empieza la cuenta-atrás
            timeStops = false;
        }
        else if (round > 1)
        {
            //Sacamos texto de oleada
            roundsObject.GetComponent<Animator>().SetBool("RoundActive", true);
            yield return new WaitForSeconds(2.55f);
            roundsObject.GetComponent<Animator>().SetBool("RoundActive", false);
            //Indicamos el tiempo del reloj
            minutes = 2;
            seconds = 0;
            //Aparece el reloj
            cronometer.GetComponent<Animator>().SetBool("TimeOn", true);
            //Empieza la cuenta-atrás
            timeStops = false;
        }
    }

    IEnumerator Spawn_L5()
    {
        if (round <= 1)
        {
            //Fundido hacia fuera
            fadeEffects.GetComponent<Animator>().SetBool("Out", true);
            yield return new WaitUntil(() => !blackscreenOff.activeInHierarchy);
            //Aparece el texto oleada
            roundsObject.GetComponent<Animator>().SetBool("RoundActive", true);
            yield return new WaitForSeconds(2.55f);
            roundsObject.GetComponent<Animator>().SetBool("RoundActive", false);
            //Aparece la UI
            UI.GetComponent<Animator>().SetTrigger("Begins2");
            //Indicamos el tiempo del reloj
            minutes = 2;
            seconds = 0;
            //Aparece el reloj
            cronometer.GetComponent<Animator>().SetBool("TimeOn", true);
            //Empieza la cuenta-atrás
            timeStops = false;
        }
        else if (round > 1)
        {
            //Sacamos texto de oleada
            roundsObject.GetComponent<Animator>().SetBool("RoundActive", true);
            yield return new WaitForSeconds(2.55f);
            roundsObject.GetComponent<Animator>().SetBool("RoundActive", false);
            //Indicamos el tiempo del reloj
            minutes = 2;
            seconds = 0;
            //Aparece el reloj
            cronometer.GetComponent<Animator>().SetBool("TimeOn", true);
            //Empieza la cuenta-atrás
            timeStops = false;
        }
    }

    IEnumerator WaitForPlay()
    {
        yield return new WaitForSecondsRealtime(5.0f);
        UI.transform.Find("Tutorial").gameObject.SetActive(true);
        UI.transform.Find("Tutorial").transform.Find("First").transform.Find("Image").GetComponent<Button_UI>().ClickFunc = () =>
        {
            //Gameplay begins
            StartCoroutine(TutFinished());

        };
    }

    void Cronometer()
    {
        if (!timeStops)
        {
            cronometer.GetComponent<Text>().text = "0" + minutes + ":" + seconds.ToString("f0");
            //StartCoroutine(Timer());
            seconds -= Time.deltaTime;

            if (seconds < 9.39f)
            {
                cronometer.GetComponent<Text>().text = "0" + minutes + ":" + "0" + seconds.ToString("f0");
            }

            if (seconds <= 0 && minutes != 0)
            {
                minutes -= 1;
                seconds = 59;
            }

            if (minutes == 0 && seconds <= 0.99f)
            {
                minutes = 0;
                seconds = 0;

                //Siguiente ronda
            }
        }
        
    }

    IEnumerator Timer()
    {
        yield return new WaitForSeconds(1.0f);
        seconds--;
        StopCoroutine(Timer());
    }

    void EndGame()
    {
        foreach (GameObject item in enemiesArray)
        {
            item.GetComponent<AI_Navigation>().distance = 1000;
            item.GetComponent<AI_Navigation>().playerTrans = null;
            item.GetComponent<Animator>().SetBool("Punch", false);
            item.GetComponent<NavMeshAgent>().isStopped = true;
        }
    }

    void roundCounter(bool beginLevel1)
    {
        if (beginLevel1)
        {
            if (minutes <= 0 && seconds <= 0)
            {
                if(roundsObject.GetComponent<RoundCount>().roundNum <= 5)
                {
                    Debug.Log("Ronda terminada");
                    //Paramos el tiempo
                    timeStops = true;
                    //Esperando siguiente oleada
                    StartCoroutine(BetweenScenes());
                    //Eliminar los enemigos que quedan por el lugar
                    EnemyManager();
                    for (int i = 0; i < spawnsParentGameobject.transform.childCount; i++)
                    {
                        var child = spawnsParentGameobject.transform.GetChild(i).gameObject;
                        if (child != null)
                            child.SetActive(true);
                    }
                    //Nueva ronda
                    StartCoroutine(Spawn_L1());
                }
                else
                {
                    Debug.Log("Partida terminada");
                    EndGame();
                    UI.GetComponent<Animator>().SetTrigger("End");
                }
                
            }
        }
        
    }

    IEnumerator BetweenScenes()
    {
        roundNUM.GetComponent<Text>().color = Color.white;
        yield return new WaitForSeconds(5);
        roundNUM.GetComponent<Text>().color = Color.clear;
    }

    void roundCounter2(bool beginLevel2)
    {
        if (beginLevel2)
        {
            if (minutes <= 0 && seconds <= 0)
            {
                if (roundNUM.GetComponent<RoundCount>().roundNum <= 5)
                {
                    Debug.Log("Ronda terminada");
                    //Paramos el tiempo
                    timeStops = true;
                    //Eliminar los enemigos que quedan por el lugar
                    EnemyManager();
                    //Generar nuevos enemigos
                    for (int i = 0; i < spawnsParentGameobject.transform.childCount; i++)
                    {
                        var child = spawnsParentGameobject.transform.GetChild(i).gameObject;
                        if (child != null)
                            child.SetActive(true);
                    }
                    //Nueva ronda
                    StartCoroutine(Spawn_L1());
                }
                else
                {
                    Debug.Log("Partida terminada");
                    EndGame();
                    UI.GetComponent<Animator>().SetTrigger("End");
                }

            }
        }

    }

    void roundCounter3(bool beginLevel3)
    {
        if (beginLevel3)
        {
            if (minutes <= 0 && seconds <= 0)
            {
                if (roundNUM.GetComponent<RoundCount>().roundNum <= 5)
                {
                    Debug.Log("Ronda terminada");
                    //Paramos el tiempo
                    timeStops = true;
                    //Eliminar los enemigos que quedan por el lugar
                    EnemyManager();
                    //Generar nuevos enemigos
                    for (int i = 0; i < spawnsParentGameobject.transform.childCount; i++)
                    {
                        var child = spawnsParentGameobject.transform.GetChild(i).gameObject;
                        if (child != null)
                            child.SetActive(true);
                    }
                    //Nueva ronda
                    StartCoroutine(Spawn_L1());
                }
                else
                {
                    Debug.Log("Partida terminada");
                    EndGame();
                    UI.GetComponent<Animator>().SetTrigger("End");
                }

            }
        }

    }

    void roundCounter4(bool beginLevel4)
    {
        if (beginLevel4)
        {
            if (minutes <= 0 && seconds <= 0)
            {
                if (roundNUM.GetComponent<RoundCount>().roundNum <= 5)
                {
                    Debug.Log("Ronda terminada");
                    //Paramos el tiempo
                    timeStops = true;
                    //Eliminar los enemigos que quedan por el lugar
                    EnemyManager();
                    //Generar nuevos enemigos
                    for (int i = 0; i < spawnsParentGameobject.transform.childCount; i++)
                    {
                        var child = spawnsParentGameobject.transform.GetChild(i).gameObject;
                        if (child != null)
                            child.SetActive(true);
                    }
                    //Nueva ronda
                    StartCoroutine(Spawn_L1());
                }
                else
                {
                    Debug.Log("Partida terminada");
                    EndGame();
                    UI.GetComponent<Animator>().SetTrigger("End");
                }

            }
        }

    }

    void roundCounter5(bool beginLevel5)
    {
        if (beginLevel5)
        {
            if (minutes <= 0 && seconds <= 0)
            {
                if (roundNUM.GetComponent<RoundCount>().roundNum <= 5)
                {
                    Debug.Log("Ronda terminada");
                    //Paramos el tiempo
                    timeStops = true;
                    //Eliminar los enemigos que quedan por el lugar
                    EnemyManager();
                    //Generar nuevos enemigos
                    for (int i = 0; i < spawnsParentGameobject.transform.childCount; i++)
                    {
                        var child = spawnsParentGameobject.transform.GetChild(i).gameObject;
                        if (child != null)
                            child.SetActive(true);
                    }
                    //Nueva ronda
                    StartCoroutine(Spawn_L1());
                }
                else
                {
                    Debug.Log("Partida terminada");
                    EndGame();
                    UI.GetComponent<Animator>().SetTrigger("End");
                }

            }
        }

    }
}
