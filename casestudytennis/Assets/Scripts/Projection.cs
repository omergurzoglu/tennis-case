using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Projection : MonoBehaviour
{
    private Scene _simulationScene;
    private PhysicsScene _physicsScene;
    [SerializeField] private Transform sceneObjects;

    private void Start()
    {
        CreatePhysicsScene();
    }


    private void CreatePhysicsScene()
    {
        _simulationScene = SceneManager.CreateScene("Simulation", new CreateSceneParameters(LocalPhysicsMode.Physics3D));
        _physicsScene = _simulationScene.GetPhysicsScene();

        foreach (Transform obj in sceneObjects)
        {
            var cloneOfObject = Instantiate(obj.gameObject,obj.transform.position,obj.rotation);
            cloneOfObject.GetComponent<Renderer>().enabled = false;
            SceneManager.MoveGameObjectToScene(cloneOfObject,_simulationScene);
        }
    }

    public void SimulateTrajectory(Ball ball,Vector3 pos,Vector3 velocity)
    {
        
    }
}