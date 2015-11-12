Imports System.Xml


Module Module1

    Sub Main()
        Dim cont As Integer = 1
        Dim elemento As String

        Dim reader As XmlTextReader = New XmlTextReader("C:\Users\Yourbroda\Documents\DA32\Acceso a datos\media\xml1.xml")
        Do While (reader.Read())
            Console.WriteLine()
            Select Case reader.NodeType
                Case XmlNodeType.Element
                    If (reader.Name = elemento) Then
                        cont = 1
                    End If
                    If (cont = 1) Then
                        elemento = reader.Name
                    Else
                        For index As Integer = 1 To cont
                            Console.Write(ControlChars.Tab)
                        Next

                    End If
                    cont = cont + 1

                    Console.Write("<" + reader.Name)
                    If (reader.HasAttributes) Then
                        While reader.MoveToNextAttribute
                            Console.Write("{0}='{1}'", reader.Name, reader.Value)
                        End While
                    End If
                    Console.Write(">")

                Case XmlNodeType.Text
                    If (reader.Name = elemento) Then
                        cont = 1
                    End If
                    If (cont = 1) Then
                        elemento = reader.Name
                    Else
                        For index As Integer = 1 To cont
                            Console.Write(ControlChars.Tab)
                        Next

                    End If
                    Console.Write(reader.Value)
                Case XmlNodeType.EndElement
                    cont = cont - 1
                    If (reader.Name = elemento) Then
                        cont = 1
                    End If
                    If (cont = 1) Then
                        elemento = reader.Name
                    Else
                        For index As Integer = 1 To cont
                            Console.Write(ControlChars.Tab)
                        Next

                    End If
                    Console.Write("</" + reader.Name)
                    Console.Write(">")
                    Console.WriteLine()


            End Select

        Loop


        Console.Read()
        reader.Close()
    End Sub

End Module
