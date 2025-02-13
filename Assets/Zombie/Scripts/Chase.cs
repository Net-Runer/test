using UnityEngine;
using UnityEngine.SceneManagement;
 
public class Chase : MonoBehaviour
{
    public Transform player; 
    public Animator animator; 
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
        {
            animator.SetBool("isDead", true);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        else
            animator.SetBool("isDead", false);
            
    }
 
    private void ChasePlayer(float distance)
    {
        if (distance < chaseRange)
        {
            animator.SetBool("isRunning", true);
            Vector3 direction = (player.position - transform.position).normalized;
            transform.position += direction * moveSpeed * Time.deltaTime;
            Quaternion lookRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, rotationSpeed * Time.deltaTime);
        }
        else
            animator.SetBool("isRunning", false);
    }
}
