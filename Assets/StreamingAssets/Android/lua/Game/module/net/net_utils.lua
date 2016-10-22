m_net_write = NetWorkScript.Instance

function net_write(type, area, command, message)
	m_net_write:write(type, area, command, message)
end

function net_write_int_message(type, area, command, message)
	m_net_write:writeIntMessage(type, area, command, message)
end