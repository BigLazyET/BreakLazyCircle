using BigLazyET.BT;
using System.Collections.Generic;
using System.Linq;

namespace AIShared
{
    [System.Serializable]
    public class StageBasedSelector : RandomCOSelector
    {
        /// <summary>
        /// 当前敌人是几阶段
        /// </summary>
        private int currentStage;   // 0,1,2
        /// <summary>
        /// 每个阶段对应的需要执行的Selector节点的子节点是哪些
        /// 比如阶段一只执行index:0,1的子行为节点
        /// 阶段二只执行Index:2,3的子行为节点
        /// 阶段三就是所有子行为节点都执行
        /// </summary>
        public List<string> includedTasksPerStage; // {"0,1", "2,3", "0，1，2，3"}

        protected override void OnStart()
        {
            // TODO: blackboard-currentStage
            currentStage = blackboard.GetValue<int>("currentStage");
            childIndexList.Clear();
            childrenExecutionOrder.Clear();
            childIndexList = includedTasksPerStage[currentStage].Split(',').Select(int.Parse).ToList();
            ShuffleChilden();
        }
    }
}
