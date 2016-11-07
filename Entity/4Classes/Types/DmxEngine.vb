
Imports System.Runtime.InteropServices
Imports System.Threading
Imports System.Windows.Forms
Namespace _4Classes.Types
    Public Class DmxEngine

        Public Shared buffer As Byte() = New Byte(512) {}
        Public Shared handle As UInteger
        Public Shared done As Boolean = False
        Public Shared Connected As Boolean = False
        Public Shared bytesWritten As Integer = 0
        Public Shared status As FT_STATUS
        Public Shared th As Thread

        Public Const BITS_8 As Byte = 8
        Public Const STOP_BITS_2 As Byte = 2
        Public Const PARITY_NONE As Byte = 0
        Public Const FLOW_NONE As UInt16 = 0
        Public Const PURGE_RX As Byte = 1
        Public Const PURGE_TX As Byte = 2


        <DllImport("FTD2XX.dll")> _
        Public Shared Function FT_Open(uiPort As UInt32, ByRef ftHandle As UInteger) As FT_STATUS
        End Function
        <DllImport("FTD2XX.dll")> _
        Public Shared Function FT_Close(ftHandle As UInteger) As FT_STATUS
        End Function
        <DllImport("FTD2XX.dll")> _
        Public Shared Function FT_Read(ftHandle As UInteger, lpBuffer As IntPtr, dwBytesToRead As UInt32, ByRef lpdwBytesReturned As UInt32) As FT_STATUS
        End Function
        <DllImport("FTD2XX.dll")> _
        Public Shared Function FT_Write(ftHandle As UInteger, lpBuffer As IntPtr, dwBytesToRead As UInt32, ByRef lpdwBytesWritten As UInt32) As FT_STATUS
        End Function
        <DllImport("FTD2XX.dll")> _
        Public Shared Function FT_SetDataCharacteristics(ftHandle As UInteger, uWordLength As Byte, uStopBits As Byte, uParity As Byte) As FT_STATUS
        End Function
        <DllImport("FTD2XX.dll")> _
        Public Shared Function FT_SetFlowControl(ftHandle As UInteger, usFlowControl As Char, uXon As Byte, uXoff As Byte) As FT_STATUS
        End Function
        <DllImport("FTD2XX.dll")> _
        Public Shared Function FT_GetModemStatus(ftHandle As UInteger, ByRef lpdwModemStatus As UInt32) As FT_STATUS
        End Function
        <DllImport("FTD2XX.dll")> _
        Public Shared Function FT_Purge(ftHandle As UInteger, dwMask As UInt32) As FT_STATUS
        End Function
        <DllImport("FTD2XX.dll")> _
        Public Shared Function FT_ClrRts(ftHandle As UInteger) As FT_STATUS
        End Function
        <DllImport("FTD2XX.dll")> _
        Public Shared Function FT_SetBreakOn(ftHandle As UInteger) As FT_STATUS
        End Function
        <DllImport("FTD2XX.dll")> _
        Public Shared Function FT_SetBreakOff(ftHandle As UInteger) As FT_STATUS
        End Function
        <DllImport("FTD2XX.dll")> _
        Public Shared Function FT_GetStatus(ftHandle As UInteger, ByRef lpdwAmountInRxQueue As UInt32, ByRef lpdwAmountInTxQueue As UInt32, ByRef lpdwEventStatus As UInt32) As FT_STATUS
        End Function
        <DllImport("FTD2XX.dll")> _
        Public Shared Function FT_ResetDevice(ftHandle As UInteger) As FT_STATUS
        End Function
        <DllImport("FTD2XX.dll")> _
        Public Shared Function FT_SetDivisor(ftHandle As UInteger, usDivisor As Char) As FT_STATUS
        End Function


        Public Shared Sub initialize()
            handle = 0
            status = FT_Open(0, handle)
            'setting up the WriteData method to be on it's own thread. This will also turn all channels off
            'this unrequested change of state can be managed by getting the current state of all channels 
            'into the write buffer before calling this function.
            th = New Thread(New ThreadStart(AddressOf writeData))
            th.Start()
        End Sub

        Public Shared Sub SetDmxValue(channel As Integer, value As Byte)
            If buffer IsNot Nothing Then
                buffer(channel) = value
            End If
        End Sub
        Public Shared Sub setDmx(value As Byte())
            buffer = value
        End Sub
        Public Shared Sub writeData()
            Try
                initOpenDMX()
                If DmxEngine.status = FT_STATUS.FT_OK Then
                    status = FT_SetBreakOn(handle)
                    status = FT_SetBreakOff(handle)
                    bytesWritten = write(handle, buffer, buffer.Length)

                    'give the system time to send the data before sending more 
                    Thread.Sleep(25)
                End If
            Catch exp As Exception
                MsgBox(exp)
            End Try

        End Sub

        Public Shared Function write(handle As UInteger, data As Byte(), length As Integer) As Integer
            Try
                Dim ptr As IntPtr = Marshal.AllocHGlobal(CInt(length))
                Marshal.Copy(data, 0, ptr, CInt(length))
                Dim bytesWritten As UInteger = 0
                status = FT_Write(handle, ptr, CUInt(length), bytesWritten)
                Return CInt(bytesWritten)
            Catch exp As Exception
                Console.WriteLine(exp)
                Return 0
            End Try
        End Function

        Public Shared Sub initOpenDMX()
            status = FT_ResetDevice(handle)
            status = FT_SetDivisor(handle, ChrW(12))
            ' set baud rate
            status = FT_SetDataCharacteristics(handle, BITS_8, STOP_BITS_2, PARITY_NONE)
            status = FT_SetFlowControl(handle, ChrW(FLOW_NONE), 0, 0)
            status = FT_ClrRts(handle)
            status = FT_Purge(handle, PURGE_TX)
            status = FT_Purge(handle, PURGE_RX)
        End Sub
        Public Shared Sub abortThread()
            th.Abort()
        End Sub
    End Class

    ''' <summary>
    ''' Enumaration containing the varios return status for the DLL functions.
    ''' </summary>
    Public Enum FT_STATUS
        FT_OK = 0
        FT_INVALID_HANDLE
        FT_DEVICE_NOT_FOUND
        FT_DEVICE_NOT_OPENED
        FT_IO_ERROR
        FT_INSUFFICIENT_RESOURCES
        FT_INVALID_PARAMETER
        FT_INVALID_BAUD_RATE
        FT_DEVICE_NOT_OPENED_FOR_ERASE
        FT_DEVICE_NOT_OPENED_FOR_WRITE
        FT_FAILED_TO_WRITE_DEVICE
        FT_EEPROM_READ_FAILED
        FT_EEPROM_WRITE_FAILED
        FT_EEPROM_ERASE_FAILED
        FT_EEPROM_NOT_PRESENT
        FT_EEPROM_NOT_PROGRAMMED
        FT_INVALID_ARGS
        FT_OTHER_ERROR
    End Enum
End Namespace