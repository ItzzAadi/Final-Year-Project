using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Sensors;
using UnityEngine.UIElements;

public class AgentAI : Agent{

    private GameManager _gameManager;
    public override void CollectObservations(VectorSensor sensor){
        sensor.AddObservation(transform.position);
    }

    public override void OnActionReceived(ActionBuffers actions){
        Debug.Log(actions.DiscreteActions[0]);
    }

}
