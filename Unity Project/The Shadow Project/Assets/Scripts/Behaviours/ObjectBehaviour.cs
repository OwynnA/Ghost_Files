/*
Originial Coder: Owynn A.
Recent Coder: Zackery E.
Recent Changes: Added basic return logic
Last date worked on: 10/3/2025
*/

using UnityEngine;

public class ObjectBehaviour : MonoBehaviour
{
    [Header("Settings")]
    public IntData damage;
    public int throwSpeed = 10;
    public bool returnable = false;

    [Header("Info")]
    public ObjectSpawner originSpawn;
    public Transform returnToObject; // Object to return to (Ghost)
    public ThrowObjectBehavior throwObjectBehavior;

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Hand"))
        {
            throwObjectBehavior.StartThrow(gameObject, returnToObject.position, throwSpeed);
        }
        else
        {
            // Damage Logic
        }
    }

}