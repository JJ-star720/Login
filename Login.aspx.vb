Imports System.Data.SqlClient

Public Class Login
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnLogin_Click(sender As Object, e As EventArgs)

        Dim email As String = txtEmail.Text
        Dim password As String = txtPass.Text
        Dim usuario As New Usuario() With {
            .Email = email,
            .Password = password
        }
        Dim dbHelper As New DatabaseHelper()
        'Validar el usuario 
        Dim parametros As New List(Of SqlParameter) From {
            New SqlParameter("@Email", email),
            New SqlParameter("@Password", password)
        }

        If Not usuario.Validar() Then
            If email = "test@example.com" And password = "password" Then

                Response.Redirect("Welcome.aspx")
            Else

                lblError.Text = "Correo electrónico o contraseña inválidos."
                lblError.Visible = True
            End If
        Else
            lblError.Text = "Por favor, ingrese un correo electrónico y una contraseña válidos."
            lblError.Visible = True
        End If


    End Sub
End Class