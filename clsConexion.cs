using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

//librerias requeridas
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;


namespace ControlSeguridadBD
{

   
    class clsConexion
    {
        //variable para la conexión.
        SqlConnection sqlconex;
        //contiene la instrucción que se le envía a la BD.
        SqlCommand inst;
        //variable para leer registros.
        SqlDataReader rsregis ;
        
        // variables globales de busqueda de rol
        private string rol;
        private string scheRol;
     
        public clsConexion()
        {
            try
            {
               
             
                sqlconex = new SqlConnection("Data Source =.; Initial Catalog = clinicasCR; Integrated Security=True");//Se eliminan el usuario y contraseña
                sqlconex.Open();

            }
            catch (Exception error)
            {
                MessageBox.Show("No se pudo realizar la conexión " + error.ToString());
            }
           
          
        }
    

        public string conectar(string user, string contra)
        {
            string usuario;
            string contraseña;
            string mensaje = "conectado satisfactoriamente";

            try
            {


                if (user != "" && contra != "")
                {
                    usuario = user;
                    contraseña = contra;
                    sqlconex = new SqlConnection("Data Source=.;Initial Catalog= clinicasCR;User ID=" + user + ";Password=" + contra);
                    sqlconex.Open();
                    MessageBox.Show("La conexión fue exitosa");
                    // 
                    ControlRoles ven = new ControlRoles();
                    ven.ShowDialog();

                    ControlUsuario ventana = new ControlUsuario();
                    ventana.ShowDialog();
                }
                else
                {

                    MessageBox.Show("intentelo nuevamente, espacion en blanco");
                }

            }
            catch (Exception error)
            {
                mensaje = "No se pudo conectar " + error.ToString();
            }
            return mensaje;
        }// final de concetar
         //--------------------------------------------------------------------------------------------------------
         //--------------------------ROLES------------------ROLES-------------------ROLES--------------------------
         //________________________________________________________________________________________________________


        public string insertarrol(string nom, string esquema)
        {
            string mensaje = "Registro insertado satisfactoriamente";
            try
            {
                //instrucción para insertar en la BD
                inst = new SqlCommand("CREATE ROLE " + nom + " AUTHORIZATION " + esquema, sqlconex);
                inst.ExecuteNonQuery();
            }
            catch (Exception error)
            {
                mensaje = "No se realizó la inserción " + error.ToString();
            }
            return mensaje;
        } // fin de insertarrol

        public string agrePermiso(string nom, string tabla, string rol)
        {
            string mensaje = "Permiso Asignado satisfactoriamente";
            try
            {
                //instrucción para insertar en la BD
                inst = new SqlCommand("GRANT " + nom + " on " + tabla + " to " + rol, sqlconex);
                inst.ExecuteNonQuery();
            }
            catch (Exception error)
            {
                mensaje = "No se realizó la Asignacion de Permisos " + error.ToString();
            }
            return mensaje;
        } // fin de insertarrol

        public string denePermiso(string nom, string tabla, string rol)
        {
            // nom: nombre del permiso
            // tabla: tabla sobre la que se le niega el permiso
            // rol: sobre que tendra 
            string mensaje = "Permisos denegados Satisfactoriamente";
            try
            {
                //instrucción para insertar en la BD
                inst = new SqlCommand("DENY " + nom + " on " + tabla + " to " + rol, sqlconex);
                inst.ExecuteNonQuery();
            }
            catch (Exception error)
            {
                mensaje = "No se realizó la denegacion del permiso" + error.ToString();
            }
            return mensaje;
        } // fin de insertarrol

        public string agreUsuario(string rol, string usuario)
        {
            string mensaje = "Usuario Agregado";
            try
            {
                //instrucción para insertar en la BD
                inst = new SqlCommand(" ALTER ROLE " + rol + " ADD MEMBER " + usuario, sqlconex);
                inst.ExecuteNonQuery();
            }
            catch (Exception error)
            {
                mensaje = "No se agrego el usuario " + error.ToString();
            }
            return mensaje;
        } // fin de insertarrol

        public string quitarUsuario(string rol, string usuario)
        {
            string mensaje = "Usuario Eliminado";
            try
            {
                //instrucción para insertar en la BD
                inst = new SqlCommand(" ALTER ROLE " + rol + " DROP MEMBER " + usuario, sqlconex);
                inst.ExecuteNonQuery();
            }
            catch (Exception error)
            {
                mensaje = "No se elimino el usuario " + error.ToString();
            }
            return mensaje;
        } // fin de quitarUsuario

        public string modificarRolName(string nom, string nomNew)
        {
            string mensaje = "Rol modificado satisfactoriamente";
            try
            {
                //instrucción para modificar en la BD
                inst = new SqlCommand("ALTER ROLE " + nom + " WITH NAME = " + nomNew + "", sqlconex);
                inst.ExecuteNonQuery();//ejecución de una acción sobre la base de datos (inserciones, modificaciones o eliminar).
            }
            catch (Exception error)
            {
                mensaje = "No se realizó la modificación " + error.ToString();
            }
            return mensaje;
        }// fin de modificarRol

        public string modificarRolEsquema(string nom, string nomNew)
        {
            string mensaje = "Esquema de Rol modificado satisfactoriamente";
            try
            {
                //instrucción para modificar en la BD
                inst = new SqlCommand("ALTER ROLE " + nom + " AUTHORIZATION " + nomNew + "", sqlconex);
                inst.ExecuteNonQuery();//ejecución de una acción sobre la base de datos (inserciones, modificaciones o eliminar).
            }
            catch (Exception error)
            {
                mensaje = "No se realizó la modificación " + error.ToString();
            }
            return mensaje;
        }// fin de modificarRolEsquema

        public string EliminarRol(string nom)
        {
            string mensaje = "Esquema de Rol eliminado satisfactoriamente";
            try
            {
                //instrucción para modificar en la BD
                inst = new SqlCommand("DROP ROLE " + nom, sqlconex);
                inst.ExecuteNonQuery();//ejecución de una acción sobre la base de datos (inserciones, modificaciones o eliminar).
            }
            catch (Exception error)
            {
                mensaje = "No se realizó la modificación " + error.ToString();
            }
            return mensaje;
        } // fin de eliminar rol

        //--------------------------------------------------------------------------------------------------------
        //--------------------------LOGIN------------------LOGIN-------------------LOGIN--------------------------
        //________________________________________________________________________________________________________

        public string insertarlogin(string nom, string contra, string bd)
        {
            string mensaje = "Registro insertado satisfactoriamente";
            try
            {
                //instrucción para insertar en la BD
                inst = new SqlCommand("USE [master] CREATE LOGIN " + nom + " WITH PASSWORD = N' " + contra + "', DEFAULT_DATABASE = [" + bd+" ] , CHECK_EXPIRATION=OFF, CHECK_POLICY= OFF", sqlconex);
                inst.ExecuteNonQuery();//ejecución de una acción sobre la base de datos (inserciones, modificaciones o eliminar).
            }
            catch (Exception error)
            {
                mensaje = "No se realizó la inserción " + error.ToString();
            }
            return mensaje;
        } // fin de insertarLOGIN
        public string modificarloginname(string name, string newname)
        {
            string mensaje = "Registro modificado satisfactoriamente";
            try
            {
                //instrucción para modificar en la BD
                inst = new SqlCommand("ALTER LOGIN " + name + " WITH NAME =" + newname, sqlconex);
                inst.ExecuteNonQuery();//ejecución de una acción sobre la base de datos (inserciones, modificaciones o eliminar).
            }
            catch (Exception error)
            {
                mensaje = "No se realizó la modificación " + error.ToString();
            }
            return mensaje;
        }// fin de modificarloginname

        public string modificarlogincontra(string nombre, string contranew)
        {
            string mensaje = "Login modificado satisfactoriamente";
            try
            {
                //instrucción para modificar en la BD
                inst = new SqlCommand("ALTER LOGIN " + nombre + " WITH PASSWORD = '" + contranew + "'", sqlconex);
                inst.ExecuteNonQuery();//ejecución de una acción sobre la base de datos (inserciones, modificaciones o eliminar).
            }
            catch (Exception error)
            {
                mensaje = "No se realizó la modificación " + error.ToString();
            }
            return mensaje;
        }// fin de modificarlogincontra

        //--------------------------------------------------------------------------------------------------------
        //--------------------------USUARIO------------------USUARIO-------------------USUARIO--------------------------
        //________________________________________________________________________________________________________

        public string insertaruser(string nom, string login)
        {
            string mensaje = "Registro insertado satisfactoriamente";
            try
            {
                //instrucción para insertar en la BD
                inst = new SqlCommand("CREATE USER " + nom + " FOR LOGIN  " + login, sqlconex);
                inst.ExecuteNonQuery();//ejecución de una acción sobre la base de datos (inserciones, modificaciones o eliminar).
            }
            catch (Exception error)
            {
                mensaje = "No se realizó la inserción " + error.ToString();
            }
            return mensaje;
        } // fin de insertarusuario
        public string modificarUser(string name, string newname)
        {
            string mensaje = "Registro modificado satisfactoriamente";
            try
            {
                //instrucción para modificar en la BD
                inst = new SqlCommand("ALTER USER " + name + " WITH NAME " + newname + "", sqlconex);
                inst.ExecuteNonQuery();//ejecución de una acción sobre la base de datos (inserciones, modificaciones o eliminar).
            }
            catch (Exception error)
            {
                mensaje = "No se realizó la modificación " + error.ToString();
            }
            return mensaje;
        }// fin de midificarUser
        public string EliminarUser(string name)
        {
            string mensaje = "Usuario eliminado satisfactoriamente";
            try
            {
                //instrucción para modificar en la BD
                inst = new SqlCommand("DROP USER " + name, sqlconex);
                inst.ExecuteNonQuery();//ejecución de una acción sobre la base de datos (inserciones, modificaciones o eliminar).
            }
            catch (Exception error)
            {
                mensaje = "No se puedo eliminar este usuario" + error.ToString();
            }
            return mensaje;
        }// fin de eliminaruser

        public string EliminarLogin(string name)
        {

            string mensaje = "LOGIN eliminado satisfactoriamente";
            try
            {
                //instrucción para modificar en la BD
                inst = new SqlCommand("DROP LOGIN " + name, sqlconex);
                inst.ExecuteNonQuery();
            }
            catch (Exception error)
            {
                mensaje = "No se realizó la modificación " + error.ToString();
            }
            return mensaje;
        } // fin de EliminarLogin 




        // -------------------------------------------------------------------------------------
        // consultar 

        public string cargarrol(string nom)//Carga los datos en el formulario cuando encuentra un registro. Es string porque solo se ocupa que devuelva el nombre.
        {
            rol = null;
            inst = new SqlCommand("Use[clinicasCR] SELECT * FROM sysusers where name = '" + nom + "'", sqlconex);
            rsregis = inst.ExecuteReader();
            if (rsregis.Read() == true)
            {
                rol = rsregis["name"].ToString();

                if (rol == nom)
                {
                    rsregis.Close();//Cierra la consulta.
                    rol = "si"; // si existe el rol
                }
                if (rol == null)
                {
                    rol = "No"; // no existe el rol
                }
            }
            rsregis.Close();//Cierra la consulta. sp_Addlogin 'Usuario_SysOF', 'miClave'
            return rol;
        } // fin de cargarrol

        public string cargaSchem(string nomrol)
        {
            rol = null;
            inst = new SqlCommand("Use[clinicasCR] select * from clinicasCR.sys.database_principals where name = '" + nomrol + "'", sqlconex);
            rsregis = inst.ExecuteReader();
            if (rsregis.Read() == true)
            {
                scheRol = rsregis["default_schema_name"].ToString();

            }
            rsregis.Close();//Cierra la consulta.
            return scheRol;
        } // cargar schema



        public string cargarLoginUsuario(string nomUser)
        {
            rol = null;
            inst = new SqlCommand("SELECT * FROM clinicasCR.sys.syslogins WHERE name ='" + nomUser + "'", sqlconex);
            rsregis = inst.ExecuteReader();

            if (rsregis.Read() == true)
            {
                rol = rsregis["loginname"].ToString();

            }
            if (rol == "")
            {
                rol = "no"; // no existe
            }

            rsregis.Close();
            return rol;
        }// fin de cargarLoginUsuario

        public string cargarUsuario(string nomUser)
        {
            rol = null;
            inst = new SqlCommand("Use[clinicasCR] SELECT * from clinicasCR.sys.sysusers where name='" + nomUser + "'", sqlconex);
            rsregis = inst.ExecuteReader();

            if (rsregis.Read() == true)
            {
                rol = rsregis["name"].ToString();

            }
            if (rol == nomUser)
            {
                rol = "si";
            }
            rsregis.Close();

            return rol;
        }// fin de cargarUser

        public string cargarLogin(string nomLogin)
        {
            rol = null;
            inst = new SqlCommand(" SELECT * FROM sys.syslogins WHERE loginname = '" + nomLogin + "'", sqlconex);
            rsregis = inst.ExecuteReader();

            if (rsregis.Read() == true)
            {
                rol = rsregis["loginname"].ToString();

            }


            rsregis.Close();
            return rol;
        }// fin de cargarlogin

        public string cargarBDlogin(string nomLogin)
        {
            rol = null;
            inst = new SqlCommand(" SELECT * FROM sys.syslogins WHERE ( loginname = '" + nomLogin + "')", sqlconex);
            rsregis = inst.ExecuteReader();

            if (rsregis.Read() == true)
            {
                rol = rsregis["dbname"].ToString();

            }


            rsregis.Close();
            return rol;
        }// fin de cargar la base de datos que esta asociada a un login 


        public string permisoGrant(string nomRol, string tabla, String permiso)
        {
            rol = null;
            inst = new SqlCommand("Use[clinicasCR] select * from permisos where( principal_name = '" + nomRol + "') and (object_name = '" + tabla + "') and (permission_state_desc = 'GRANT') and (permission_name = '" + permiso + "')", sqlconex);
            rsregis = inst.ExecuteReader();
            if (rsregis.Read() == true)
            {
                rol = rsregis["permission_name"].ToString();// esta variable tiene el objeto sobre el que el rol tiene el permiso



            }
            rsregis.Close();//Cierra la consulta.
            return rol;
        } // cargar permiso con grant
        public string cargarObjeto(string nomObj)
        {
            rol = null;
            inst = new SqlCommand("Use[clinicasCR] select * from permisos where (principal_name = '" + nomObj + "')  and (permission_state_desc = 'GRANT') ", sqlconex);
            rsregis = inst.ExecuteReader();
            if (rsregis.Read() == true)
            {
                rol = rsregis["object_name"].ToString();// esta variable tiene el objeto sobre el que el rol tiene el permiso



            }
            rsregis.Close();//Cierra la consulta.
            return rol;
        } // cargar objeto

        public string permisoDeny(string nomRol, string tabla, String permiso)
        {
            rol = null;
            inst = new SqlCommand("Use[clinicasCR] select * from permisos where( principal_name = '" + nomRol + "') and (object_name = '" + tabla + "') and (permission_state_desc = 'DENY') and (permission_name = '" + permiso + "')", sqlconex);
            rsregis = inst.ExecuteReader();
            if (rsregis.Read() == true)
            {
                rol = rsregis["permission_name"].ToString();// esta variable tiene el objeto sobre el que el rol tiene el permiso



            }
            rsregis.Close();//Cierra la consulta.
            return rol;
        } // cargar permiso con deny
        public string cargaTablaGrant(string nomtabla)
        {
            rol = null;
            inst = new SqlCommand("Use[clinicasCR] select * from permisos where (object_name = '" + nomtabla + "') and (permission_state_desc = 'GRANT')", sqlconex);
            rsregis = inst.ExecuteReader();
            if (rsregis.Read() == true)
            {
                rol = rsregis["principal_name"].ToString();// esta variable tiene el objeto sobre el que el rol tiene el permiso



            }
            rsregis.Close();//Cierra la consulta.
            return rol;
        } // cargar permiso con deny
        public string permisoRolGrant(string nomRol, string tabla, String permiso)
        {
            rol = null;
            inst = new SqlCommand("Use[clinicasCR] select * from permisos where( principal_name = '" + nomRol + "') and (object_name = '" + tabla + "') and (permission_state_desc = 'GRANT') and (permission_name = '" + permiso + "')", sqlconex);
            rsregis = inst.ExecuteReader();
            if (rsregis.Read() == true)
            {
                rol = rsregis["permission_name"].ToString();// esta variable tiene el objeto sobre el que el rol tiene el permiso



            }
            rsregis.Close();//Cierra la consulta.
            return rol;
        } // cargar permiso de rol con grant
        public string permisoRolDeny(string nomRol, string tabla, String permiso)
        {
            rol = null;
            inst = new SqlCommand("Use[clinicasCR] select * from permisos where( principal_name = '" + tabla + "') and (object_name = '" + nomRol + "') and (permission_state_desc = 'DENY') and (permission_name = '" + permiso + "')", sqlconex);
            rsregis = inst.ExecuteReader();
            if (rsregis.Read() == true)
            {
                rol = rsregis["permission_name"].ToString();// esta variable tiene el objeto sobre el que el rol tiene el permiso



            }
            rsregis.Close();//Cierra la consulta.
            return rol;
        } // cargar permiso de rol con grant
        public string cargaRolDeny(string nomtabla)
        {
            rol = null;
            inst = new SqlCommand("Use[clinicasCR] select * from permisos where (object_name = '" + nomtabla + "') and (permission_state_desc = 'DENY')", sqlconex);
            rsregis = inst.ExecuteReader();
            if (rsregis.Read() == true)
            {
                rol = rsregis["principal_name"].ToString();// esta variable tiene el objeto sobre el que el rol tiene el permiso



            }
            rsregis.Close();//Cierra la consulta.
            return rol;
        } // cargar tabla con deby
        public string cargaTablaRolGrant(string nomrol, string nomtabla, string permiso)
        {
            rol = null;
            inst = new SqlCommand("Use[clinicasCR] select * from permisos where (object_name = '" + nomtabla + "') and ( principal_name = '" + nomrol + "') and (permission_state_desc = 'GRANT') and (permission_name = '" + permiso + "')", sqlconex);
            rsregis = inst.ExecuteReader();
            if (rsregis.Read() == true)
            {
                rol = rsregis["permission_name"].ToString();// esta variable tiene el objeto sobre el que el rol tiene el permiso



            }
            rsregis.Close();//Cierra la consulta.
            return rol;
        } // cargar permisos que tengan en comun la tabla y el rol y el GRANT

        public string cargaTablaRolDeny(string nomrol, string nomtabla, string permiso)
        {
            rol = null;
            inst = new SqlCommand("Use[clinicasCR] select * from permisos where (object_name = '" + nomtabla + "') and ( principal_name = '" + nomrol + "') and (permission_state_desc = 'DENY') and (permission_name ='" + permiso + "')", sqlconex);
            rsregis = inst.ExecuteReader();
            if (rsregis.Read() == true)
            {
                rol = rsregis["permission_name"].ToString();// esta variable tiene el objeto sobre la consulta que se realizo en inst



            }
            rsregis.Close();//Cierra la consulta.
            return rol;
        } // cargar permisos que tengan en comun la tabla y el rol y el Deny


        public string ifexistBD(string bd)
        {
            rol = null;
            inst = new SqlCommand("select * from sysdatabases where name = '" + bd + "'", sqlconex);
            rsregis = inst.ExecuteReader();
            if (rsregis.Read() == true)
            {
                rol = rsregis["name"].ToString();// esta variable tiene el objeto sobre la consulta que se realizo en inst


            }
            rsregis.Close();//Cierra la consulta.
            return rol;
        }// retorna si a base de datos existe



//.---------------------------------------------------------------------------------------------------------------------------------
//     METODOS DE CARGAR PARA LOGIN
//----------------------------------------------------------------------------------------------------------------------------------

       public string serverRol(string login) // muestra si un login tiene un rol de servidor
        {
            

            rol = null;
            inst = new SqlCommand("use[clinicasCR] select * from serverRol where Login = '" + login + "'", sqlconex);
            rsregis = inst.ExecuteReader();
            if (rsregis.Read() == true)
            {
                rol = rsregis["ServerRol"].ToString();// esta variable tiene el nombre del rol que estamos solicitando
                rsregis.Close();//Cierra la consulta.

            }
            rsregis.Close();//Cierra la consulta.
            return rol;
        }

        public string rolBD(string login) // muestra si un login tiene un rol de servidor
        {


            rol = null;
            inst = new SqlCommand("use[clinicasCR] select Grupo from VIS_USUARIOSXGRUPO where Usuario = '" + login + "'", sqlconex);
            rsregis = inst.ExecuteReader();
            if (rsregis.Read() == true)
            {
                rol = rsregis["ServerRol"].ToString();// esta variable tiene el nombre del rol que estamos solicitando
                rsregis.Close();//Cierra la consulta.

            }
            rsregis.Close();//Cierra la consulta.
            return rol;
        }

        public string ValidarContra(string user, string contra) // muestra si un login tiene un rol de servidor
        {
            string usuario;
            string contraseña;
            string mensaje = "contraseña correcta";

            try
            {


                if (user != "" && contra != "")
                {
                    usuario = user;
                    contraseña = contra;
                    sqlconex = new SqlConnection("Data Source=.;Initial Catalog= master;User ID=" + user + ";Password=" + contra);
                    sqlconex.Open();
       
                }
                else
                {

                    mensaje = "Contraseña Incorrecta";
                }

            }
            catch (Exception error)
            {
                mensaje = "No se pudo conectar";
            }
          
            return mensaje;
        }

        public string ValidarContra2(string user, string contra) // muestra si un login tiene un rol de servidor
        {
            string usuario;
            string contraseña;
            string mensaje = "contraseña correcta";

            try
            {


                if (user != "" && contra != "")
                {
                    usuario = user;
                    contraseña = contra;
                    sqlconex = new SqlConnection("Data Source=.;Initial Catalog= clinicasCR;User ID=" + user + ";Password=" + contra);
                    sqlconex.Open();

                }
                else
                {

                    mensaje = "Contraseña Incorrecta";
                }

            }
            catch (Exception error)
            {
                mensaje = "No se pudo conectar";
            }

            return mensaje;
        }
        //-------------------------------------------------------------------------------------------------------------------------------------------------
        //                      ASIGNACION DE ROLES DE SERVIDOR
        // --------------------------------------------------------------------------------------------------------

        public string AsignarServerRol(string login, string role) // muestra si un login tiene un rol de servidor
        {
            string mensaje;
            try
            {
                rol = null;
                inst = new SqlCommand(" use[master] ALTER SERVER ROLE [" + role + "] ADD MEMBER [ " + login + "]", sqlconex);
                //rsregis = inst.ExecuteReader();
                inst.ExecuteNonQuery();
                mensaje = "Rol de Servidor Asignado Satisfactoriamente";
            }
            catch(Exception error)
            {
                mensaje = "No se pudo Asignar";
            }
           
            return mensaje;
        }


        public string QuitarServerRol(string login, string role) // muestra si un login tiene un rol de servidor
        {
            string mensaje;
            try
            {
                rol = null;
                inst = new SqlCommand(" use[master] ALTER SERVER ROLE ["+ role +"] DROP MEMBER ["+ login+"]", sqlconex);
                //rsregis = inst.ExecuteReader();
                inst.ExecuteNonQuery();
                mensaje = "Rol de Servidor Eliminado Satisfactoriamente";
            }
            catch (Exception error)
            {
                mensaje = "No se pudo Asignar" + error.ToString();
            }
         
            return mensaje;
        }
        public string buscarRolLogin(string login/*, string role*/) // muestra si un login tiene un rol de servidor
        {

            //  and (ServerRol = '"+ role+"')
            rol = null;
                inst = new SqlCommand(" use[clinicasCR] select * from serverRol where (Login = '"+ login+"') ", sqlconex);
                rsregis = inst.ExecuteReader();
            if (rsregis.Read() == true)
            {
                rol = rsregis["ServerRol"].ToString();// esta variable tiene el nombre del rol que estamos solicitando
                rsregis.Close();//Cierra la consulta.

            }
        
         
            rsregis.Close();//Cierra la consulta.
            return rol;
        }
        //---------------------------------------------------------------------------------------------------------------------
        //                            BLOQUEAR USUARIO
        // --------------------------------------------------------------------------------------------------------------------


        public string bloqueaLogin(string login) // muestra si un login tiene un rol de servidor
        {
            string mensaje;
            try
            {
                rol = null;
                inst = new SqlCommand(" use[master] DENY CONNECT SQL TO [" + login + "] go ALTER LOGIN [" +login + "] DISABLE " , sqlconex);
                rsregis = inst.ExecuteReader();
                mensaje = "Usuario Bloqueado Temporalmente";
            }
            catch (Exception error)
            {
                mensaje = "No se pudo bloquear" + error.ToString();
            }

            return mensaje;
        }
        public string conectividad(string login) // muestra si un login tiene un rol de servidor
        {

            rol = null;
            inst = new SqlCommand(" use[master]select * from syslogins where loginname = '" + login + "'", sqlconex);
            rsregis = inst.ExecuteReader();
            if (rsregis.Read() == true)
            {
                rol = rsregis["denylogin"].ToString();// esta variable tiene el nombre del rol que estamos solicitando
                rsregis.Close();//Cierra la consulta.

            }
            rsregis.Close();//Cierra la consulta.
            return rol;
        }

        public string Login(string login) // activa la conectividad 
        {
            string mensaje;
            try
            {
                rol = null;
                inst = new SqlCommand(" use[master]GRANT CONNECT SQL TO ["+ login + "] go ALTER LOGIN [" + login + "] DISABLE ", sqlconex);
                rsregis = inst.ExecuteReader();
                mensaje = "Usuario Bloqueado Temporalmente";
            }
            catch (Exception error)
            {
                mensaje = "No se pudo bloquear" + error.ToString();
            }

            return mensaje;
        }

        public string DenyConex(string login) // muestra si un login tiene un rol de servidor
        {
            string mensaje;
            try
            {
                rol = null;
                inst = new SqlCommand(" use[master] DENY CONNECT SQL TO [" + login + "] go ALTER LOGIN [" + login + "] DISABLE ", sqlconex);
                rsregis = inst.ExecuteReader();
                mensaje = "Denega conexion";
            }
            catch (Exception error)
            {
                mensaje = "No se degenó la conexion" + error.ToString();
            }

            return mensaje;
        }
        public string GrantConex(string login) // muestra si un login tiene un rol de servidor
        {
            string mensaje;
            try
            {
                rol = null;
                inst = new SqlCommand(" use[master] GRANT CONNECT SQL TO [" + login + "] go ALTER LOGIN [" + login + "] enable ", sqlconex);
                rsregis = inst.ExecuteReader();
                mensaje = "Se habilito la conexion";
            }
            catch (Exception error)
            {
                mensaje = "No se pudo dar la conexion" + error.ToString();
            }

            return mensaje;
        }

    }// fin
}
   
    