using TheKiwiCoder;

[System.Serializable]
public class ExtSubTree : SubTree
{
    public override void OnInit()
    {
        if (treeAsset)
        {
            treeInstance = treeAsset.Clone();
            treeInstance.blackboard = blackboard;
            treeInstance.Bind(context);
        }
    }
}
