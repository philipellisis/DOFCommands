Imports System.Security.Policy
Imports DirectOutput.Cab
Imports DirectOutput.Cab.Out.ComPort
Imports DirectOutput.Cab.Out.PinOne
Module Module1
    Dim one As PinOne
    Sub Main(args As String())
        ' Check for sufficient arguments
        If args.Length < 3 Then
            Console.WriteLine("Usage: [output item] [output value] [wait time in milliseconds]")
            Return
        End If

        ' Parse command line arguments
        Dim outputItem As Integer
        Dim outputValue As Integer
        Dim waitTime As Integer

        ' Try to convert the arguments into integers
        If Integer.TryParse(args(0), outputItem) AndAlso
           Integer.TryParse(args(1), outputValue) AndAlso
           Integer.TryParse(args(2), waitTime) Then
            ' Initialize the PinOne device
            Dim comPort As String = PinOneAutoConfigurator.GetDevice
            Dim one As New PinOne(comPort)
            Dim cab As New DirectOutput.Cab.Cabinet
            Dim CO As CabinetOwner = New CabinetOwner()
            cab.Init(CO)
            one.Init(cab)

            ' Set output based on command line arguments
            one.Outputs.Item(outputItem).Value = outputValue
            one.Update()
            Threading.Thread.Sleep(waitTime)
            one.Finish()
        Else
            Console.WriteLine("Invalid input. Please ensure all inputs are integers.")
        End If
    End Sub

End Module
