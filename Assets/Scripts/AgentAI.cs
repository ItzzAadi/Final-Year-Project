using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Sensors;
using UnityEngine.UIElements;
using UnityEngine.Assertions.Must;

public class AgentAI : Agent{

    private GameManager _gameManager;
    private DriveCar _carController;

    void Start(){
        _carController = GetComponent<DriveCar>();
    }
    public override void CollectObservations(VectorSensor sensor){
        sensor.AddObservation(transform.position);
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
    }

}
