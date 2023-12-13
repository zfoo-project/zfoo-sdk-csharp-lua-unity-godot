
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
        message = "", -- string
        module = 0 -- byte
    }
    setmetatable(obj, self)
    self.__index = self
    return obj
end

local Error = {}
function Error:new()
    local obj = {
        errorCode = 0, -- int
        errorMessage = "", -- string
        module = 0 -- int
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

local JProtobufHelloRequest = {}
function JProtobufHelloRequest:new()
    local obj = {
        message = "" -- string
    }
    setmetatable(obj, self)
    self.__index = self
    return obj
end

local JProtobufHelloResponse = {}
function JProtobufHelloResponse:new()
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

local Protocols = {}
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
Protocols.JProtobufHelloRequest = JProtobufHelloRequest
Protocols.JProtobufHelloResponse = JProtobufHelloResponse
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