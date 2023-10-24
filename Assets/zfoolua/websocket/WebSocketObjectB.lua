
local WebSocketObjectB = {}

function WebSocketObjectB:new()
    local obj = {
        flag = false -- bool
    }
    setmetatable(obj, self)
    self.__index = self
    return obj
end

function WebSocketObjectB:protocolId()
    return 2072
end

function WebSocketObjectB:write(buffer, packet)
    if packet == nil then
        buffer:writeInt(0)
        return
    end
    buffer:writeInt(-1)
    buffer:writeBoolean(packet.flag)
end

function WebSocketObjectB:read(buffer)
    local length = buffer:readInt()
    if length == 0 then
        return nil
    end
    local beforeReadIndex = buffer:getReadOffset()
    local packet = WebSocketObjectB:new()
    local result0 = buffer:readBoolean()
    packet.flag = result0
    if length > 0 then
        buffer:setReadOffset(beforeReadIndex + length)
    end
    return packet
end

return WebSocketObjectB
