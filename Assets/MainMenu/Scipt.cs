using UnityEngine;
using UnityEngine.SceneManagement;
 
public class Script : MonoBehaviour
{
    public Transform player; 
    public float moveSpeed = 5f; // the enemy's move speed
    public float rotationSpeed = 5f; // the speed at which the enemy rotates
    public float chaseRange = 10f; // the distance at which the enemy starts chasing the player
    public float deathRange = .75f; // the distance at which the enemy kills the player
 
    private void Update()
    {
        float distance = Vector3.Distance(player.position, transform.position);
        ChasePlayer(distance); 
        PlayerDeath(distance); 
    }
 
    private void PlayerDeath(float distance)
    {
        if (distance < deathRange)
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
 
    private void ChasePlayer(float distance)
    {
        if (distance < chaseRange)
        {
            Vector3 direction = (player.position - transform.position).normalized;
            transform.position += direction * moveSpeed * Time.deltaTime;
            Quaternion lookRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, rotationSpeed * Time.deltaTime);
        }
    }
}