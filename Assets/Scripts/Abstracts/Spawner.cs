using MLAPI;
using UnityEngine;

public abstract class Spawner : NetworkBehaviour
{
    public virtual void Spawn(GameObject objectToSpawn, Vector3 newPosition, Quaternion newRotation)
    {
        objectToSpawn.transform.position = newPosition;
        objectToSpawn.transform.rotation = newRotation;
    }
}
