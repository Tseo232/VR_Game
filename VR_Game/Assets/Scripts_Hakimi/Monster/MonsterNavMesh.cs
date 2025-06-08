using UnityEngine;
using UnityEngine.AI;

public class MonsterNavMesh : MonoBehaviour
{
    private NavMeshAgent navMeshAgent;
    private Transform[] moveTargets;
    private Transform currentTarget;

    [SerializeField] private float targetReachedThreshold = 1f;

    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void Start()
    {
        GameObject[] targets = GameObject.FindGameObjectsWithTag("MoveTarget");
        moveTargets = new Transform[targets.Length];

        for (int i = 0; i < targets.Length; i++)
        {
            moveTargets[i] = targets[i].transform;
        }

        PickNewTarget();
    }

    private void Update()
    {
        if (currentTarget == null) return;

        navMeshAgent.destination = currentTarget.position;

        float distanceToTarget = Vector3.Distance(transform.position, currentTarget.position);
        if (distanceToTarget < targetReachedThreshold)
        {
            PickNewTarget();
        }
    }

    private void PickNewTarget()
    {
        if (moveTargets.Length == 0) return;

        Transform newTarget;
        do
        {
            newTarget = moveTargets[Random.Range(0, moveTargets.Length)];
        } while (newTarget == currentTarget && moveTargets.Length > 1);

        currentTarget = newTarget;
    }
}
