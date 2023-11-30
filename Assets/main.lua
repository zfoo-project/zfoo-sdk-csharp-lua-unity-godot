local ByteBuffer = require("zfoolua.ByteBuffer")
local ProtocolManager = require("zfoolua.ProtocolManager")
local TcpHelloRequest = require("zfoolua.tcp.TcpHelloRequest")


-------------------------------------ProtocolManager init-------------------------------------
function initProtocol()
    ProtocolManager.initProtocol()
end

function sendTest()
    local request = TcpHelloRequest:new()
    request.message = "这个是普通发送的lua消息"
    send(request)
end


function send(packet)
    local byteBuffer = ByteBuffer:new()
    byteBuffer:writeRawInt(4)
    ProtocolManager.write(byteBuffer, packet)
    local length = byteBuffer:getWriteOffset()
    local packetLength = length - 4
    byteBuffer:setWriteOffset(1)
    byteBuffer:writeRawInt(packetLength)
    byteBuffer:setWriteOffset(length)
    
    mm = CS.System.IO.MemoryStream()
    mm.Position = 0
    mm:SetLength(0)
    len = byteBuffer:getWriteOffset() - 1
    mm:Write(byteBuffer:getBytes(1, len), 0, len)
    CS.zfoolua.LuaMain.Send(mm, len)
end

function receiver(bytes)
    print("lua receiver bytes ", #bytes)
    local byteBuffer = ByteBuffer:new()
    byteBuffer:writeBuffer(bytes)
    local packet = ProtocolManager.read(byteBuffer)
    print(packet)
end