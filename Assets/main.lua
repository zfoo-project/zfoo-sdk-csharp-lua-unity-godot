local ByteBuffer = require("zfoolua.ByteBuffer")
local ProtocolManager = require("zfoolua.ProtocolManager")
local Protocols = require("zfoolua.Protocols")

function sendTest()
    local request = Protocols.TcpHelloRequest:new()
    request.message = "这个是普通发送的lua消息"
    send(request)
end

function asyncAskTest()
    local request = Protocols.TcpHelloRequest:new()
    request.message = "这个是异步发送的lua消息"
    local myValue = 100
    asyncAsk(request,
            function(answer)
                print("异步请求回调方法 callback --> ", answer)
                print(myValue)
            end)
end

-------------------------------------ProtocolManager init------------------------------------- 
function initProtocol()
    ProtocolManager.initProtocol()
end

-------------------------------------send packet------------------------------------- 
function send(packet)
    local byteBuffer = ByteBuffer:new()
    byteBuffer:writeRawInt(4)
    ProtocolManager.write(byteBuffer, packet)
    sendByteBuffer(byteBuffer)
end

function sendWithAttachment(packet, attachment)
    local byteBuffer = ByteBuffer:new()
    byteBuffer:writeRawInt(4)
    ProtocolManager.write(byteBuffer, packet)
    byteBuffer:writeBoolean(true)
    ProtocolManager.write(byteBuffer, attachment)
    sendByteBuffer(byteBuffer)
end

function sendByteBuffer(byteBuffer)
    local length = byteBuffer:getWriteOffset() - 1
    local packetLength = length - 4
    byteBuffer:setWriteOffset(1)
    byteBuffer:writeRawInt(packetLength)
    byteBuffer:setWriteOffset(length)

    mm = CS.System.IO.MemoryStream()
    mm.Position = 0
    mm:SetLength(0)
    mm:Write(byteBuffer:getBytes(1, length), 0, length)
    CS.zfoolua.LuaMain.Send(mm, length)
end
-------------------------------------asyncAsk packet------------------------------------- 
local uuid = 0
local signalAttachmentMap = {}

function asyncAsk(packet, callback)
    local currentTime = os.clock()
    local attachment = Protocols.SignalAttachment:new();
    uuid = uuid + 1
    local signalId = uuid
    -- 将浮点转为整形
    attachment.timestamp = math.floor(currentTime)
    attachment.signalId = signalId
    attachment.taskExecutorHash = -1
    attachment.client = 12
    local encodedPacketInfo = {
        attachment = attachment,
        callback = callback
    }
    -- 遍历删除旧的attachment
    local deleteList = {}
    for key, value in pairs(signalAttachmentMap) do
        if value == nil or value.attachment == nil then
            table.insert(deleteList, key)
        else
            local att = value.attachment
            local time = att.timestamp
            if currentTime - time > 15 then
                table.insert(deleteList, key)
            end
        end
    end
    for index, element in pairs(deleteList) do
        signalAttachmentMap[element] = nil
    end
    signalAttachmentMap[signalId] = encodedPacketInfo
    sendWithAttachment(packet, attachment)
end

function receiver(bytes)
    print("lua receiver bytes ", #bytes)
    local byteBuffer = ByteBuffer:new()
    byteBuffer:writeBuffer(bytes)
    local packet = ProtocolManager.read(byteBuffer)
    if byteBuffer:isReadable() and byteBuffer:readBoolean() then
        local attachment = ProtocolManager.read(byteBuffer)
        local signalId = attachment.signalId
        local encodedPacketInfo = signalAttachmentMap[signalId]
        if encodedPacketInfo == nil then
            print("可能消息超时找不到对应的SignalAttachment:", attachment)
        else
            local callback = encodedPacketInfo.callback
            callback(packet)
            signalAttachmentMap[signalId] = nil
            print("收到异步response <-- ", packet)
        end
    else
        print("收到response <-- ", packet)
    end
end