using System.Collections.Generic;
using UnityEngine;

public class EnemyBT_Normal : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    EnemyMover mover;
    BTNode root;
    void Start()
    {
        mover = GetComponent<EnemyMover>();
        var RangeFound = new CheckDistanceNode(mover);
        var MoveToTarget = new MoveToTargetNode(mover);

        root = new SelectorNode(new List<BTNode> {
            new SequenceNode(new List<BTNode> { RangeFound, MoveToTarget }),
            new ActionNode( () =>
       {        Debug.Log("IDLE...");
                return NodeState.Run;
            })
        });

    }

    // Update is called once per frame
    void Update()
    {
        root.Eval();
    }
}
