using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject[] PathPoints;
    [SerializeField]
    private int currentPathIndex = 0;
    public float speed;
    private float epsilon = 0.15f;
    private Vector3 direction;

    private void Start()
    {
        direction = Vector3.right;
    }
    private void Update()
    {
        if (Vector3.Distance(transform.position, PathPoints[currentPathIndex].transform.position) < epsilon)
        {
            ChangeDirection();
        }
        Move();
    }
    void Move()
    {
        transform.position += speed * direction * Time.deltaTime;
    }
    void ChangeDirection()
    {
        int nextIndex = currentPathIndex + 1;
        if (nextIndex == PathPoints.Length)
        {
            Destroy(gameObject);
            WinPannel.Instance.ShowLosePannel();
            return;
        }
        direction = (PathPoints[nextIndex].transform.position - PathPoints[currentPathIndex].transform.position).normalized;
        currentPathIndex++;
        transform.rotation = Quaternion.FromToRotation(Vector3.right,direction);
    }
}
