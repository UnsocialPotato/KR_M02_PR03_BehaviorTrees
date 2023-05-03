using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using BehaviorTree;

public class GuardBT : BTree
{
    public UnityEngine.Transform[] waypoints;

    public static float speed = 2f;
    public static float fovRange = 6f;
    public static float attackRange = 1f;

    protected override Node_2 SetupTree()
    {
        Node_2 root = new Selector(new List<Node_2>
        {
            new Sequence(new List<Node_2>
            {
                new CheckEnemyInAttackRange(transform),
                new TaskAttack(transform),
            }),
            new Sequence(new List<Node_2>
            {
                new CheckEnemyInFOVRange(transform),
                new TaskGoToTarget(transform),
            }),
            new TaskPatrol (transform, waypoints),
        });

        return root;
    }
}
