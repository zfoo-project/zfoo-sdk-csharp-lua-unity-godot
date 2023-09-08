using Spring.Core;
using Spring.Event;
using Spring.Util;
using Summer.Base;
using Summer.Base.Model;
using Summer.Scheduler.Model;
using UnityEngine;

namespace Summer.Scheduler
{
    [Bean]
    public class SchedulerManager : AbstractManager, ISchedulerManager
    {
        [Autowired]
        private BaseComponent baseComponent;


        private float count = 0;
        private long lastTime = TimeUtils.Now();

        public override void Update(float elapseSeconds, float realElapseSeconds)
        {
            count += elapseSeconds;
            // 每秒刷新一次，减少运算
            if (count < 1)
            {
                return;
            }
            var now = TimeUtils.Now() + (long) (count * TimeUtils.MILLIS_PER_SECOND);
            TimeUtils.SetNow(now);
            count = 0;
            
            // 每一分钟抛出一个MinuteSchedulerAsyncEvent事件
            if (now - lastTime > TimeUtils.MILLIS_PER_MINUTE)
            {
                lastTime = now;
                EventBus.AsyncSubmit(MinuteSchedulerAsyncEvent.ValueOf());
            }
        }

        public override void Shutdown()
        {
        }

    }
}