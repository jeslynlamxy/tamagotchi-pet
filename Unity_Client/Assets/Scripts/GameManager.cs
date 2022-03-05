// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class GameManager : MonoBehaviour
// {
//     public static GameManager Instance;
//     public GameState State;
//     public static event Action<GameState> OnGameStateChanged;

//     void Awake() {
//         Instance=this;

//     }

//     void Start() {
//         UpdateGameState(OnGameStateChanged.MultiOrSingle);
//     }

//     public void UpdateGameState(GameState newState) {
//         State = newState;

//         switch (newState){

//             case GameState.MultiOrSingle:
//             HandleMultiOrSingle();
//             break;

//             case GameState.WorldAndStage:
//             break;

//             case GameState.Character:
//             break;

//             case GameState.SinglePlayerGame:
//             break;

//             case GameState.MissionComplete:
//             break;

//             case GameState.MultiPlayerGame:
//             break;

//             case GameState.MissionVictory:
//             break;

//             case GameState.MissionDefeat:
//             break;

//             default: 
//                 throw new ArgumentOutOfRangeException(nameof(newState), newState, null);


//         }

//         OnGameStateChanged?.Invoke(newState);

//     }

//     private void HandleMultiOrSingle() {
//         // allow user to switch btwn multi and single
//     }


//     private void HandleMissionComplete() {
//         // show mission complete screen
//     }

//     private async void HandleDecide() {
//         // if end game no more lifes

//         // if end game no more questions

//     }

// }

// public enum GameState {
//     MultiOrSingle,
//     WorldAndStage,
//     Character,
//     SinglePlayerGame,
//     MissionComplete,
//     MultiPlayerGame,
//     MissionVictory,
//     MissionDefeat
// }