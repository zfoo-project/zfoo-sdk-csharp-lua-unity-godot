# zfoo sdk of csharp and lua for unity and godot

zfoo sdk of csharp and lua for unity and godot

```
support C# in .net framework

support C# in unity C# Script

support C# in unity webgl

support zfoo lua in xlua
```

# Start Server

- start server
  in [TcpServerTest](https://github.com/zfoo-project/zfoo/blob/main/net/src/test/java/com/zfoo/net/core/tcp/server/TcpServerTest.java)

# Start Client

- await usage in C#

```
var response = await tcpClient.asyncAsk(request) as TcpHelloResponse;
```

- send packet in C#

```
tcpClient.Send(request)
```

- async callback in lua

```
asyncAsk(request,
        function(answer)
            print("async ask callback --> ", answer)
        end)
```

- send packet in lua

```
send(request)
```