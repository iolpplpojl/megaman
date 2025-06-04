using System;
using System.Collections.Generic;
using UnityEngine;


public enum NodeState { Okay, Fail, Run }
public abstract class BTNode
{
    public abstract NodeState Eval();
}
                                                

public class CheckDistanceNode : BTNode 
{
    public EnemyMover mover;
    public CheckDistanceNode(EnemyMover mover)
    {
        this.mover = mover;
    }
    public override NodeState Eval()
    {
        Debug.Log($"CheckDistanceNode: isFind = {mover.isFind}");
        return mover.isFind ? NodeState.Okay : NodeState.Fail;
    }
}

public class MoveToTargetNode : BTNode
{
    public EnemyMover mover;
    public MoveToTargetNode(EnemyMover mover)
    {
        this.mover = mover; 
    }
    public override NodeState Eval()
    {
        Debug.Log("움직이는 중...");                                             
        mover.Move();
        return NodeState.Run;
    }
}

public class SequenceNode : BTNode
{
    private List<BTNode> _children;

    public SequenceNode(List<BTNode> children)
    {
        _children = children;
    }

    public override NodeState Eval()
    {
        bool anyRunning = false;

        foreach (var node in _children)
        {
            NodeState result = node.Eval();
            Debug.Log($"Child returned: {result}");

            if (result == NodeState.Fail)
                return NodeState.Fail;
            if (result == NodeState.Run)
                anyRunning = true;
                
        }
        return anyRunning ? NodeState.Run : NodeState.Okay;
    }
}

public class SelectorNode : BTNode
{
    private List<BTNode> _children;
    public SelectorNode(List<BTNode> children)
    {
        _children = children;
    }

    public override NodeState Eval()
    {
        bool anyRunning = false;
        foreach (var node in _children)
        {
            NodeState result = node.Eval();
            if (result == NodeState.Okay)
                return NodeState.Okay;
            if (result == NodeState.Run)
            {
                anyRunning = true;
                break;
            }
        }
        return anyRunning ? NodeState.Run : NodeState.Fail;
    }
}
public class ActionNode : BTNode
{
    private Func<NodeState> _action;

    public ActionNode(Func<NodeState> action)
    {
        _action = action;
    }

    public override NodeState Eval()
    {
        return _action.Invoke();
    }
}