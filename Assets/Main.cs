using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CsProtocol;
using CsProtocol.Buffer;
using Spring.Core;
using Summer.Net;
using UnityEngine;

public class Main : MonoBehaviour
{
    async Task Start()
    {
        var netManager = SpringContext.GetBean<NetManager>();
        if (Application.platform == RuntimePlatform.WebGLPlayer)
        {
            var websocketServerUrl = "127.0.0.1:9000";
            netManager.Connect(websocketServerUrl);
        }
        else
        {
            var tcpServerUrl = "127.0.0.1:9000";
            netManager.Connect(tcpServerUrl);
        }
        
        // 等待获取的数字
        int number = await GetNumberAsync();
        Debug.Log("加载的数据：" + number);
        
        var request = new TcpHelloRequest();
        request.message = "unity await request";
        var response = await netManager.asyncAsk(request) as TcpHelloResponse;
        Debug.Log("await response:" + response);
    }

    Task<int> GetNumberAsync()
    {
        // 创建一个TaskCompletionSource对象
        TaskCompletionSource<int> tcs = new TaskCompletionSource<int>();

        // 模拟异步操作
        StartCoroutine(DelayedCompletion(tcs));

        // 返回Task对象
        return tcs.Task;
    }

    IEnumerator DelayedCompletion(TaskCompletionSource<int> tcs)
    {
        // 等待3秒
        yield return new WaitForSeconds(3f);
        // 完成Task，并设置结果值
        tcs.SetResult(42);
    }

    // Update is called once per frame
    void Update()
    {
    }
}
