using System;

namespace PAC_Desarrollo_Entrega_2S2324
{
    public class Program
    {
        static void Main(string[] args)
        {
            //--- Declaracion de variables
            string frase = "";
            string resultado = "";


            //------------------------------------------------------------------------------------------ Ejecución libre del programa

            //-------------------------- Se valida que la frase introducida sea correcta
            do
            {
                Console.Write("Inserta una frase para que la analice: ");
                frase = Console.ReadLine();

            } while (FraseValida(frase) == false);

            //-------------------------- Se obtiene la cuenta de caracteres mayúsculos, minúsculos, numéricos y otros
            resultado = ContarCaracteres(frase);
            Console.WriteLine(resultado);

            //-------------------------- Se obtiene la frase invertida
            resultado = InvertirFrase(frase);
            Console.WriteLine(resultado);

            //-------------------------- Se obtiene la primera posición donde aparece el número que más veces está en el array
            Console.WriteLine(CaracterMasRepetido(frase));

            //--- Fin de la ejecución del programa

            


        }


        //---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------


        //VERIFICA QUE LA LONGITUD ESTÁ COMPRENDIDA ENTRE UNA CANTIDAD DETERMINADA DE CARACTERES, SI NO LO ESTÁ REPETIRÁ MENSAJE EN PANTALLA.
        public static bool FraseValida(string frase)
        {
            if (frase.Length >= 20 && frase.Length <= 55)               //si, longitud de frase es mayor o igual a 20 y menor o igual a 55 caracteres   
            {
                return true;                                            //devuelve un verdadero y procede con la secuencia del programa
            }
            else                                                        //si no cumple el verdadero entonces
            {
                return false;                                           //devuelve un falso y volverá a pedir una frase para analizar.
            }
        }
        //---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        //contamos el numero de caracteres ya sean mayusculas numeros o minusculas y en esta ultima metemos los caracteres especiales y espacios y lo describe en pantalla

        public static string ContarCaracteres(string frase)
        {
            int mayusculas = 0;
            int minusculas = 0;
            int numeros = 0;
            foreach (Char contabilizacion in frase)                     //para cada contabilizacion de la frase hacer
            {
                if (char.IsUpper(contabilizacion))                      //si cuenta letra mayusc
                {
                    mayusculas++;                                       //sumar 1 al apartado mayusculas y repetir hasta terminar la frase
                }
                else if (char.IsUpper(contabilizacion))                 //si cuenta letra minusc
                {
                    minusculas++;                                       //sumar 1 al apartado minusculas y repetir hasta terminar la frase
                }
                else if (char.IsNumber(contabilizacion))                //si cuenta numero
                {
                    numeros++;                                          //suma 1 al apartado numeros y repetir hasta terminar la frase
                }
                else                                                    //si cuenta caracter especial (ej: +-*/ )
                {
                    minusculas++;                                       //los almacenará como unidades en minusculas, sumando uno más
                }
            }
            return "La frase contiene " + mayusculas + " letras mayúsculas, " + minusculas + " letras minúsculas y " + numeros + " números.";
        }

        //---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        //invertimos una cadena de caracteres y la devuelve en pantalla invertida.

        public static string InvertirFrase(string frase)
        {
            string frasesentidocontrario = "";                         //se deja un espacio para almacenar la frase insertada pero en direccion contraria
            foreach (char letra in frase)                               //el bucle irá recorriendo cada caracter de la frase
            {
                frasesentidocontrario = letra + frasesentidocontrario;  //se "construye" la cadena de caracteres en sentido contrario
            }
            return frasesentidocontrario;                               //bucle acaba y la frase en sentido contrario vuelve al espacio que hemos dejado para almacenarla y mostrarla en pantalla
        }


        //busca la mayor cantidad de repeticiones y el 1º lugar que ocupa el caracter mas repetido
        public static string CaracterMasRepetido(string frase)
        {
            char[] arrLetras = new char[frase.Length];
            int[] arrContadorLetras = new int[frase.Length];
            int posicion;
            int contador;

            contador = 0;
            posicion = 0;
            for (int letras = 0; letras < frase.Length; letras++)        //hace el recorrido de todos los caracteres de "frase" sumando 1 a la variable ¨letras" 

            {
                char letraActual = frase[letras];                        //de "frase" saca cada letra de la posicion "letras" y la mete en "letraActual"
                bool encontrado = false;                                //hace el bucle empezando como "no encontrado" el caracter


                //el bucle se realiza por cada caracter. "letraActual" guarda el caracter y "encontrado" sabe si ya lo tenemos localizado o no.


                for (int iguales = 0; iguales < frase.Length; iguales++)        //hace el recorrido tantas veces como caracteres tengamos
                {
                    if (arrLetras[iguales] == letraActual)                      //si el caracter de "iguales" es el mismo que el de letraActual
                    {
                        arrContadorLetras[iguales]++;                           //suma 1 si encuentra caracteres iguales
                        encontrado = true;                                      //se encuentra el caracter actual
                        break;                                                  //para el bucle cuando encuentra caracteres iguales
                    }
                }


                //el bucle contará las veces que aparece una letra y se detine ante una coincidencia y suma 1 al contador del caracter correspondiente


                if (encontrado == false)                                        //no encuentra caracter repetido
                {
                    arrLetras[letras] = letraActual;                            //mete el caracter actual en "letras" 
                    arrContadorLetras[letras] = 1;                              //inicia el contador correspondiente ya que es la 1º vez que lo encuentra
                    contador++;                                                 //suma 1 al contador para decir que es un caracter nuevo
                }
            }


            //por cada caracter encontrado inicia el contador desde 1 y sumará 1 si se repite                    


            int maxCantidad = 0;                                                     //almacena la posicion del caracter mas repetido
            for (int posMasRepetido = 0; posMasRepetido < contador; posMasRepetido++)
            {
                if (arrContadorLetras[posMasRepetido] > maxCantidad)                    //mira si "arrContadorLetras" es mayor que la cantidad almacenada en "maxCantidad"
                {
                    maxCantidad = arrContadorLetras[posMasRepetido];                    //"maxCantidad" almacena el valor de la posicion más repetida
                    posicion = posMasRepetido + 1;                                         //guarda la posicion del caracter mas repetido partiendo de 1 ya que siempre hay contado 1 caracter
                }
            }


            if (contador > 1)
            {
                return "El valor '" + arrLetras[posicion - 1] + "' se repite " + arrContadorLetras[posicion - 1] + " veces y la primera vez que aparece en la frase es en la posición " + posicion + ".";
            }
            else
            {
                return "Todos los caracteres de la frase aparecen por igual.";
            }
        }
    }
}