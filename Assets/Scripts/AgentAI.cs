using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Sensors;
using UnityEngine.UIElements;
using UnityEngine.Assertions.Must;
using System.Numerics;

public class AgentAI : Agent{

    private GameManager _gameManager;
    private DriveCar _carController;
    private FuelController _fuelController;
    private UnityEngine.Vector2 _initialPosition;
    private bool episodeEnded = false;

    void Start(){
        _carController = GetComponent<DriveCar>();
        _gameManager = FindAnyObjectByType<GameManager>();
        _fuelController = FindObjectOfType<FuelController>();
        _initialPosition = transform.localPosition;
    }

    public override void OnEpisodeBegin(){
        Debug.Log("New Episode Started");
        episodeEnded = false;
        _initialPosition = transform.localPosition;


        //_fuelController.FillFuel();
        if(_gameManager == null){
            Debug.Log("Game Manager is null");
            _gameManager = FindAnyObjectByType<GameManager>();
            Debug.Log("Found Object GameManager");
        }
    }
    public override void CollectObservations(VectorSensor sensor){
        UnityEngine.Vector2 _relativePosition = (UnityEngine.Vector2)transform.localPosition - _initialPosition;
        sensor.AddObservation(_relativePosition);
    }

    public override void OnActionReceived(ActionBuffers actions){
        Debug.Log(actions.DiscreteActions[0]);
        float _moveAction = actions.DiscreteActions[0];
        if(_moveAction == 0){
            _carController.Move(-1f);
        }
        else if (_moveAction == 1){
            _carController.Move(1f);
        }

        float _distanceTraveled = transform.localPosition.x - _initialPosition.x;
        if(_distanceTraveled >= 1.0f && !episodeEnded){
            SetReward(1.0f);
            _initialPosition = transform.localPosition;
            //episodeEnded = true;
            //EndEpisode();
        }
        else if (_distanceTraveled <0f){
            SetReward(-0.5f);
        }
        if(_fuelController.GetCurrentFuel() <= 0f & !episodeEnded){
            episodeEnded = true;
            Debug.Log("Episode ended");
            EndEpisode();
            _gameManager.RestartGame();
            Debug.Log("Game Manager Restart Game is called");
        }
    }

}
