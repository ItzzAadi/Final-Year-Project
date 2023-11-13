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
    private UnityEngine.Vector2 _initialPosition;
    private bool episodeEnded = false;

    void Start(){
        _carController = GetComponent<DriveCar>();
        _initialPosition = transform.position;
    }

    public override void OnEpisodeBegin(){
        episodeEnded = false;
        _initialPosition = transform.position;
    }
    public override void CollectObservations(VectorSensor sensor){
        UnityEngine.Vector2 _relativePosition = (UnityEngine.Vector2)transform.position - _initialPosition;
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

        float _distanceTraveled = transform.position.x - _initialPosition.x;
        if(_distanceTraveled >= 1.0f && !episodeEnded){
            SetReward(1.0f);
            episodeEnded = true;
            EndEpisode();
        }
        else if (_distanceTraveled <0f){
            SetReward(-0.5f);
        }
    }

}
