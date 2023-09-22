# zfoo-csharp-unity-sdk

zfoo net sdk for unity by C#

```
support C# in webgl browser
```

# Start Server

- start server
  in [TcpServerTest](https://github.com/zfoo-project/zfoo/blob/64a9fec7bac3fb10cb798a567f75bb6d7230a121/net/src/test/java/com/zfoo/net/core/tcp/server/TcpServerTest.java)

# Start Client

- await usage

```
var response = await netManager.asyncAsk(request) as TcpHelloResponse;
```

- send with no response

```
netManager.Send(request)
```