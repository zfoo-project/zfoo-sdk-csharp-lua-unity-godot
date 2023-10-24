
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

function Error:protocolId()
    return 101
end

function Error:write(buffer, packet)
    if packet == nil then
        buffer:writeInt(0)
        return
    end
    buffer:writeInt(-1)
    buffer:writeInt(packet.errorCode)
    buffer:writeString(packet.errorMessage)
    buffer:writeInt(packet.module)
end

function Error:read(buffer)
    local length = buffer:readInt()
    if length == 0 then
        return nil
    end
    local beforeReadIndex = buffer:getReadOffset()
    local packet = Error:new()
    local result0 = buffer:readInt()
    packet.errorCode = result0
    local result1 = buffer:readString()
    packet.errorMessage = result1
    local result2 = buffer:readInt()
    packet.module = result2
    if length > 0 then
        buffer:setReadOffset(beforeReadIndex + length)
    end
    return packet
end

return Error
