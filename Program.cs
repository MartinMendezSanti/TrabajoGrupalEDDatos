using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace trabajogrupalEDDatos
{
    //Clase alumno
    public class Alumno
    {
        public string Name { get; set; }
        public int Nota1 { get; set; }
        public int Nota2 { get; set; }
        public int Nota3 { get; set; }
        public string Lastname { get; set; }

        public override string ToString()
        {
            return "Alumno: " + Name + " " + Lastname + " - Notas: " + Nota1 + " / " + Nota2 + " / " + Nota3;
        }
    }
    class Program
    {
        
        public static void PromediarAlumno(List<Alumno> listado)
        {
            for (int i = 0; i < listado.Count; i++)
            {
                Console.Write(listado[i].Name + " " + listado[i].Lastname);
                float promedio = (listado[i].Nota1 + listado[i].Nota2 + listado[i].Nota3) / 3;

                if (promedio != 0)
                {
                    Console.Write(" tiene de promedio: " + promedio + "\n");
                }
                else
                {
                    Console.Write(" : No tiene notas cargadas. \n");
                }
            }
        }
        public static void BuscarAlumno(List<Alumno> lista)
        {
            //Buscar alumno
            Console.Write("\nSi desea buscar alumno escriba su nombre: ");
            string buscado = Console.ReadLine();
            Console.WriteLine("\nDatos del alumno: {0}\n", lista.Find(x => x.Name.Contains(buscado)));
        }
        public static List<Alumno> IngresarAlumnos()
        {
            //Lista de alumnos
            List<Alumno> listaDeAlumnos = new List<Alumno>();

            //Flag para terminar la carga
            string salir = "no";


            //Carga de datos
            do
            {
                Console.Write("\nIngrese nombre alumno: ");
                string nombre = Console.ReadLine();
                Console.Write("Ingrese apellido del alumno: ");
                string apellido = Console.ReadLine();

                listaDeAlumnos.Add(new Alumno() { Name = nombre, Lastname = apellido });
                Console.Write("\n> ¿Desea agregar más alumnos? si/no  ");
                salir = Console.ReadLine();

            }
            while (salir != "no");

            return listaDeAlumnos;
        }
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
            {
                return usuario;
            }
            else
            {
                Console.WriteLine("Usuario o contraseña incorrectos");
                IngresoUsuario(diccionario);
                return usuario;

                //PROBLEMA: si al principio se pone un usuario incorrecto y se entra en este else
                //el usuario que se termina retornando cuando finalmente ingrese el correcto es el
                //primer usuario incorrecto que ingresó. Ver cómo se puede arreglar.
            }


        }

        public static int validador()
        {
            int valor;
            string num;
            bool esNumero;
            do
            {
                Console.Write("Ingrese nota entre 1 y 10: ");
                num = Console.ReadLine();
                /* Si es número correcto retornará true y saldrá del Ciclo*/
                esNumero = int.TryParse(num, out valor);

                while (valor > 10 || valor < 0)
                {
                    Console.Write("Numero incorrecta, ingrese nota entre 1 y 10: ");
                    num = Console.ReadLine();
                    esNumero = int.TryParse(num, out valor);
                }
                if (!esNumero) Console.Write("Nota incorrecta.");
            }
            while (!esNumero);

            return valor;
        }
        public static List<Alumno> IngresarNotas(ref List<Alumno> listado)
        {
            //Agregar Nota a algun alumno en particular
            string salir;
            do
            {
                Console.Write("\nEscriba el nombre del alumno que desea agregar las notas: ");
                string buscarAlumno = Console.ReadLine();

                //Listado de alumnos con foreach
                foreach (Alumno lista in listado)
                {
                    if (lista.Name == buscarAlumno)
                    {
                        Console.WriteLine("\nIngresar a continuacion las 3 notas del cuatrimestre.\n");
                        int notauno = validador();
                        int notados = validador();
                        int notatres = validador();
                        lista.Nota1 = notauno; lista.Nota2 = notados; lista.Nota3 = notatres;
                    }

                }
                Console.Write("\n ¿Desea agregar más notas? si/no ");
                salir = Console.ReadLine();
            }
            while (salir != "no");

            return listado;

        }
        public static ArrayList GenerarUsuario()
        {
            //Se le pide al usuario ingresar un usuario, una contraseña y volver a ingresar la contraseña.
            
            string nombre_elegido, pass1, pass2;
            Console.WriteLine("Bienvenido al generador de usuario.");
            Console.WriteLine("Ingrese el nombre de usuario:");
            nombre_elegido = Console.ReadLine();
            Console.WriteLine("Ingrese la contraseña:");
            pass1 = Console.ReadLine();
            Console.WriteLine("Ingrese nuevamente la contraseña:");
            pass2 = Console.ReadLine();

            //Valida que la contraseña ingresada las dos veces coincida.
            while (pass1 != pass2)
            {
                Console.WriteLine("Las contraseñas no coincide. Intente nuevamente");
                Console.WriteLine("Ingrese la contraseña:");
                pass1 = Console.ReadLine();
                Console.WriteLine("Ingrese nuevamente la contraseña:");
                pass2 = Console.ReadLine();
            }

            //Crea una lista donde guarda los valores del nombre de usuario y contraseña para devolver eso.
            Console.WriteLine("Usuario y contraseña generado exitosamente.");
            ArrayList listaUsuario = new ArrayList();
            listaUsuario.Add(nombre_elegido);
            listaUsuario.Add(pass1);

            return listaUsuario;
            
        }
        static void Main(string[] args)
        {
            List<Alumno> listadoDeAlumnos = new List<Alumno>();
            int digito, opcion_elegida;
            string nombre_usuario, password;
            //Como no tenemos BD usamos un diccionario con el par usuario/clave.
            Hashtable diccioUsuarios = new Hashtable();
            diccioUsuarios.Add("Eduardo", "pass1");
            diccioUsuarios.Add("Mariela", "pass2");
            diccioUsuarios.Add("Pablo", "pass3");
            
            Console.WriteLine("Bienvenido al gestor de alumnos y cursadas");
            Console.WriteLine("Si ya posee un usuario ingrese 1; si desea generar un usuario ingrese 2");
            digito = Convert.ToInt32(Console.ReadLine());

            //Valida que se haya ingresado 1 o 2
            while (digito != 1 && digito != 2)
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
                
                //Llama a la función de generar usuario, que le va a devolver una lista.
                //Guarda los elementos de esa lista en variables string y los suma al
                //diccionario de usuario/clave.
                ArrayList lista_user = GenerarUsuario();
                nombre_usuario = (string) lista_user[0];
                password = (string) lista_user[1];
                diccioUsuarios.Add(nombre_usuario, password);
                Console.WriteLine("Bienvenido {0}", nombre_usuario);

            }

            Console.WriteLine("Porfavor ingrese el número de operación que desea realizar.");
            Console.WriteLine("Ingresar datos de un alumno: 1");
            Console.WriteLine("Ingresar notas: 2");
            Console.WriteLine("Ingresar notas: 3");
            Console.WriteLine("Calcular Promedio de un alumno: 4");
            Console.WriteLine("Calcular Promedio total del curso: 5");
            Console.WriteLine("Ver la cantidad de alumnos: 6");
            Console.WriteLine("Salir: 7");
            opcion_elegida = Convert.ToInt32(Console.ReadLine());

            switch (opcion_elegida)
            {
                case 1:
                    {
                        listadoDeAlumnos = IngresarAlumnos();
                        break;
                    }
                case 2:
                    {
                        IngresarNotas(ref listadoDeAlumnos);
                        break;
                    }
                case 3:
                    {
                        BuscarAlumno(listadoDeAlumnos);
                        break;
                    }
                case 4:
                    {
                        PromediarAlumno(listadoDeAlumnos);
                        break;
                    }
                case 5:
                    {
                        PromediarCurso();
                        break;
                    }
                case 6: 
                    { 
                        Console.WriteLine("\nEste curso tiene " + listadoDeAlumnos.Count + " alumnos.\n");
                        break;
                    }

                case 7:
                    {
                        Console.WriteLine("Gracias por usar el gestor de alumnos y cursadas");
                        break;
                    }
            }

        }
    }
}
