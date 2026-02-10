using UnityEngine;

public class FoodTrigger : MonoBehaviour
{
    public enum FoodType { Apple, Trash }
    public FoodType foodType;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("EAT: " + other.name);

        SnakeMovement snake = other.GetComponentInParent<SnakeMovement>();
        if (snake == null) return;

        if (foodType == FoodType.Apple)
            snake.AddBodyPart();
        else
            snake.RemoveBodyPart();

        // Move food somewhere else
        transform.position = new Vector3(
            Random.Range(-5f, 5f),
            transform.position.y,
            Random.Range(-5f, 5f)
        );
    }
}