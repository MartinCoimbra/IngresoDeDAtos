Imports MySql.Data.MySqlClient
Public Class Form1
    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        Dim conexion As MySqlConnection
        conexion = New MySqlConnection
        Dim cmd As New MySqlCommand
        Dim ds As DataSet = New DataSet
        Dim adaptador As MySqlDataAdapter = New MySqlDataAdapter

        conexion.ConnectionString = "server=localhost; database=encuesta;Uid=root;Pwd=;"



        If txtNombre.Text = "" Or txtApellido.Text = "" Or cbserie.Text = "" Then

            MessageBox.Show("Error, ingrese los datos correspondientes", "Datos ERRONEOS", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Else
            Try

                ' MsgBox("Conectado con la base de datos.")

                conexion.Open()

                cmd.Connection = conexion
                cmd.CommandText = "INSERT INTO encuesta_series(nombre, apellido, serie_favorita) VALUES (@nombre, @apellido, @serie_favorita)"
                cmd.Prepare()

                cmd.Parameters.AddWithValue("@nombre", txtNombre.Text)
                cmd.Parameters.AddWithValue("@apellido", txtApellido.Text)
                cmd.Parameters.AddWithValue("@serie_favorita", cbserie.Text)
                cmd.ExecuteNonQuery()

                cmd.CommandText = "SELECT * FROM encuesta_series ORDER BY id ASC"
                adaptador.SelectCommand = cmd
                adaptador.Fill(ds, "Tabla")
                grdTabla.DataSource = ds
                grdTabla.DataMember = "Tabla"

                conexion.Close()
                txtNombre.Clear()
                txtApellido.Clear()
                cbserie.Text = ""
                MsgBox("Datos igresados.")

            Catch ex As Exception
                MsgBox("No ha conectado con la base de datos.")
            End Try
        End If
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        End
    End Sub

    Private Sub btnActualizar_Click(sender As Object, e As EventArgs) Handles btnActualizar.Click
        Dim adaptador As MySqlDataAdapter = New MySqlDataAdapter
        Dim cmd As New MySqlCommand
        Dim ds As DataSet = New DataSet
        Dim conexion As MySqlConnection
        conexion = New MySqlConnection
        conexion.ConnectionString = "server=localhost; database=encuesta;Uid=root;Pwd=;"

        Try

            conexion.Open()
            cmd.Connection = conexion
            cmd.CommandText = "SELECT * FROM encuesta_series ORDER BY id ASC"
            adaptador.SelectCommand = cmd
            adaptador.Fill(ds, "Tabla")
            grdTabla.DataSource = ds
            grdTabla.DataMember = "Tabla"
            conexion.Close()

        Catch ex As Exception
            MsgBox("No ha conectado con la base de datos.")

        End Try

    End Sub

End Class
