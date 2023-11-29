
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

function SignalAttachment:protocolId()
    return 0
end

function SignalAttachment:protocolName()
    return SignalAttachment
end

function SignalAttachment:__tostring()
    local jsonTemplate = "{signalId:%s, taskExecutorHash:%s, client:%s, timestamp:%s}"
    local result = string.format(jsonTemplate, self.signalId, self.taskExecutorHash, self.client, self.timestamp)
    return result
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

return SignalAttachment
