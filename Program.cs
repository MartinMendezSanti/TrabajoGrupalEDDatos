using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace trabajogrupalEDDatos
{
    class Program
    {
        public static string IngresoUsuario(Hashtable diccionario)
        {
            string usuario, pass;
            int contador = 0;
            
            //Pedimos que ingrese su usuario y contraseña
            Console.WriteLine("Ingrese su usuario:");
            usuario = Console.ReadLine();
            Console.WriteLine("Ingrese su contraseña:");
            pass = Console.ReadLine();
            
            //Vamos a enumerar el diccionario donde tenemos guardados los usuarios
            //para poder ir comparando si el usuario y contraseña ingresados se encuentran
            //en el diccionario; si es así se agrega un 1 al contador.
            IDictionaryEnumerator miEnumerador = diccionario.GetEnumerator();
            while (miEnumerador.MoveNext())
            {
                if (usuario == (string) miEnumerador.Key && pass == (string) miEnumerador.Value)
                    contador++;
            }

            //Si el contador es mayor a 0 significa que el par usuario/pass se encontró
            //en el diccionario por lo que es correcto. Sino notifica que no son correctos
            //y la función vuelve a llamarse a sí misma.

            if (contador > 0)
                return usuario;
            else
            {
                Console.WriteLine("Usuario o contraseña incorrectos");
                IngresoUsuario(diccionario);
                return usuario;
            }


        }

        public static ArrayList GenerarUsuario()
        {
            string nombre_elegido, pass1, pass2;
            Console.WriteLine("Bienvenido al generador de usuario.");
            Console.WriteLine("Ingrese el nombre de usuario:");
            nombre_elegido = Console.ReadLine();
            Console.WriteLine("Ingrese la contraseña:");
            pass1 = Console.ReadLine();
            Console.WriteLine("Ingrese nuevamente la contraseña:");
            pass2 = Console.ReadLine();

            while (pass1 != pass2)
            {
                Console.WriteLine("Las contraseñas no coincide. Intente nuevamente");
                Console.WriteLine("Ingrese la contraseña:");
                pass1 = Console.ReadLine();
                Console.WriteLine("Ingrese nuevamente la contraseña:");
                pass2 = Console.ReadLine();
            }

            Console.WriteLine("Usuario y contraseña generado exitosamente.");
            ArrayList listaUsuario = new ArrayList();
            listaUsuario.Add(nombre_elegido);
            listaUsuario.Add(pass1);

            return listaUsuario;
            
        }
        static void Main(string[] args)
        {
            int digito;
            string nombre_usuario, password;
            Hashtable diccioUsuarios = new Hashtable();
            diccioUsuarios.Add("Eduardo", "pass1");
            diccioUsuarios.Add("Mariela", "pass2");
            diccioUsuarios.Add("Pablo", "pass3");
            
            Console.WriteLine("Bienvenido al gestor de alumnos y cursadas");
            Console.WriteLine("Si ya posee un usuario ingrese 1; si desea generar un usuario ingrese 2");
            digito = Convert.ToInt32(Console.ReadLine());

            while (digito != 1 || digito != 2)
            {
                Console.WriteLine("Ingresó un caracter incorrecto. Intente nuevamente");
                Console.WriteLine("Si ya posee un usuario ingrese 1; si desea generar un usuario ingrese 2");
                digito = Convert.ToInt32(Console.ReadLine());
            }

            if (digito == 1)
            {
                nombre_usuario = IngresoUsuario(diccioUsuarios);
                Console.WriteLine("Bienvenido {0}", nombre_usuario);
            }
            else if (digito == 2)
            { 
                ArrayList lista_user = GenerarUsuario();
                nombre_usuario = (string) lista_user[0];
                password = (string) lista_user[1];
                diccioUsuarios.Add(nombre_usuario, password);
                Console.WriteLine("Bienvenido {0}", nombre_usuario);

            }

        }
    }
}
