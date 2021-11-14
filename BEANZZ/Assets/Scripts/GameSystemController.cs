using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameSystemController : MonoBehaviour
{
    public enum GameStates
    {
        Menu = 0,
        GamePlay,
        GamePause,
        GameOver,
        PlayerToGateCutScene,
        GateToPlayerCutScene,
        CutSceneLive,
        NumOfGameStates
    }


    [SerializeField] Canvas pauseCanvas;

    private GameStates newGameState = GameStates.Menu;
    private GameStates currentGameState = GameStates.Menu;
    private static GameSystemController instance;

    

    public static GameSystemController Instance
    {
        get
        {
            if(instance == null)
            {
                instance = GameObject.FindObjectOfType<GameSystemController>();
            }
            return instance;
        }
    }

    public GameStates NewGameState
    {
        get
        {
            return newGameState;
        }

        set
        {
            newGameState = value;
            HandleGameStateTransitions();
        }
    }

    public GameStates CurrentGameState { get => currentGameState; }

    private void Awake()
    {
        pauseCanvas.enabled = false;
        currentGameState = GameStates.GamePlay;
        newGameState = currentGameState;
        CameraDirector.Instance.SetCamera(CameraDirector.CameraList.FollowCam);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Things that happen repeatidly per state go here
        switch (currentGameState)
        {
            case GameStates.Menu:

                break;
            case GameStates.GamePlay:
                
                break;
            case GameStates.GamePause:
                break;
            case GameStates.GameOver:
                break;
            case GameStates.PlayerToGateCutScene:
                if (!CameraDirector.Instance.GetIsLive(CameraDirector.CameraList.FollowCam))
                
                {
                    NewGameState = GameStates.CutSceneLive;
                }
                break;
            case GameStates.GateToPlayerCutScene:
                if (!CameraDirector.Instance.GetIsLive(CameraDirector.CameraList.CutSceneCam))
                {
                    NewGameState = GameStates.GamePlay;
                }
                break;
            case GameStates.CutSceneLive:
                break;
            case GameStates.NumOfGameStates: //No break so flows into default
            default:
                //Do nothing
                break;
        }
    }

    private void HandleGameStateTransitions()
    {
        //Check for 1-off transition actions which should be performed immediatley
        //Update functionw will handle the cyclic state behaviors

        switch (currentGameState)
        {
            case GameStates.Menu:
                //Check transitions and execute transition actions
                if (NewGameState == GameStates.GamePlay)
                {
                    
                    //complete the transition
                    currentGameState = NewGameState;
                }
                else
                {
                    // no valid transitions
                    NewGameState = currentGameState;
                }

                break;
            case GameStates.GamePlay:

                if (NewGameState == GameStates.GameOver)
                {
                    
                    

                    currentGameState = NewGameState;
                }
                else if(NewGameState == GameStates.GamePause)
                {
                    GameObject[] helpers;
                    helpers = GameObject.FindGameObjectsWithTag("Helper");
                    foreach (GameObject helper in helpers)
                    {
                        helper.SendMessage("PauseHelper");
                    }
                    pauseCanvas.enabled = true;
                    currentGameState = NewGameState;
                }
                else if(NewGameState == GameStates.PlayerToGateCutScene)
                {
                    GameObject[] helpers;
                    helpers = GameObject.FindGameObjectsWithTag("Helper");
                    foreach (GameObject helper in helpers)
                    {
                        helper.SendMessage("PauseHelper");
                    }
                    currentGameState = NewGameState;
                }
                else
                {
                    NewGameState = currentGameState;
                }
                break;
            case GameStates.GamePause:
                if (NewGameState == GameStates.GamePlay)
                {
                    GameObject[] helpers;
                    helpers = GameObject.FindGameObjectsWithTag("Helper");
                    foreach (GameObject helper in helpers)
                    {
                        helper.SendMessage("ResumeHelper");
                    }
                    pauseCanvas.enabled = false;
                    currentGameState = NewGameState;
                }
                else
                {
                    NewGameState = currentGameState;
                }
                break;
           
            case GameStates.GameOver:

                if (NewGameState == GameStates.GamePlay)
                {
                    //hide the game over canvases
                    
                    currentGameState = NewGameState;
                }
                else if(NewGameState == GameStates.Menu)
                {
                    //hide the retry canvas
                   
                    currentGameState = NewGameState;
                }
                else
                {
                    // no valid transitions
                    NewGameState = currentGameState;
                }
                break;
            case GameStates.PlayerToGateCutScene:
                if(NewGameState == GameStates.CutSceneLive)
                {
                    
                    currentGameState = NewGameState;
                    
                }
                else
                {
                    NewGameState = currentGameState;
                }
                break;
            case GameStates.GateToPlayerCutScene:
                if (NewGameState == GameStates.GamePlay)
                {
                    GameObject[] helpers;
                    helpers = GameObject.FindGameObjectsWithTag("Helper");
                    foreach (GameObject helper in helpers)
                    {
                        helper.SendMessage("ResumeHelper");
                    }
                    currentGameState = NewGameState;
                }
                else
                {
                    NewGameState = currentGameState;
                }
                break;
            case GameStates.CutSceneLive:
                if (NewGameState == GameStates.GateToPlayerCutScene)
                {
                    CameraDirector.Instance.SetCamera(CameraDirector.CameraList.FollowCam);
                    currentGameState = NewGameState;

                }
                else
                {
                    NewGameState = currentGameState;
                }
                break;
            case GameStates.NumOfGameStates:
                break;
            default:
                break;
        }
        //Debug.Log("Current Game State: " + currentGameState.ToString());
    }

    public void RetryButtonPress()
    {
        if(currentGameState == GameStates.GameOver)
        {
            NewGameState = GameStates.GamePlay;
        }
        
    }

    public void ResumeButtonPress()
    {
        
    }

    public void GotoMenuButtonPress()
    {
        //goto main menu
        if(currentGameState == GameStates.GameOver)
        {
            NewGameState = GameStates.Menu;
        }
    }


    public void StartButtonPressed()
    {

        switch (currentGameState)
        {
            case GameStates.Menu:
                NewGameState = GameStates.GamePlay;
                break;
            case GameStates.GamePlay:
                NewGameState = GameStates.GamePause;
                break;
            case GameStates.GamePause:
                NewGameState = GameStates.GamePlay;
                break;
            case GameStates.GameOver:
                
                break;
            case GameStates.PlayerToGateCutScene:
                break;
            case GameStates.GateToPlayerCutScene:
                break;
            case GameStates.CutSceneLive:
                break;
            case GameStates.NumOfGameStates: //removed break so that it will flow to default
            default:
                break;
        }
    }    
}
