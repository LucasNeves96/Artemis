using UnityEngine;

public class WalkEntitty : MonoBehaviour
{
    [SerializeField] private RectTransform rectTransform;
    [SerializeField] private float speed = 1;
    [SerializeField] private Vector3 desiredPos;
    const float MINIMUM_DISTANCE = 0.01f;

    void Update()
    {
        if (rectTransform.position != desiredPos)
        {
            rectTransform.position = moveTowards(rectTransform.position, desiredPos);
        }
    }

    Vector3 moveTowards(Vector3 position, Vector3 desiredPos)
    {
        Vector3 direction = new Vector3(
            desiredPos.x - position.x,
            desiredPos.y - position.y,
            desiredPos.z - position.z);
        direction.Normalize();

        float moveX = position.x + (direction.x * speed * Time.deltaTime);
        float moveY = position.y + (direction.y * speed * Time.deltaTime);
        float moveZ = position.z + (direction.z * speed * Time.deltaTime);

        if (Mathf.Abs(moveX - desiredPos.x) < MINIMUM_DISTANCE)
        {
            moveX = desiredPos.x;
        }
        if (Mathf.Abs(moveY - desiredPos.y) < MINIMUM_DISTANCE)
        {
            moveY = desiredPos.y;
        }
        if (Mathf.Abs(moveZ - desiredPos.z) < MINIMUM_DISTANCE)
        {
            moveZ = desiredPos.z;
        }

        return new Vector3(moveX, moveY, moveZ);
    }
}
