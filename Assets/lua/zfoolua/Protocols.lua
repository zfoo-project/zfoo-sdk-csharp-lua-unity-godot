local Protocols = {}


local SignalAttachment = {}

function SignalAttachment:new()
    local obj = {
        -- 0 for the server, 1 or 2 for the sync or async native client, 12 for the outside client such as browser, mobile
        client = 0, -- byte
        signalId = 0, -- int
        taskExecutorHash = 0, -- int
        timestamp = 0 -- long
    }
    setmetatable(obj, self)
    self.__index = self
    return obj
end

local Message = {}

function Message:new()
    local obj = {
        code = 0, -- int
        message = "" -- string
    }
    setmetatable(obj, self)
    self.__index = self
    return obj
end

local Error = {}

function Error:new()
    local obj = {
        code = 0, -- int
        message = "" -- string
    }
    setmetatable(obj, self)
    self.__index = self
    return obj
end

local Heartbeat = {}

function Heartbeat:new()
    local obj = {
        
    }
    setmetatable(obj, self)
    self.__index = self
    return obj
end

local Ping = {}

function Ping:new()
    local obj = {
        
    }
    setmetatable(obj, self)
    self.__index = self
    return obj
end

local Pong = {}

function Pong:new()
    local obj = {
        time = 0 -- long
    }
    setmetatable(obj, self)
    self.__index = self
    return obj
end

local PairIntLong = {}

function PairIntLong:new()
    local obj = {
        key = 0, -- int
        value = 0 -- long
    }
    setmetatable(obj, self)
    self.__index = self
    return obj
end

local PairLong = {}

function PairLong:new()
    local obj = {
        key = 0, -- long
        value = 0 -- long
    }
    setmetatable(obj, self)
    self.__index = self
    return obj
end

local PairString = {}

function PairString:new()
    local obj = {
        key = "", -- string
        value = "" -- string
    }
    setmetatable(obj, self)
    self.__index = self
    return obj
end

local PairLS = {}

function PairLS:new()
    local obj = {
        key = 0, -- long
        value = "" -- string
    }
    setmetatable(obj, self)
    self.__index = self
    return obj
end

local TripleLong = {}

function TripleLong:new()
    local obj = {
        left = 0, -- long
        middle = 0, -- long
        right = 0 -- long
    }
    setmetatable(obj, self)
    self.__index = self
    return obj
end

local TripleString = {}

function TripleString:new()
    local obj = {
        left = "", -- string
        middle = "", -- string
        right = "" -- string
    }
    setmetatable(obj, self)
    self.__index = self
    return obj
end

local TripleLSS = {}

function TripleLSS:new()
    local obj = {
        left = 0, -- long
        middle = "", -- string
        right = "" -- string
    }
    setmetatable(obj, self)
    self.__index = self
    return obj
end

local UdpHelloRequest = {}

function UdpHelloRequest:new()
    local obj = {
        message = "" -- string
    }
    setmetatable(obj, self)
    self.__index = self
    return obj
end

local UdpHelloResponse = {}

function UdpHelloResponse:new()
    local obj = {
        message = "" -- string
    }
    setmetatable(obj, self)
    self.__index = self
    return obj
end

local TcpHelloRequest = {}

function TcpHelloRequest:new()
    local obj = {
        message = "" -- string
    }
    setmetatable(obj, self)
    self.__index = self
    return obj
end

local TcpHelloResponse = {}

function TcpHelloResponse:new()
    local obj = {
        message = "" -- string
    }
    setmetatable(obj, self)
    self.__index = self
    return obj
end

local WebsocketHelloRequest = {}

function WebsocketHelloRequest:new()
    local obj = {
        message = "" -- string
    }
    setmetatable(obj, self)
    self.__index = self
    return obj
end

local WebsocketHelloResponse = {}

function WebsocketHelloResponse:new()
    local obj = {
        message = "" -- string
    }
    setmetatable(obj, self)
    self.__index = self
    return obj
end

local JsonHelloRequest = {}

function JsonHelloRequest:new()
    local obj = {
        message = "" -- string
    }
    setmetatable(obj, self)
    self.__index = self
    return obj
end

local JsonHelloResponse = {}

function JsonHelloResponse:new()
    local obj = {
        message = "" -- string
    }
    setmetatable(obj, self)
    self.__index = self
    return obj
end

local HttpHelloRequest = {}

function HttpHelloRequest:new()
    local obj = {
        message = "" -- string
    }
    setmetatable(obj, self)
    self.__index = self
    return obj
end

local HttpHelloResponse = {}

function HttpHelloResponse:new()
    local obj = {
        message = "" -- string
    }
    setmetatable(obj, self)
    self.__index = self
    return obj
end

local WebSocketPacketRequest = {}

function WebSocketPacketRequest:new()
    local obj = {
        a = 0, -- byte
        aa = 0, -- byte
        aaa = {}, -- byte[]
        aaaa = {}, -- byte[]
        b = 0, -- short
        bb = 0, -- short
        bbb = {}, -- short[]
        bbbb = {}, -- short[]
        c = 0, -- int
        cc = 0, -- int
        ccc = {}, -- int[]
        cccc = {}, -- int[]
        d = 0, -- long
        dd = {}, -- long[]
        e = 0, -- float
        ee = 0, -- float
        eee = {}, -- float[]
        eeee = {}, -- float[]
        f = 0, -- double
        ff = 0, -- double
        fff = {}, -- double[]
        ffff = {}, -- double[]
        jj = "", -- string
        jjj = {}, -- string[]
        kk = nil, -- WebSocketObjectA
        kkk = {}, -- WebSocketObjectA[]
        l = {}, -- List<int>
        ll = {}, -- List<List<List<int>>>
        lll = {}, -- List<List<WebSocketObjectA>>
        llll = {}, -- List<string>
        lllll = {}, -- List<Dictionary<int, string>>
        m = {}, -- Dictionary<int, string>
        mm = {}, -- Dictionary<int, WebSocketObjectA>
        mmm = {}, -- Dictionary<WebSocketObjectA, List<int>>
        mmmm = {}, -- Dictionary<List<List<WebSocketObjectA>>, List<List<List<int>>>>
        s = {}, -- HashSet<int>
        ss = {}, -- HashSet<HashSet<List<int>>>
        sss = {}, -- HashSet<HashSet<WebSocketObjectA>>
        ssss = {}, -- HashSet<string>
        sssss = {} -- HashSet<Dictionary<int, string>>
    }
    setmetatable(obj, self)
    self.__index = self
    return obj
end

local WebSocketObjectA = {}

function WebSocketObjectA:new()
    local obj = {
        a = 0, -- int
        objectB = nil -- WebSocketObjectB
    }
    setmetatable(obj, self)
    self.__index = self
    return obj
end

local WebSocketObjectB = {}

function WebSocketObjectB:new()
    local obj = {
        flag = false -- bool
    }
    setmetatable(obj, self)
    self.__index = self
    return obj
end

local GatewayToProviderRequest = {}

function GatewayToProviderRequest:new()
    local obj = {
        message = "" -- string
    }
    setmetatable(obj, self)
    self.__index = self
    return obj
end

local GatewayToProviderResponse = {}

function GatewayToProviderResponse:new()
    local obj = {
        message = "" -- string
    }
    setmetatable(obj, self)
    self.__index = self
    return obj
end

function SignalAttachment:protocolId()
    return 0
end

function SignalAttachment:protocolName()
    return "SignalAttachment"
end

function SignalAttachment:__tostring()
    return table.serializeTableToJson(self)
end

function SignalAttachment:write(buffer, packet)
    if packet == nil then
        buffer:writeInt(0)
        return
    end
    buffer:writeInt(-1)
    buffer:writeByte(packet.client)
    buffer:writeInt(packet.signalId)
    buffer:writeInt(packet.taskExecutorHash)
    buffer:writeLong(packet.timestamp)
end

function SignalAttachment:read(buffer)
    local length = buffer:readInt()
    if length == 0 then
        return nil
    end
    local beforeReadIndex = buffer:getReadOffset()
    local packet = SignalAttachment:new()
    local result0 = buffer:readByte()
    packet.client = result0
    local result1 = buffer:readInt()
    packet.signalId = result1
    local result2 = buffer:readInt()
    packet.taskExecutorHash = result2
    local result3 = buffer:readLong()
    packet.timestamp = result3
    if length > 0 then
        buffer:setReadOffset(beforeReadIndex + length)
    end
    return packet
end
function Message:protocolId()
    return 100
end

function Message:protocolName()
    return "Message"
end

function Message:__tostring()
    return table.serializeTableToJson(self)
end

function Message:write(buffer, packet)
    if packet == nil then
        buffer:writeInt(0)
        return
    end
    buffer:writeInt(-1)
    buffer:writeInt(packet.code)
    buffer:writeString(packet.message)
end

function Message:read(buffer)
    local length = buffer:readInt()
    if length == 0 then
        return nil
    end
    local beforeReadIndex = buffer:getReadOffset()
    local packet = Message:new()
    local result0 = buffer:readInt()
    packet.code = result0
    local result1 = buffer:readString()
    packet.message = result1
    if length > 0 then
        buffer:setReadOffset(beforeReadIndex + length)
    end
    return packet
end
function Error:protocolId()
    return 101
end

function Error:protocolName()
    return "Error"
end

function Error:__tostring()
    return table.serializeTableToJson(self)
end

function Error:write(buffer, packet)
    if packet == nil then
        buffer:writeInt(0)
        return
    end
    buffer:writeInt(-1)
    buffer:writeInt(packet.code)
    buffer:writeString(packet.message)
end

function Error:read(buffer)
    local length = buffer:readInt()
    if length == 0 then
        return nil
    end
    local beforeReadIndex = buffer:getReadOffset()
    local packet = Error:new()
    local result0 = buffer:readInt()
    packet.code = result0
    local result1 = buffer:readString()
    packet.message = result1
    if length > 0 then
        buffer:setReadOffset(beforeReadIndex + length)
    end
    return packet
end
function Heartbeat:protocolId()
    return 102
end

function Heartbeat:protocolName()
    return "Heartbeat"
end

function Heartbeat:__tostring()
    return table.serializeTableToJson(self)
end

function Heartbeat:write(buffer, packet)
    if packet == nil then
        buffer:writeInt(0)
        return
    end
    buffer:writeInt(-1)
end

function Heartbeat:read(buffer)
    local length = buffer:readInt()
    if length == 0 then
        return nil
    end
    local beforeReadIndex = buffer:getReadOffset()
    local packet = Heartbeat:new()
    
    if length > 0 then
        buffer:setReadOffset(beforeReadIndex + length)
    end
    return packet
end
function Ping:protocolId()
    return 103
end

function Ping:protocolName()
    return "Ping"
end

function Ping:__tostring()
    return table.serializeTableToJson(self)
end

function Ping:write(buffer, packet)
    if packet == nil then
        buffer:writeInt(0)
        return
    end
    buffer:writeInt(-1)
end

function Ping:read(buffer)
    local length = buffer:readInt()
    if length == 0 then
        return nil
    end
    local beforeReadIndex = buffer:getReadOffset()
    local packet = Ping:new()
    
    if length > 0 then
        buffer:setReadOffset(beforeReadIndex + length)
    end
    return packet
end
function Pong:protocolId()
    return 104
end

function Pong:protocolName()
    return "Pong"
end

function Pong:__tostring()
    return table.serializeTableToJson(self)
end

function Pong:write(buffer, packet)
    if packet == nil then
        buffer:writeInt(0)
        return
    end
    buffer:writeInt(-1)
    buffer:writeLong(packet.time)
end

function Pong:read(buffer)
    local length = buffer:readInt()
    if length == 0 then
        return nil
    end
    local beforeReadIndex = buffer:getReadOffset()
    local packet = Pong:new()
    local result0 = buffer:readLong()
    packet.time = result0
    if length > 0 then
        buffer:setReadOffset(beforeReadIndex + length)
    end
    return packet
end
function PairIntLong:protocolId()
    return 110
end

function PairIntLong:protocolName()
    return "PairIntLong"
end

function PairIntLong:__tostring()
    return table.serializeTableToJson(self)
end

function PairIntLong:write(buffer, packet)
    if packet == nil then
        buffer:writeInt(0)
        return
    end
    buffer:writeInt(-1)
    buffer:writeInt(packet.key)
    buffer:writeLong(packet.value)
end

function PairIntLong:read(buffer)
    local length = buffer:readInt()
    if length == 0 then
        return nil
    end
    local beforeReadIndex = buffer:getReadOffset()
    local packet = PairIntLong:new()
    local result0 = buffer:readInt()
    packet.key = result0
    local result1 = buffer:readLong()
    packet.value = result1
    if length > 0 then
        buffer:setReadOffset(beforeReadIndex + length)
    end
    return packet
end
function PairLong:protocolId()
    return 111
end

function PairLong:protocolName()
    return "PairLong"
end

function PairLong:__tostring()
    return table.serializeTableToJson(self)
end

function PairLong:write(buffer, packet)
    if packet == nil then
        buffer:writeInt(0)
        return
    end
    buffer:writeInt(-1)
    buffer:writeLong(packet.key)
    buffer:writeLong(packet.value)
end

function PairLong:read(buffer)
    local length = buffer:readInt()
    if length == 0 then
        return nil
    end
    local beforeReadIndex = buffer:getReadOffset()
    local packet = PairLong:new()
    local result0 = buffer:readLong()
    packet.key = result0
    local result1 = buffer:readLong()
    packet.value = result1
    if length > 0 then
        buffer:setReadOffset(beforeReadIndex + length)
    end
    return packet
end
function PairString:protocolId()
    return 112
end

function PairString:protocolName()
    return "PairString"
end

function PairString:__tostring()
    return table.serializeTableToJson(self)
end

function PairString:write(buffer, packet)
    if packet == nil then
        buffer:writeInt(0)
        return
    end
    buffer:writeInt(-1)
    buffer:writeString(packet.key)
    buffer:writeString(packet.value)
end

function PairString:read(buffer)
    local length = buffer:readInt()
    if length == 0 then
        return nil
    end
    local beforeReadIndex = buffer:getReadOffset()
    local packet = PairString:new()
    local result0 = buffer:readString()
    packet.key = result0
    local result1 = buffer:readString()
    packet.value = result1
    if length > 0 then
        buffer:setReadOffset(beforeReadIndex + length)
    end
    return packet
end
function PairLS:protocolId()
    return 113
end

function PairLS:protocolName()
    return "PairLS"
end

function PairLS:__tostring()
    return table.serializeTableToJson(self)
end

function PairLS:write(buffer, packet)
    if packet == nil then
        buffer:writeInt(0)
        return
    end
    buffer:writeInt(-1)
    buffer:writeLong(packet.key)
    buffer:writeString(packet.value)
end

function PairLS:read(buffer)
    local length = buffer:readInt()
    if length == 0 then
        return nil
    end
    local beforeReadIndex = buffer:getReadOffset()
    local packet = PairLS:new()
    local result0 = buffer:readLong()
    packet.key = result0
    local result1 = buffer:readString()
    packet.value = result1
    if length > 0 then
        buffer:setReadOffset(beforeReadIndex + length)
    end
    return packet
end
function TripleLong:protocolId()
    return 114
end

function TripleLong:protocolName()
    return "TripleLong"
end

function TripleLong:__tostring()
    return table.serializeTableToJson(self)
end

function TripleLong:write(buffer, packet)
    if packet == nil then
        buffer:writeInt(0)
        return
    end
    buffer:writeInt(-1)
    buffer:writeLong(packet.left)
    buffer:writeLong(packet.middle)
    buffer:writeLong(packet.right)
end

function TripleLong:read(buffer)
    local length = buffer:readInt()
    if length == 0 then
        return nil
    end
    local beforeReadIndex = buffer:getReadOffset()
    local packet = TripleLong:new()
    local result0 = buffer:readLong()
    packet.left = result0
    local result1 = buffer:readLong()
    packet.middle = result1
    local result2 = buffer:readLong()
    packet.right = result2
    if length > 0 then
        buffer:setReadOffset(beforeReadIndex + length)
    end
    return packet
end
function TripleString:protocolId()
    return 115
end

function TripleString:protocolName()
    return "TripleString"
end

function TripleString:__tostring()
    return table.serializeTableToJson(self)
end

function TripleString:write(buffer, packet)
    if packet == nil then
        buffer:writeInt(0)
        return
    end
    buffer:writeInt(-1)
    buffer:writeString(packet.left)
    buffer:writeString(packet.middle)
    buffer:writeString(packet.right)
end

function TripleString:read(buffer)
    local length = buffer:readInt()
    if length == 0 then
        return nil
    end
    local beforeReadIndex = buffer:getReadOffset()
    local packet = TripleString:new()
    local result0 = buffer:readString()
    packet.left = result0
    local result1 = buffer:readString()
    packet.middle = result1
    local result2 = buffer:readString()
    packet.right = result2
    if length > 0 then
        buffer:setReadOffset(beforeReadIndex + length)
    end
    return packet
end
function TripleLSS:protocolId()
    return 116
end

function TripleLSS:protocolName()
    return "TripleLSS"
end

function TripleLSS:__tostring()
    return table.serializeTableToJson(self)
end

function TripleLSS:write(buffer, packet)
    if packet == nil then
        buffer:writeInt(0)
        return
    end
    buffer:writeInt(-1)
    buffer:writeLong(packet.left)
    buffer:writeString(packet.middle)
    buffer:writeString(packet.right)
end

function TripleLSS:read(buffer)
    local length = buffer:readInt()
    if length == 0 then
        return nil
    end
    local beforeReadIndex = buffer:getReadOffset()
    local packet = TripleLSS:new()
    local result0 = buffer:readLong()
    packet.left = result0
    local result1 = buffer:readString()
    packet.middle = result1
    local result2 = buffer:readString()
    packet.right = result2
    if length > 0 then
        buffer:setReadOffset(beforeReadIndex + length)
    end
    return packet
end
function UdpHelloRequest:protocolId()
    return 1200
end

function UdpHelloRequest:protocolName()
    return "UdpHelloRequest"
end

function UdpHelloRequest:__tostring()
    return table.serializeTableToJson(self)
end

function UdpHelloRequest:write(buffer, packet)
    if packet == nil then
        buffer:writeInt(0)
        return
    end
    buffer:writeInt(-1)
    buffer:writeString(packet.message)
end

function UdpHelloRequest:read(buffer)
    local length = buffer:readInt()
    if length == 0 then
        return nil
    end
    local beforeReadIndex = buffer:getReadOffset()
    local packet = UdpHelloRequest:new()
    local result0 = buffer:readString()
    packet.message = result0
    if length > 0 then
        buffer:setReadOffset(beforeReadIndex + length)
    end
    return packet
end
function UdpHelloResponse:protocolId()
    return 1201
end

function UdpHelloResponse:protocolName()
    return "UdpHelloResponse"
end

function UdpHelloResponse:__tostring()
    return table.serializeTableToJson(self)
end

function UdpHelloResponse:write(buffer, packet)
    if packet == nil then
        buffer:writeInt(0)
        return
    end
    buffer:writeInt(-1)
    buffer:writeString(packet.message)
end

function UdpHelloResponse:read(buffer)
    local length = buffer:readInt()
    if length == 0 then
        return nil
    end
    local beforeReadIndex = buffer:getReadOffset()
    local packet = UdpHelloResponse:new()
    local result0 = buffer:readString()
    packet.message = result0
    if length > 0 then
        buffer:setReadOffset(beforeReadIndex + length)
    end
    return packet
end
function TcpHelloRequest:protocolId()
    return 1300
end

function TcpHelloRequest:protocolName()
    return "TcpHelloRequest"
end

function TcpHelloRequest:__tostring()
    return table.serializeTableToJson(self)
end

function TcpHelloRequest:write(buffer, packet)
    if packet == nil then
        buffer:writeInt(0)
        return
    end
    buffer:writeInt(-1)
    buffer:writeString(packet.message)
end

function TcpHelloRequest:read(buffer)
    local length = buffer:readInt()
    if length == 0 then
        return nil
    end
    local beforeReadIndex = buffer:getReadOffset()
    local packet = TcpHelloRequest:new()
    local result0 = buffer:readString()
    packet.message = result0
    if length > 0 then
        buffer:setReadOffset(beforeReadIndex + length)
    end
    return packet
end
function TcpHelloResponse:protocolId()
    return 1301
end

function TcpHelloResponse:protocolName()
    return "TcpHelloResponse"
end

function TcpHelloResponse:__tostring()
    return table.serializeTableToJson(self)
end

function TcpHelloResponse:write(buffer, packet)
    if packet == nil then
        buffer:writeInt(0)
        return
    end
    buffer:writeInt(-1)
    buffer:writeString(packet.message)
end

function TcpHelloResponse:read(buffer)
    local length = buffer:readInt()
    if length == 0 then
        return nil
    end
    local beforeReadIndex = buffer:getReadOffset()
    local packet = TcpHelloResponse:new()
    local result0 = buffer:readString()
    packet.message = result0
    if length > 0 then
        buffer:setReadOffset(beforeReadIndex + length)
    end
    return packet
end
function WebsocketHelloRequest:protocolId()
    return 1400
end

function WebsocketHelloRequest:protocolName()
    return "WebsocketHelloRequest"
end

function WebsocketHelloRequest:__tostring()
    return table.serializeTableToJson(self)
end

function WebsocketHelloRequest:write(buffer, packet)
    if packet == nil then
        buffer:writeInt(0)
        return
    end
    buffer:writeInt(-1)
    buffer:writeString(packet.message)
end

function WebsocketHelloRequest:read(buffer)
    local length = buffer:readInt()
    if length == 0 then
        return nil
    end
    local beforeReadIndex = buffer:getReadOffset()
    local packet = WebsocketHelloRequest:new()
    local result0 = buffer:readString()
    packet.message = result0
    if length > 0 then
        buffer:setReadOffset(beforeReadIndex + length)
    end
    return packet
end
function WebsocketHelloResponse:protocolId()
    return 1401
end

function WebsocketHelloResponse:protocolName()
    return "WebsocketHelloResponse"
end

function WebsocketHelloResponse:__tostring()
    return table.serializeTableToJson(self)
end

function WebsocketHelloResponse:write(buffer, packet)
    if packet == nil then
        buffer:writeInt(0)
        return
    end
    buffer:writeInt(-1)
    buffer:writeString(packet.message)
end

function WebsocketHelloResponse:read(buffer)
    local length = buffer:readInt()
    if length == 0 then
        return nil
    end
    local beforeReadIndex = buffer:getReadOffset()
    local packet = WebsocketHelloResponse:new()
    local result0 = buffer:readString()
    packet.message = result0
    if length > 0 then
        buffer:setReadOffset(beforeReadIndex + length)
    end
    return packet
end
function JsonHelloRequest:protocolId()
    return 1600
end

function JsonHelloRequest:protocolName()
    return "JsonHelloRequest"
end

function JsonHelloRequest:__tostring()
    return table.serializeTableToJson(self)
end

function JsonHelloRequest:write(buffer, packet)
    if packet == nil then
        buffer:writeInt(0)
        return
    end
    buffer:writeInt(-1)
    buffer:writeString(packet.message)
end

function JsonHelloRequest:read(buffer)
    local length = buffer:readInt()
    if length == 0 then
        return nil
    end
    local beforeReadIndex = buffer:getReadOffset()
    local packet = JsonHelloRequest:new()
    local result0 = buffer:readString()
    packet.message = result0
    if length > 0 then
        buffer:setReadOffset(beforeReadIndex + length)
    end
    return packet
end
function JsonHelloResponse:protocolId()
    return 1601
end

function JsonHelloResponse:protocolName()
    return "JsonHelloResponse"
end

function JsonHelloResponse:__tostring()
    return table.serializeTableToJson(self)
end

function JsonHelloResponse:write(buffer, packet)
    if packet == nil then
        buffer:writeInt(0)
        return
    end
    buffer:writeInt(-1)
    buffer:writeString(packet.message)
end

function JsonHelloResponse:read(buffer)
    local length = buffer:readInt()
    if length == 0 then
        return nil
    end
    local beforeReadIndex = buffer:getReadOffset()
    local packet = JsonHelloResponse:new()
    local result0 = buffer:readString()
    packet.message = result0
    if length > 0 then
        buffer:setReadOffset(beforeReadIndex + length)
    end
    return packet
end
function HttpHelloRequest:protocolId()
    return 1700
end

function HttpHelloRequest:protocolName()
    return "HttpHelloRequest"
end

function HttpHelloRequest:__tostring()
    return table.serializeTableToJson(self)
end

function HttpHelloRequest:write(buffer, packet)
    if packet == nil then
        buffer:writeInt(0)
        return
    end
    buffer:writeInt(-1)
    buffer:writeString(packet.message)
end

function HttpHelloRequest:read(buffer)
    local length = buffer:readInt()
    if length == 0 then
        return nil
    end
    local beforeReadIndex = buffer:getReadOffset()
    local packet = HttpHelloRequest:new()
    local result0 = buffer:readString()
    packet.message = result0
    if length > 0 then
        buffer:setReadOffset(beforeReadIndex + length)
    end
    return packet
end
function HttpHelloResponse:protocolId()
    return 1701
end

function HttpHelloResponse:protocolName()
    return "HttpHelloResponse"
end

function HttpHelloResponse:__tostring()
    return table.serializeTableToJson(self)
end

function HttpHelloResponse:write(buffer, packet)
    if packet == nil then
        buffer:writeInt(0)
        return
    end
    buffer:writeInt(-1)
    buffer:writeString(packet.message)
end

function HttpHelloResponse:read(buffer)
    local length = buffer:readInt()
    if length == 0 then
        return nil
    end
    local beforeReadIndex = buffer:getReadOffset()
    local packet = HttpHelloResponse:new()
    local result0 = buffer:readString()
    packet.message = result0
    if length > 0 then
        buffer:setReadOffset(beforeReadIndex + length)
    end
    return packet
end
function WebSocketPacketRequest:protocolId()
    return 2070
end

function WebSocketPacketRequest:protocolName()
    return "WebSocketPacketRequest"
end

function WebSocketPacketRequest:__tostring()
    return table.serializeTableToJson(self)
end

function WebSocketPacketRequest:write(buffer, packet)
    if packet == nil then
        buffer:writeInt(0)
        return
    end
    buffer:writeInt(-1)
    buffer:writeByte(packet.a)
    buffer:writeByte(packet.aa)
    buffer:writeByteArray(packet.aaa)
    buffer:writeByteArray(packet.aaaa)
    buffer:writeShort(packet.b)
    buffer:writeShort(packet.bb)
    buffer:writeShortArray(packet.bbb)
    buffer:writeShortArray(packet.bbbb)
    buffer:writeInt(packet.c)
    buffer:writeInt(packet.cc)
    buffer:writeIntArray(packet.ccc)
    buffer:writeIntArray(packet.cccc)
    buffer:writeLong(packet.d)
    buffer:writeLongArray(packet.dd)
    buffer:writeFloat(packet.e)
    buffer:writeFloat(packet.ee)
    buffer:writeFloatArray(packet.eee)
    buffer:writeFloatArray(packet.eeee)
    buffer:writeDouble(packet.f)
    buffer:writeDouble(packet.ff)
    buffer:writeDoubleArray(packet.fff)
    buffer:writeDoubleArray(packet.ffff)
    buffer:writeString(packet.jj)
    buffer:writeStringArray(packet.jjj)
    buffer:writePacket(packet.kk, 2071)
    buffer:writePacketArray(packet.kkk, 2071)
    buffer:writeIntArray(packet.l)
    if packet.ll == null then
        buffer:writeInt(0)
    else
        buffer:writeInt(#packet.ll)
        for index0, element1 in pairs(packet.ll) do
            if element1 == null then
                buffer:writeInt(0)
            else
                buffer:writeInt(#element1)
                for index2, element3 in pairs(element1) do
                    buffer:writeIntArray(element3)
                end
            end
        end
    end
    if packet.lll == null then
        buffer:writeInt(0)
    else
        buffer:writeInt(#packet.lll)
        for index4, element5 in pairs(packet.lll) do
            buffer:writePacketArray(element5, 2071)
        end
    end
    buffer:writeStringArray(packet.llll)
    if packet.lllll == null then
        buffer:writeInt(0)
    else
        buffer:writeInt(#packet.lllll)
        for index6, element7 in pairs(packet.lllll) do
            buffer:writeIntStringMap(element7)
        end
    end
    buffer:writeIntStringMap(packet.m)
    buffer:writeIntPacketMap(packet.mm, 2071)
    if packet.mmm == null then
        buffer:writeInt(0)
    else
        buffer:writeInt(table.mapSize(packet.mmm))
        for key8, value9 in pairs(packet.mmm) do
            buffer:writePacket(key8, 2071)
            buffer:writeIntArray(value9)
        end
    end
    if packet.mmmm == null then
        buffer:writeInt(0)
    else
        buffer:writeInt(table.mapSize(packet.mmmm))
        for key10, value11 in pairs(packet.mmmm) do
            if key10 == null then
                buffer:writeInt(0)
            else
                buffer:writeInt(#key10)
                for index12, element13 in pairs(key10) do
                    buffer:writePacketArray(element13, 2071)
                end
            end
            if value11 == null then
                buffer:writeInt(0)
            else
                buffer:writeInt(#value11)
                for index14, element15 in pairs(value11) do
                    if element15 == null then
                        buffer:writeInt(0)
                    else
                        buffer:writeInt(#element15)
                        for index16, element17 in pairs(element15) do
                            buffer:writeIntArray(element17)
                        end
                    end
                end
            end
        end
    end
    buffer:writeIntArray(packet.s)
    if packet.ss == null then
        buffer:writeInt(0)
    else
        buffer:writeInt(#packet.ss)
        for index18, element19 in pairs(packet.ss) do
            if element19 == null then
                buffer:writeInt(0)
            else
                buffer:writeInt(#element19)
                for index20, element21 in pairs(element19) do
                    buffer:writeIntArray(element21)
                end
            end
        end
    end
    if packet.sss == null then
        buffer:writeInt(0)
    else
        buffer:writeInt(#packet.sss)
        for index22, element23 in pairs(packet.sss) do
            buffer:writePacketArray(element23, 2071)
        end
    end
    buffer:writeStringArray(packet.ssss)
    if packet.sssss == null then
        buffer:writeInt(0)
    else
        buffer:writeInt(#packet.sssss)
        for index24, element25 in pairs(packet.sssss) do
            buffer:writeIntStringMap(element25)
        end
    end
end

function WebSocketPacketRequest:read(buffer)
    local length = buffer:readInt()
    if length == 0 then
        return nil
    end
    local beforeReadIndex = buffer:getReadOffset()
    local packet = WebSocketPacketRequest:new()
    local result0 = buffer:readByte()
    packet.a = result0
    local result1 = buffer:readByte()
    packet.aa = result1
    local array2 = buffer:readByteArray()
    packet.aaa = array2
    local array3 = buffer:readByteArray()
    packet.aaaa = array3
    local result4 = buffer:readShort()
    packet.b = result4
    local result5 = buffer:readShort()
    packet.bb = result5
    local array6 = buffer:readShortArray()
    packet.bbb = array6
    local array7 = buffer:readShortArray()
    packet.bbbb = array7
    local result8 = buffer:readInt()
    packet.c = result8
    local result9 = buffer:readInt()
    packet.cc = result9
    local array10 = buffer:readIntArray()
    packet.ccc = array10
    local array11 = buffer:readIntArray()
    packet.cccc = array11
    local result12 = buffer:readLong()
    packet.d = result12
    local array13 = buffer:readLongArray()
    packet.dd = array13
    local result14 = buffer:readFloat()
    packet.e = result14
    local result15 = buffer:readFloat()
    packet.ee = result15
    local array16 = buffer:readFloatArray()
    packet.eee = array16
    local array17 = buffer:readFloatArray()
    packet.eeee = array17
    local result18 = buffer:readDouble()
    packet.f = result18
    local result19 = buffer:readDouble()
    packet.ff = result19
    local array20 = buffer:readDoubleArray()
    packet.fff = array20
    local array21 = buffer:readDoubleArray()
    packet.ffff = array21
    local result22 = buffer:readString()
    packet.jj = result22
    local array23 = buffer:readStringArray()
    packet.jjj = array23
    local result24 = buffer:readPacket(2071)
    packet.kk = result24
    local array25 = buffer:readPacketArray(2071)
    packet.kkk = array25
    local list26 = buffer:readIntArray()
    packet.l = list26
    local result27 = {}
    local size28 = buffer:readInt()
    if size28 > 0 then
        for index29 = 1, size28 do
            local result30 = {}
            local size31 = buffer:readInt()
            if size31 > 0 then
                for index32 = 1, size31 do
                    local list33 = buffer:readIntArray()
                    table.insert(result30, list33)
                end
            end
            table.insert(result27, result30)
        end
    end
    packet.ll = result27
    local result34 = {}
    local size35 = buffer:readInt()
    if size35 > 0 then
        for index36 = 1, size35 do
            local list37 = buffer:readPacketArray(2071)
            table.insert(result34, list37)
        end
    end
    packet.lll = result34
    local list38 = buffer:readStringArray()
    packet.llll = list38
    local result39 = {}
    local size40 = buffer:readInt()
    if size40 > 0 then
        for index41 = 1, size40 do
            local map42 = buffer:readIntStringMap()
            table.insert(result39, map42)
        end
    end
    packet.lllll = result39
    local map43 = buffer:readIntStringMap()
    packet.m = map43
    local map44 = buffer:readIntPacketMap(2071)
    packet.mm = map44
    local result45 = {}
    local size46 = buffer:readInt()
    if size46 > 0 then
        for index47 = 1, size46 do
            local result48 = buffer:readPacket(2071)
            local list49 = buffer:readIntArray()
            result45[result48] = list49
        end
    end
    packet.mmm = result45
    local result50 = {}
    local size51 = buffer:readInt()
    if size51 > 0 then
        for index52 = 1, size51 do
            local result53 = {}
            local size54 = buffer:readInt()
            if size54 > 0 then
                for index55 = 1, size54 do
                    local list56 = buffer:readPacketArray(2071)
                    table.insert(result53, list56)
                end
            end
            local result57 = {}
            local size58 = buffer:readInt()
            if size58 > 0 then
                for index59 = 1, size58 do
                    local result60 = {}
                    local size61 = buffer:readInt()
                    if size61 > 0 then
                        for index62 = 1, size61 do
                            local list63 = buffer:readIntArray()
                            table.insert(result60, list63)
                        end
                    end
                    table.insert(result57, result60)
                end
            end
            result50[result53] = result57
        end
    end
    packet.mmmm = result50
    local set64 = buffer:readIntArray()
    packet.s = set64
    local result65 = {}
    local size66 = buffer:readInt()
    if size66 > 0 then
        for index67 = 1, size66 do
            local result68 = {}
            local size69 = buffer:readInt()
            if size69 > 0 then
                for index70 = 1, size69 do
                    local list71 = buffer:readIntArray()
                    table.insert(result68, list71)
                end
            end
            table.insert(result65, result68)
        end
    end
    packet.ss = result65
    local result72 = {}
    local size73 = buffer:readInt()
    if size73 > 0 then
        for index74 = 1, size73 do
            local set75 = buffer:readPacketArray(2071)
            table.insert(result72, set75)
        end
    end
    packet.sss = result72
    local set76 = buffer:readStringArray()
    packet.ssss = set76
    local result77 = {}
    local size78 = buffer:readInt()
    if size78 > 0 then
        for index79 = 1, size78 do
            local map80 = buffer:readIntStringMap()
            table.insert(result77, map80)
        end
    end
    packet.sssss = result77
    if length > 0 then
        buffer:setReadOffset(beforeReadIndex + length)
    end
    return packet
end
function WebSocketObjectA:protocolId()
    return 2071
end

function WebSocketObjectA:protocolName()
    return "WebSocketObjectA"
end

function WebSocketObjectA:__tostring()
    return table.serializeTableToJson(self)
end

function WebSocketObjectA:write(buffer, packet)
    if packet == nil then
        buffer:writeInt(0)
        return
    end
    buffer:writeInt(-1)
    buffer:writeInt(packet.a)
    buffer:writePacket(packet.objectB, 2072)
end

function WebSocketObjectA:read(buffer)
    local length = buffer:readInt()
    if length == 0 then
        return nil
    end
    local beforeReadIndex = buffer:getReadOffset()
    local packet = WebSocketObjectA:new()
    local result0 = buffer:readInt()
    packet.a = result0
    local result1 = buffer:readPacket(2072)
    packet.objectB = result1
    if length > 0 then
        buffer:setReadOffset(beforeReadIndex + length)
    end
    return packet
end
function WebSocketObjectB:protocolId()
    return 2072
end

function WebSocketObjectB:protocolName()
    return "WebSocketObjectB"
end

function WebSocketObjectB:__tostring()
    return table.serializeTableToJson(self)
end

function WebSocketObjectB:write(buffer, packet)
    if packet == nil then
        buffer:writeInt(0)
        return
    end
    buffer:writeInt(-1)
    buffer:writeBool(packet.flag)
end

function WebSocketObjectB:read(buffer)
    local length = buffer:readInt()
    if length == 0 then
        return nil
    end
    local beforeReadIndex = buffer:getReadOffset()
    local packet = WebSocketObjectB:new()
    local result0 = buffer:readBool()
    packet.flag = result0
    if length > 0 then
        buffer:setReadOffset(beforeReadIndex + length)
    end
    return packet
end
function GatewayToProviderRequest:protocolId()
    return 5000
end

function GatewayToProviderRequest:protocolName()
    return "GatewayToProviderRequest"
end

function GatewayToProviderRequest:__tostring()
    return table.serializeTableToJson(self)
end

function GatewayToProviderRequest:write(buffer, packet)
    if packet == nil then
        buffer:writeInt(0)
        return
    end
    buffer:writeInt(-1)
    buffer:writeString(packet.message)
end

function GatewayToProviderRequest:read(buffer)
    local length = buffer:readInt()
    if length == 0 then
        return nil
    end
    local beforeReadIndex = buffer:getReadOffset()
    local packet = GatewayToProviderRequest:new()
    local result0 = buffer:readString()
    packet.message = result0
    if length > 0 then
        buffer:setReadOffset(beforeReadIndex + length)
    end
    return packet
end
function GatewayToProviderResponse:protocolId()
    return 5001
end

function GatewayToProviderResponse:protocolName()
    return "GatewayToProviderResponse"
end

function GatewayToProviderResponse:__tostring()
    return table.serializeTableToJson(self)
end

function GatewayToProviderResponse:write(buffer, packet)
    if packet == nil then
        buffer:writeInt(0)
        return
    end
    buffer:writeInt(-1)
    buffer:writeString(packet.message)
end

function GatewayToProviderResponse:read(buffer)
    local length = buffer:readInt()
    if length == 0 then
        return nil
    end
    local beforeReadIndex = buffer:getReadOffset()
    local packet = GatewayToProviderResponse:new()
    local result0 = buffer:readString()
    packet.message = result0
    if length > 0 then
        buffer:setReadOffset(beforeReadIndex + length)
    end
    return packet
end

Protocols.SignalAttachment = SignalAttachment
Protocols.Message = Message
Protocols.Error = Error
Protocols.Heartbeat = Heartbeat
Protocols.Ping = Ping
Protocols.Pong = Pong
Protocols.PairIntLong = PairIntLong
Protocols.PairLong = PairLong
Protocols.PairString = PairString
Protocols.PairLS = PairLS
Protocols.TripleLong = TripleLong
Protocols.TripleString = TripleString
Protocols.TripleLSS = TripleLSS
Protocols.UdpHelloRequest = UdpHelloRequest
Protocols.UdpHelloResponse = UdpHelloResponse
Protocols.TcpHelloRequest = TcpHelloRequest
Protocols.TcpHelloResponse = TcpHelloResponse
Protocols.WebsocketHelloRequest = WebsocketHelloRequest
Protocols.WebsocketHelloResponse = WebsocketHelloResponse
Protocols.JsonHelloRequest = JsonHelloRequest
Protocols.JsonHelloResponse = JsonHelloResponse
Protocols.HttpHelloRequest = HttpHelloRequest
Protocols.HttpHelloResponse = HttpHelloResponse
Protocols.WebSocketPacketRequest = WebSocketPacketRequest
Protocols.WebSocketObjectA = WebSocketObjectA
Protocols.WebSocketObjectB = WebSocketObjectB
Protocols.GatewayToProviderRequest = GatewayToProviderRequest
Protocols.GatewayToProviderResponse = GatewayToProviderResponse

return Protocols