using CsProtocol;
using Spring.Core;
using Spring.Event;
using Spring.Util;
using Summer.Net;
using Summer.Net.Core.Model;
using Summer.Net.Dispatcher;
using Summer.Scheduler.Model;
using UnityEngine;


namespace Controller
{
   
    [Bean]
    public class LoginController
    {

        [PacketReceiver]
        public void AtTcpHelloResponse(TcpHelloResponse response)
        {
            Debug.Log("@PacketReceiver response:" + JsonUtility.ToJson(response));
        }

        [PacketReceiver]
        public void AtPong(Pong pong)
        {
            // 设置一下服务器的最新时间
            TimeUtils.SetNow(pong.time);
        }

        [EventReceiver]
        public void OnNetOpenEvent(NetOpenEvent eve)
        {
            Debug.Log(eve.GetType().Name);
            
            var request = new TcpHelloRequest();
            request.message = "unity request";
            SpringContext.GetBean<NetManager>().Send(request);
            
        }

        [EventReceiver]
        public void OnNetErrorEvent(NetErrorEvent eve)
        {
            Debug.Log(eve.GetType().Name);
        }
    
        [EventReceiver]
        public void OnMinuteSchedulerAsyncEvent(MinuteSchedulerAsyncEvent eve)
        {
            Debug.Log(eve.GetType().Name + TimeUtils.Now());
        }
    } 
}